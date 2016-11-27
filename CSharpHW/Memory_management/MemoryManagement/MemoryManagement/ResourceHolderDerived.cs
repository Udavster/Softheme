using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryManagement
{
    class ResourceHolderDerived:ResourceHolderBase
    {
        private bool _disposed;

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ResourceHolderDerived()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Derived destructor");
            Console.ResetColor();

            Dispose(false);
        }

        protected void Dispose(bool disposing)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Derived object disposed");
            Console.ResetColor();

            if (!_disposed)
            {
                if (disposing)
                {
                    Console.WriteLine("\tFreeing derived managed resources");
                }

                Console.WriteLine("\tFreeing derived unmanaged resources");
                _disposed = true;
            }

            base.Dispose(disposing);
        }
    }
}
