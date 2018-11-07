using BillSplitApp.Core.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillSplitApp.Core;

namespace BillSplitApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the file name, for example: " + "test.txt");
            var fileName = Console.ReadLine();
            if (string.IsNullOrEmpty(fileName))
            {
                Console.WriteLine("Please enter a valid file name, for example: " + "test.txt");
            }

            //get File Path
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), @"InputOutput\" + fileName);

            //Process if file exist
            if (File.Exists(filePath))
            {
                var readLines = File.ReadAllLines(filePath);
                if (readLines != null)
                {   //Process input
                    ICalculator processInput = new ProcessInput();
                    var trips = processInput.Calculate(readLines);
                    //Process Output
                    ILineWriter processOutput = new ProcessOutput(fileName);
                    processOutput.WriteOutput(trips);
                }
                else
                {
                    Console.WriteLine("No records presents");
                }
            }
            else
            {
                Console.WriteLine("No such file presents, please enter a valid file name");
            }
        }
    }
}
