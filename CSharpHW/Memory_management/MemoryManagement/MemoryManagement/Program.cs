using System;

namespace MemoryManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowDispose();
            ShowDestructor();

            Console.ReadLine();
        }

        public static void ShowDispose()
        {
            ResourceHolderDerived resourceHolderDerived = new ResourceHolderDerived();
            ResourceHolderBase resourceHolderBase = new ResourceHolderBase();

            Console.WriteLine("Disposing derived:");
            resourceHolderDerived.Dispose();

            Console.WriteLine("\nDisposing base:");
            resourceHolderBase.Dispose();

            Console.WriteLine("\nDisposing derived one more time:");
            resourceHolderDerived.Dispose();
            Console.WriteLine("->No exception here\n");
        }

        public static void ShowDestructor()
        {
            ResourceHolderDerived resourceHolderDerived = new ResourceHolderDerived();
            ResourceHolderBase resourceHolderBase = new ResourceHolderBase();

            resourceHolderBase = null;
            resourceHolderDerived = null;

            Console.WriteLine("\nShowing destructors work: ");
            GC.Collect(0, GCCollectionMode.Forced, true);
        }

    }
}