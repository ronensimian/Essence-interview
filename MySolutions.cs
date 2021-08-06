using System;
using System.IO;
using System.Threading;

namespace RonenSimianSolution
{
    public class MySolutions
    {
        public static void Main()
        {
        }

        public string GetHexAsBits(string HexNumber)
        {
            string hexAsBits = "";
            byte hexAsByte;

            try
            {
                hexAsByte = Convert.ToByte(HexNumber, 16);
                hexAsBits = Convert.ToString(hexAsByte, 2).PadLeft(8, '0');
            }
            catch (Exception)
            {
                hexAsBits = "";
            }
            return hexAsBits;
        }

        public int SwitchByteHexString(ref string HexNumberString, int Position, int BitValue)
        {
            int status = -1; // "fail" or "exception"
            char bitValue;

            if (BitValue == 1)
            {
                bitValue = '1';
            }
            else if (BitValue == 0)
            {
                bitValue = '0';
            }
            else
            {
                return status; // bit value is not 0 or 1
            }

            try
            {
                char[] charArray = HexNumberString.ToCharArray();

                charArray[Position - 1] = bitValue;

                HexNumberString = new string(charArray);

                status = 0; // PASS

            }
            catch (Exception)
            {
            }

            return status;
        }

        public string GetSubStringBetween(string Source, string StartString, string EndString)
        {
            // result includes start and end strings
            string subStr;
            int startIndex = 0;
            int endIndex = Source.Length;
            int length;

            try
            {
                if (Source.Contains(StartString))
                {
                    startIndex = Source.IndexOf(StartString);
                }
                if (Source.Contains(EndString))
                {
                    endIndex = Source.IndexOf(EndString);
                }

                length = endIndex - startIndex;

                subStr = Source.Substring(startIndex, length);
            }
            catch (Exception)
            {
                subStr = "";
            }

            return subStr;
        }


        /// <summary>
        /// Copy all files from destination folder into destination folder,
        /// including subfolders
        /// </summary>
        /// <param name="SourcePath"></param>
        /// <param name="DestinationPath"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public string CopyAllFiles(string SourcePath, string DestinationPath, ref int status)
        {
            
            string returnValue;
            int slp = 200;
            status = -1; // reset to FAIL

            // check if directories exists
            if (Directory.Exists(SourcePath) == false)
            {
                return "Source Path doesn't exist";
            }
            if (Directory.Exists(DestinationPath) == false)
            {
                return "Destination Path doesn't exist";
            }


            try
            {
                // create all directories
                foreach (string dirPath in Directory.GetDirectories(SourcePath, "*", SearchOption.AllDirectories))
                {
                    Directory.CreateDirectory(dirPath.Replace(SourcePath, DestinationPath));
                    Thread.Sleep(slp);
                }
                // copy all files & Replaces any files with the same name
                foreach (string newPath in Directory.GetFiles(SourcePath, "*.*", SearchOption.AllDirectories))
                {
                    File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath), true);
                    Thread.Sleep(slp);
                }
                Thread.Sleep(slp);


                status = 0; 
                returnValue = "PASS";
            }
            catch (Exception ex)
            {
                status = -1;
                returnValue = ex.Message.ToString();
            }

            return returnValue;
        }


    }
}
