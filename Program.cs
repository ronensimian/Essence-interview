using System;
using System.Diagnostics;



namespace RonenSimianSolution
{
    class Program
    {
        #region Variables

        static string myHexNumberString = "0F";
        static string resultQ1;
        static string myHexNumberAsBits = "";
        static int myPosition = 4; // position from left of binary string
        static int myBitValue = 1;
        static int myStatus = -1;
        static string mySource = "I like the number 5, that's it for sure.";
        static string myStartString = "number";
        static string myEndString = "it";
        static string resultQ2;
        static string mySourcePath = @"C:\fromHere";
        static string myDestinationPath = @"C:\intoHere";
        static string resultQ3;

        #endregion Variables


        static void Main()
        {
            MySolutions ms = new MySolutions();

            #region Q1
            
            myHexNumberAsBits = ms.GetHexAsBits(myHexNumberString);

            myStatus = ms.SwitchByteHexString(ref myHexNumberAsBits, myPosition, myBitValue);
            if (myStatus == 0)
            {
                resultQ1 = Convert.ToInt32(myHexNumberAsBits, 2).ToString("X2");
                Trace.WriteLine("The solution for Q1 is: " + resultQ1);
            }
            else // fail or exception
            {
                Trace.WriteLine("FAIL Q1");
            }

            #endregion Q1


            #region Q2

            resultQ2 = ms.GetSubStringBetween(mySource, myStartString, myEndString);
            if (resultQ2 != "")
            {
                Trace.WriteLine("The substring for Q2 is: " + resultQ2);
            }
            else
            {
                Trace.WriteLine("FAIL Q2");
            }

            #endregion Q2


            #region Q3

            resultQ3 = ms.CopyAllFiles(mySourcePath, myDestinationPath, ref myStatus);
            Trace.WriteLine(resultQ3);

            #endregion Q3

        }
    }
}
