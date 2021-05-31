using System;
using System.Threading.Tasks;

namespace DesignPattern
{
    // Sealed restricts the inheritance
    public sealed class SingletonEager
    {
        private static int counter = 0;

        private static readonly SingletonEager _instance = new SingletonEager();

        // Private constructor ensures that object is not instantiated other than with in the class itself
        private SingletonEager()
        {
            counter++;
            Console.WriteLine("Counter Value " + counter.ToString());
        }

        // public property is used to return only one instance of the class
        public static SingletonEager getInstance
        {
            get
            {
                return _instance;
            }
        }

        public void print(string msg)
        {
            Console.WriteLine(msg);
        }
    }

    public class SingletonEagerTest
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
            SingletonEager singleton1 = SingletonEager.getInstance;
            singleton1.print("FirstMessage");
        }

        private static void PrintSecondMessage()
        {
            SingletonEager singleton2 = SingletonEager.getInstance;
            singleton2.print("SecondMessage");
        }
    }
}
