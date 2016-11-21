using System;
using System.Threading;

namespace Compress1
{
    public class AnimateHelper
    {
        public static void AnimateProgress(Thread thread)
        {
            int i = 0;
            while (thread.IsAlive)
            {
                Thread.Sleep(150);
                if (!ZipHelpers.ErrorOccured)
                {
                    Console.Clear();
                }

                switch (i)
                {
                    case 0:
                        Console.Write("/");
                        break;
                    case 1:
                        Console.Write("-");
                        break;
                    case 2:
                        Console.Write(@"\");
                        break;
                    case 3:
                        Console.Write("-");
                        break;
                }

                i = (i + 1) % 4;
            }
        }
    }
}
