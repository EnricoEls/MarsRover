using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MarsRover.App
{
    public class TextHelper
    {
        public static List<string> ReadTextFile()
        {
            var instructionLine = String.Empty;
            var returnLineList = new List<string>();

            System.IO.StreamReader instructionFile = new System.IO.StreamReader("testFile1.txt");

            while(!String.IsNullOrWhiteSpace(instructionLine = instructionFile.ReadLine()))
            {
                returnLineList.Add(instructionLine.Trim());
            }

            instructionFile.Close();
            return returnLineList;
        }

        public static string RemoveAllSpaces(string inputString)
        {
            if (!string.IsNullOrEmpty(inputString))
            {
                return Regex.Replace(inputString, @"\s+", "");
            }
            return "";
        }
    }
}
