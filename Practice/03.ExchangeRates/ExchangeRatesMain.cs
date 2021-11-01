using System;

namespace ExchangeRates
{
    class ExchangeMain
    {
        //Recursion
        //static void Main()
        //{
        //    double currency = double.Parse(Console.ReadLine());
        //    int n = int.Parse(Console.ReadLine());

        //    var rate12 = new double[n]; //rate from the first to the second currency
        //    var rate21 = new double[n]; //rate from the second to the first currency

        //    for (int i = 0; i < n; ++i)
        //    {
        //        var strs = Console.ReadLine().Split(' ');
        //        rate12[i] = double.Parse(strs[0]);
        //        rate21[i] = double.Parse(strs[1]);
        //    }

        //    Console.WriteLine("{0:F2}",Recursion(rate12, rate21, 0, currency, true));
        //}

        //static double Recursion(double[] rate12, double[] rate21, int day, double currency, bool isFirst)
        //{
        //    if (day == rate12.Length)
        //    {
        //        return isFirst ? currency : 0;
        //    }

        //    return Math.Max(
        //    Recursion(rate12, rate21, day + 1, currency, isFirst), //no exhange has taken place
        //    Recursion(rate12, rate21, day + 1, currency * (isFirst ? rate12[day] : rate21[day]), !isFirst));
        //}

        static void Main()
        {
            double maxCurrency1 = double.Parse(Console.ReadLine());
            double maxCurrency2 = 0;
            int n = int.Parse(Console.ReadLine());

            var steps1 = new string[n];
            var steps2 = new string[n];

            for (int i = 0; i < n; ++i)
            {
                var strs = Console.ReadLine().Split(' ');
                var rate12 = double.Parse(strs[0]);
                var rate21 = double.Parse(strs[1]);

                double currCurrency1;
                double currCurrency2;

                string[] currSteps1 = new string[n];
                string[] currSteps2 = new string[n];

                //The first currency
                double curr21 = maxCurrency1 * rate21;
                if (maxCurrency1 < curr21)
                {
                    currCurrency1 = curr21;
                    Array.Copy(steps2, currSteps1, n);
                    currSteps1[i] = "Exchange from currency 2 to 1";
                }
                else
                {
                    currCurrency1 = maxCurrency1;
                    Array.Copy(steps1, currSteps1, n);
                    currSteps1[i] = "Keep currency 1";
                }

                //The second currency
                double curr12 = maxCurrency1 * rate21;
                if (maxCurrency2 < curr12)
                {
                    currCurrency2 = curr12;
                    Array.Copy(steps1, currSteps2, n);
                    currSteps2[i] = "Exchange from currency 2 to 1";
                }
                else
                {
                    currCurrency2 = maxCurrency2;
                    Array.Copy(steps2, currSteps2, n);
                    currSteps2[i] = "Keep currency 2";
                }


                //double currCurrency1 = Math.Max(maxCurrency1, maxCurrency2 * rate21);
                //double currCurrency2 = Math.Max(maxCurrency2, maxCurrency1 * rate12);

                maxCurrency1 = currCurrency1;
                maxCurrency2 = currCurrency2;

                steps1 = currSteps1;
                steps2 = currSteps2;
            }

            Console.WriteLine("{0:F2}", maxCurrency1);
            Console.WriteLine(string.Join("/n", steps1));
        }
    }
}
