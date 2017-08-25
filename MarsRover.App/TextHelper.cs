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
        public static List<string> ReadTextFile(string fileLocation)
        {
            fileLocation = CorrectStringAsNeeded(fileLocation);
            var instructionLine = String.Empty;
            var returnLineList = new List<string>();

            System.IO.StreamReader instructionFile = new System.IO.StreamReader(fileLocation);

            while(!String.IsNullOrWhiteSpace(instructionLine = instructionFile.ReadLine()))
            {
                returnLineList.Add(instructionLine.Trim());
            }

            instructionFile.Close();
            return returnLineList;
        }

        public static string CorrectStringAsNeeded(string textLocationString)
        {
            var returnString = "";

            if (!string.IsNullOrEmpty(textLocationString))
            {
                returnString = textLocationString.Replace("\\", "/");
                returnString = returnString.Replace("\"", "");
            }

            return returnString;
        }
    }
}
