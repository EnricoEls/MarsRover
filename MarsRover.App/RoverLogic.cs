using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Int32;

namespace MarsRover.App
{
    public class RoverLogic
    {
        public RoverLogic(List<string> listOfinstructions)
        {

            var girdSplit =
                listOfinstructions[0].Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            XMax = Parse(girdSplit[0]);
            YMax = Parse(girdSplit[1]);

            var locationSplit =
                listOfinstructions[1].Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            X = Parse(locationSplit[0]);
            Y = Parse(locationSplit[1]);
            D = locationSplit[2];

            Instructions = listOfinstructions[2].ToCharArray().ToList();
            UnknownInstructions = new List<string>();

        }

        public int XMax { get; internal set; }
        public int YMax { get; internal set; }
        public int X { get; internal set; }
        public int Y { get; internal set; }
        public string D { get; internal set; }
        public List<char> Instructions { get; internal set; }
        public List<string> UnknownInstructions { get; internal set; } 

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
            else if (instruction == "L")
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
                            D = "N";
                            break;
                        }
                    case "S":
                        {
                            D = "O";
                            break;
                        }
                    case "W":
                        {
                            D = "S";
                            break;
                        }
                }
            }
            else if (instruction == "R")
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
            else
            {
                UnknownInstructions.Add(instruction);
            }
        }

        public string Execute()
        {
            if (!IsInBounds())
            {
                return $"Rover moved out of grid at point 8 8 \n End position {X} {Y} {D}";
            }

            foreach (var instruction in Instructions)
            {
                ExecuteMovementCommand(instruction.ToString());

                if (!IsInBounds())
                {
                    return $"Rover moved out of grid at point 8 8 \n End position {X} {Y} {D}";
                }
            }

            return $"{X} {Y} {D}";
        }

        public bool IsInBounds()
        {
            var xInBounds = X >= 0 && X <= XMax;
            var yInBounds = Y >= 0 && Y <= YMax;

            return xInBounds && yInBounds;
        }
    }
}
