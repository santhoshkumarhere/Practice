using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace Practice.ThreadConcepts
{
    class ThreadExample
    {
        public static void ThreadProc()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"ThreadProc: {i}");
                Thread.Sleep(100);
            }
        }

        public static void Main()
        {
            Console.WriteLine("Main thread: Start a Second thread.");
            Thread t = new Thread(new ThreadStart(ThreadProc));

            t.Start();
            //Thread.Sleep(100);

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main thread: Do some work.");
                Thread.Sleep(100);
            }
            Console.WriteLine("Main thread: Call Join(), to wait until ThreadProc ends.");
            t.Join();
            Console.WriteLine("Main thread: ThreadProc.Join has returned.  Press Enter to end program.");
            Console.ReadLine();
        }
    }
}
