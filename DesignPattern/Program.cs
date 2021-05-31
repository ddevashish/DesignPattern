using DesignPattern.Implementation.AbstractFactory;
using DesignPattern.Implementation.Factory;
using DesignPattern.Implementation.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //SingletonTest singletonTest = new SingletonTest();
            //singletonTest.Test();

            //SingletonEagerTest singletonEagerTest = new SingletonEagerTest();
            //singletonEagerTest.Test();

            //SingletonLazyTest singletonLazyTest = new SingletonLazyTest();
            //singletonLazyTest.Test();

            //LogTest logTest = new LogTest();
            //logTest.LogMessageTest("Demo Log");

            //ExceptionLogTest exceptionLogTest = new ExceptionLogTest();
            //exceptionLogTest.LogExceptionMessageTest("Demo Exception Log");

            //SQLConnectionTest sqlConnectionTest = new SQLConnectionTest();
            //sqlConnectionTest.SQLConnectionTestDemo();

            //FactorTest factorTest = new FactorTest();
            //factorTest.FactorTestDemo();

            //GetDataFactoryTest getDataFactoryTest = new GetDataFactoryTest();
            //getDataFactoryTest.GetDataFromFactory();

            //MobileTest mobileTest = new MobileTest();
            //mobileTest.MobileTestDemo();

            AbstractFactorTest abstractFactorTest = new AbstractFactorTest();
            abstractFactorTest.AbstractFactorTestDemo();

            Console.ReadLine();
        }
    }
}
