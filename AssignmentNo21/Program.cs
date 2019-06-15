using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AssignmentNo21
{
    class Program
    {
        static Task t1;
        static Task t2;
        static void Main(string[] args)
        {
            int loopConditionCount = 10;
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            t1 = new Task(() =>
            {
                int max = 0;
                for (int i = 1; i <= loopConditionCount; i++)
                {
                    if (token.IsCancellationRequested)
                        break;
                    else
                    {
                        Console.WriteLine($"Task One run number {i} ");
                        max = i;
                    }
                }
                Console.WriteLine();
                if (max == loopConditionCount)
                    Console.WriteLine("TASK ONE IS COMPLETE!");
                else
                {
                    Console.WriteLine("Task One is cancelled");
                    Console.WriteLine("Task One Maximum " + max);
                }
                cancellationTokenSource.Cancel();
            });

            t2 = new Task(() =>
            {
                int max = 0;
                for (int i = 1; i <= loopConditionCount; i++)
                {
                    if (token.IsCancellationRequested)
                        break;
                    else
                    {
                        Console.WriteLine($"Task Two run number {i} ");
                        max = i;
                    }
                }
                Console.WriteLine();
                if (max == loopConditionCount)
                    Console.WriteLine("TASK TWO IS COMPLETE!");
                else
                {
                    Console.WriteLine("Task Two is cancelled");
                    Console.WriteLine("Task Two Maximum " + max);
                }
                cancellationTokenSource.Cancel();
            });

            t1.Start();
            t2.Start();

            Task.WaitAll(t1, t2);
        }
    }
}
