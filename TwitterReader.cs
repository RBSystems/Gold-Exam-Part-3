using System;
using System.Text;
using Crestron.SimplSharp;                          				// For Basic SIMPL# Classes
using Crestron.SimplSharp.Net.Https;
using Crestron.SimplSharp.CrestronIO;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace SIMPLSharpTwitter
{
    public class TwitterReader
    {
        public string ConsumerKey;
        public string ConsumerSecret;
        private string ConsumerBase64;
        private string BearerToken;

        public const string Const_TwitterDateTemplate = "ddd MMM dd HH:mm:ss +ffff yyyy";

        /// <summary>
        /// SIMPL+ can only execute the default constructor. If you have variables that require initialization, please
        /// use an Initialize method
        /// </summary>
        public TwitterReader()
        {
        }

        public void sendOAuthPost()
        {
            var authHeaderFormat = "Basic {0}";
            ConsumerBase64 = string.Format(authHeaderFormat, Convert.ToBase64String(Encoding.UTF8.GetBytes(Uri.EscapeDataString(ConsumerKey) + ":" +
                Uri.EscapeDataString(ConsumerSecret))));
            
            HttpsClient myClient = new HttpsClient();
            myClient.UserAgent = "GoldTestv1";
            HttpsClientRequest authRequest = new HttpsClientRequest();
            authRequest.Url.Parse("https://api.twitter.com/oauth2/token");
            authRequest.RequestType = RequestType.Post;
            authRequest.Header.AddHeader(new HttpsHeader("Authorization", ConsumerBase64));
            authRequest.Header.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            authRequest.Header.AddHeader(new HttpsHeader("Content-Length", "29"));

            String postBody = "grant_type=client_credentials";
            authRequest.ContentSource = ContentSource.ContentString;
            authRequest.ContentString = postBody;


            HttpsClientResponse authResponse;
            authResponse = myClient.Dispatch(authRequest);

            processBearer(authResponse.ContentString);
        }
        private void processBearer(String authResponse)
        {
            TwitterJson.tokenJson testJson = new TwitterJson.tokenJson();        
            testJson = JsonConvert.DeserializeObject<TwitterJson.tokenJson>(authResponse);        
            BearerToken = testJson.AccessToken;
            ApiRequest();
        }

        public void ApiRequest()
        {
            if (BearerToken.Length > 0)
            {
                HttpsClient myClient = new HttpsClient();
                myClient.UserAgent = "GoldTestv1";
                HttpsClientRequest authRequest = new HttpsClientRequest();              
                authRequest.Url.Parse("https://api.twitter.com/1.1/statuses/user_timeline.json?count=10&screen_name=CrestronHQ&exclude_replies=true");
                authRequest.RequestType = RequestType.Get;
                authRequest.Header.AddHeader(new HttpsHeader("Authorization", "Bearer " + BearerToken));

                HttpsClientResponse apiResponse;
                apiResponse = myClient.Dispatch(authRequest);

                parseTweets(apiResponse.ContentString);
            }
        }

        public void parseTweets(String apiResponse)
        {
            String[] subStrings;
            subStrings = apiResponse.Split(',');
            foreach (string str in subStrings)
            {
                CrestronConsole.PrintLine("{0}", str);
            }   

            var result = JsonConvert.DeserializeObject<List<TwitterJson.tweetConfig>>(apiResponse);

            foreach (TwitterJson.tweetConfig config in result)
            {
                DateTime createdAt = DateTime.ParseExact((string)config.created_at, Const_TwitterDateTemplate, new System.Globalization.CultureInfo("en-US"));
                CrestronConsole.PrintLine("created_at {0} ", createdAt.ToString("hh:mm tt MM/dd/yyyy"));
                CrestronConsole.PrintLine("{0}", config.text);
            }

        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }


        /* Input from Splus Module***********************************
         * These functions are called from Simpl+ when ever an
         * event there happens. The call should include a uniqiue
         * name for the Digital,Analog,Serial,or Buffer input
         * on the Simpl+ wrapper module that changed and the value
         * it changed to. For digital send a 1 or 0. Then a delegate 
         * should be invoked on the calling namespace for handling. 
         * new dgInput(YourFunctionName);
        ************************************************************/
        //public delegate void INPUTDELEGATE(String sName, String sValue);
        //public INPUTDELEGATE dgInput { get; set; }
        public void InputChange(String sName, String sValue)//Simpl+ DIGITAL_INPUT PUSH Event
        {
            switch (sName)
            {
                case ("Device_Tx$"): /*Transmit(sValue);*/ break;
            }
        }
        /* Output to Splus Module************************************
         * A delegate in the calling namespace should point to a 
         * function in this module with parameters sName and sValue.
         * Then this class' delegate should point to a function (UpdateSP)
         * in simpl+ to update feedback.
         * 
         * SIMPL#
         * using SplusIO; //add reference to SplusIO.dll
         * SPIO mySPIO=new SPIO();
         * public delegate void SPIODelegate(String sName,String sValue);
         * public SPIODelegate dgSPIO;
         * public void UpdateFeedback(String sName,String sValue)
         * {
         *     dgSPIO= new SPIODelegate(mySPIO.UpdateSP);
         * }
         * 
         * simpl+ RegisterDelegate(<yourclassname>,dgOutput,<simpl+function>);
         * simpl+ CALLBACK FUNCTION SpUpdate (String sName, String sValue)
         * {
         *      switch(sName)
         *      {
         *          case ("btn123"):
         *              btn123=ATOI(sValue);
         *          case ("analog1"):
         *              analog1=ATOI(sValue);
         *          case ("serialout1"):
         *              serialout1=sValuel;
         * }
        ************************************************************/
        public delegate void OUTPUTDELEGATE(SimplSharpString sName, SimplSharpString sValue);
        public OUTPUTDELEGATE dgOutput { get; set; }

        public void UpdateSP(String sName, String sValue)
        {
            if (dgOutput != null)//Check if it is defined in simpl+
            {
                dgOutput(sName, sValue);
            }
        }
    }


}
