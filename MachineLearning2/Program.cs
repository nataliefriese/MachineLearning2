using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineLearning2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines =
                System.IO.File.ReadAllLines(
                    @"C:\Users\Natalie\source\repos\MachineLearning2\MachineLearning2\abalone.txt");

            List<Abalone> schneckschens = new List<Abalone>();
            foreach (var line in lines)
            {
                schneckschens.Add(new Abalone(line));
            }

            for (int k = 1; k <= 10; k++)
            {
                
                foreach (var aba in schneckschens)
                {
                    List<Abalone> nearest = new List<Abalone>();
                    for (int i = 0; i < k; i++)
                    {
                        nearest.Add(aba.GetNearest(schneckschens, nearest));
                    }
                    aba.SetPrediction(nearest);
                }


                //get Errors
                int absoluteErrors = 0;

                foreach (var gary in schneckschens)
                {
                    if (gary.Prediction < gary.Rings)
                    {
                        absoluteErrors += gary.Rings - gary.Prediction;
                    }
                    else
                    {
                        absoluteErrors += gary.Prediction - gary.Rings;
                    }
                }
                double avg = absoluteErrors*1.0 / schneckschens.Count;
                Console.WriteLine("k = " + k + " Error rate: " + avg);
                
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }



    }
}
