using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Easy.Monitor.Utility
{
    public static class StatTaskHelper
    {
        private static IList<Thread> threadList = new List<Thread>();

        public static void NewStatStart(Action action)
        {
            Thread t = new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    System.Diagnostics.Debug.Write("cccc");
                    Thread.Sleep(1000 * 60);
                    try
                    {
                        action.Invoke();
                    }
                    catch { }
                }
            }));
            t.Start();
            threadList.Add(t);
        }
    }
}