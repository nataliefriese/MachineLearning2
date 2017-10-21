using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineLearning2
{
    class Abalone
    {
        public double[] Values = new double[8];
        public int Rings;
        public int Prediction;

       public Abalone(String input)
        {
            String[] help = input.Split(' ');
            for (int i = 0; i < Values.Length; i++)
            {
                Values[i] = Convert.ToDouble(help[i]);
            }
            
            Rings = Convert.ToInt32(help[8].Split(',')[0]);
        }

        public Abalone GetNearest(List<Abalone> data, List<Abalone> nearest)
        {
            double smallestDistance = double.PositiveInfinity;
            Abalone Nearest = null;
            foreach (var aba in data)
            {
                bool found = false;

                foreach (var aba2 in nearest)
                {
                    if (aba.Equals(aba2))
                    {
                        found = true;
                    }
                }
                if (aba.Equals(this))
                {
                    found = true;
                }
                if (!found)
                {
                    double distance = 0;
                    if (Values[0] != aba.Values[0])
                    {
                        distance += 1;
                    }
                    for (int i = 1; i < Values.Length; i++)
                    {
                        distance += (Values[i] - aba.Values[i]) * (Values[i] - aba.Values[i]) * 100;
                    }


                    if (Math.Sqrt(distance) < smallestDistance)
                    {
                        smallestDistance = Math.Sqrt(distance);
                        Nearest = aba;
                    }
                }
            }

            return Nearest;
        }

        public void SetPrediction(List<Abalone> nearest)
        {
            int pred = 0;
            foreach (var aba in nearest)
            {
                pred += aba.Rings;
            }
            Prediction= (int) Math.Round((double)(pred / nearest.Count), 0);
        }
    }
}
