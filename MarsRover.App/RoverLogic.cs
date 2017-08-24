using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.App
{
    public class RoverLogic
    {
        public RoverLogic(List<string> listOfinstructions)
        {
            var girdSplit = listOfinstructions[0].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            XMax = Int32.Parse(girdSplit[0]);
            YMax = Int32.Parse(girdSplit[1]);

            var locationSplit = listOfinstructions[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            X = Int32.Parse(locationSplit[0]);
            Y = Int32.Parse(locationSplit[1]);
            D = locationSplit[2];

            Instructions = listOfinstructions[2].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public int XMax { get; internal set; }
        public int YMax { get; internal set; }
        public int X { get; internal set; }
        public int Y { get; internal set; }
        public string D { get; internal set; }
        public List<string> Instructions { get; internal set; }

        public void ExecuteMovementCommand(string instruction)
        {
            if(instruction == "M")
            {
                switch (D)
                {
                    case "N":
                        {
                            Y++;
                            break;
                        }
                    case "E":
                        {
                            X++;
                            break;
                        }
                    case "S":
                        {
                            Y--;
                            break;
                        }
                    case "W":
                        {
                            X--;
                            break;
                        }
                }
            }

            if (instruction == "L")
            {
                switch (D)
                {
                    case "N":
                        {
                            D = "W";
                            break;
                        }
                    case "E":
                        {
                            D = "S";
                            break;
                        }
                    case "S":
                        {
                            D = "O";
                            break;
                        }
                    case "W":
                        {
                            D = "N";
                            break;
                        }
                }
            }

            if (instruction == "R")
            {
                switch (D)
                {
                    case "N":
                        {
                            D = "E";
                            break;
                        }
                    case "E":
                        {
                            D = "S";
                            break;
                        }
                    case "S":
                        {
                            D = "W";
                            break;
                        }
                    case "W":
                        {
                            D = "N";
                            break;
                        }
                }
            }
        }

        public string Execute()
        {
            foreach(var instruction in Instructions)
            {
                ExecuteMovementCommand(instruction);
            }

            return $"{X} {Y} {D}";
        }
    }
}
