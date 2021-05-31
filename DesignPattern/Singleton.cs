using System;
using System.Threading.Tasks;

namespace DesignPattern
{
    // Sealed restricts the inheritance
    public sealed class Singleton
    {
        private static Singleton _instance = null;

        private static int counter = 0;

        private static readonly object obj = new object();

        // Private constructor ensures that object is not instantiated other than with in the class itself
        private Singleton()
        {
            counter++;
            Console.WriteLine("Counter Value " + counter.ToString());
        }

        // public property is used to return only one instance of the class
        public static Singleton getInstance
        {
            get
            {
                if (_instance == null)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                }
                return _instance;
            }
        }

        public void print(string msg)
        {
            Console.WriteLine(msg);
        }
    }

    public class SingletonTest
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
            Singleton singleton1 = Singleton.getInstance;
            singleton1.print("FirstMessage");
        }

        private static void PrintSecondMessage()
        {
            Singleton singleton2 = Singleton.getInstance;
            singleton2.print("SecondMessage");
        }

    }
}
