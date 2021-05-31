using System;
using System.Threading.Tasks;

namespace DesignPattern
{
    // Sealed restricts the inheritance
    public sealed class SingletonLazy
    {
        private static int counter = 0;

        private static readonly Lazy<SingletonLazy> _instance = new Lazy<SingletonLazy>(() => new SingletonLazy());

        // Private constructor ensures that object is not instantiated other than with in the class itself
        private SingletonLazy()
        {
            counter++;
            Console.WriteLine("Counter Value " + counter.ToString());
        }

        // public property is used to return only one instance of the class
        public static SingletonLazy getInstance
        {
            get
            {
                return _instance.Value;
            }
        }

        public void print(string msg)
        {
            Console.WriteLine(msg);
        }
    }

    public class SingletonLazyTest
    {
        public void Test()
        {
            Parallel.Invoke
            (
                () => PrintFirstMessage(),
                () => PrintSecondMessage()
            );
        }

        private static void PrintFirstMessage()
        {
            SingletonLazy singleton1 = SingletonLazy.getInstance;
            singleton1.print("FirstMessage");
        }

        private static void PrintSecondMessage()
        {
            SingletonLazy singleton2 = SingletonLazy.getInstance;
            singleton2.print("SecondMessage");
        }
    }
}
