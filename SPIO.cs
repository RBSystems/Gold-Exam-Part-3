using System;
using System.Text;
using Crestron.SimplSharp;                          				// For Basic SIMPL# Classes
/*  
 * 
*/

namespace SplusIO
{
    public class SPIO
    {
        /// <summary>
        /// SIMPL+ can only execute the default constructor. If you have variables that require initialization, please
        /// use an Initialize method
        /// </summary>        
        public SPIO()
        {


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
        public delegate void INPUTDELEGATE(String sName, String sValue);
        public INPUTDELEGATE dgInput { get; set; }
        public void InputChange(String sName, String sValue)//Simpl+ DIGITAL_INPUT PUSH Event
        {
            //"Btn1","0"
            //"Btn1","1"
            //"device_rx$","POWR0   \x0d" 
            //"Volume12","65535"
            if (dgInput != null)//Check if it is defined in calling namespace
            {
                CrestronConsole.PrintLine("InputChange {0}, {1}", sName, sValue);
                dgInput(sName, sValue); //report nName pressed
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
            CrestronConsole.PrintLine("UpdateSP {0}, {1}", sName, sValue);
            if (dgOutput != null)//Check if it is defined in simpl+
            {
                CrestronConsole.PrintLine("dgOutput != null, calling simpl+");
                dgOutput(sName, sValue);
            }
        }
    }
}

