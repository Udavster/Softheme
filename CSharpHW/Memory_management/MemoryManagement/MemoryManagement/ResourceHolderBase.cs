using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryManagement
{
    class ResourceHolderBase:IDisposable
    {
        private bool _disposed;

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        ~ResourceHolderBase()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Base destructor");
            Console.ResetColor();

            Dispose(false);
        }

        protected void Dispose(bool disposing)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Base object disposed");
            Console.ResetColor();

            if (!_disposed)
            {
                if (disposing)
                {
                    Console.WriteLine("\tFreeing base managed resources");
                }

                Console.WriteLine("\tFreeing base unmanaged resources");
                _disposed = true;
            }

        }

    }
}
