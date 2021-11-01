using System;
using System.Collections.Generic;
using System.Linq;

namespace OfficeSpace
{
    class OfficeSpaceStartUp
    {        
        static bool hasCircularTask = false;       
        static int[] answers = new int[50];
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var minutes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            List<int>[] dependencies = new List<int>[n];

            for (var i = 0; i < n; i++)
            {
                dependencies[i] = Console.ReadLine().Split(' ').Select(x => int.Parse(x) - 1).ToList();
            }

            for (int i = 0; i < n; i++)
            {
                answers[i] = CalculateMinTime(i, minutes, dependencies);

                if (hasCircularTask)
                {
                    Console.WriteLine(-1);
                    return;
                }
            }
           
            Console.WriteLine(answers.Max());
        }

        //Recursion
        static int CalculateMinTime(int taskId, int[] minutes, List<int>[] dependencies)
        {
            if (answers[taskId] < 0)
            {
                hasCircularTask = true;
            }

            if (answers[taskId] != 0)
            {
                return answers[taskId];
            }                      

            //Bottom
            if (dependencies[taskId].Count == 1 && dependencies[taskId][0] == -1)
            {
                return minutes[taskId];
            }

            answers[taskId] = -1;

            var maxDependencyTime = 0;

            foreach (int dependencyId in dependencies[taskId])
            {               

                var dependencyTime = CalculateMinTime(dependencyId, minutes, dependencies);

                maxDependencyTime = Math.Max(dependencyTime, maxDependencyTime);
            }

            answers[taskId] =  minutes[taskId] + maxDependencyTime;

            return answers[taskId];
        }
    }
}
