using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    public interface IAbstractProductA
    {
        string GetProductDetails();
    }

    public interface IAbstractProductB
    {
        string GetProductDetails();
    }

    public interface IAbstractFactory
    {
        IAbstractProductA CreateProductA();

        IAbstractProductB CreateProductB();
    }

    public class ProductA1 : IAbstractProductA
    {
        public string GetProductDetails()
        {
            return "Product A1";
        }
    }

    public class ProductA2 : IAbstractProductA
    {
        public string GetProductDetails()
        {
            return "Product A2";
        }
    }

    public class ProductB1 : IAbstractProductB
    {
        public string GetProductDetails()
        {
            return "Product B1";
        }
    }

    public class ProductB2 : IAbstractProductB
    {
        public string GetProductDetails()
        {
            return "Product B2";
        }
    }

    public class ConcreteFactoryA : IAbstractFactory
    {
        public IAbstractProductA CreateProductA()
        {
            return new ProductA1();
        }

        public IAbstractProductB CreateProductB()
        {
            return new ProductB1();
        }
    }

    public class ConcreteFactoryB : IAbstractFactory
    {
        public IAbstractProductA CreateProductA()
        {
            return new ProductA2();
        }

        public IAbstractProductB CreateProductB()
        {
            return new ProductB2();
        }
    }

    public class Client
    {
        private IAbstractProductA _productA;
        private IAbstractProductB _productB;

        public Client(IAbstractFactory factory)
        {
            _productA = factory.CreateProductA();
            _productB = factory.CreateProductB();
        }

        public string GetProductADetails()
        {
            return _productA.GetProductDetails();
        }

        public string GetProductBDetails()
        {
            return _productB.GetProductDetails();
        }
    }

    public class AbstractFactorTest
    {
        public void AbstractFactorTestDemo()
        {
            IAbstractFactory abstractFactoryA = new ConcreteFactoryA();
            Client clientFactoryA = new Client(abstractFactoryA);

            Console.WriteLine("********* Product A **********");
            Console.WriteLine(clientFactoryA.GetProductADetails());
            Console.WriteLine(clientFactoryA.GetProductBDetails());


            IAbstractFactory abstractFactoryB = new ConcreteFactoryB();
            Client clientFactoryB = new Client(abstractFactoryB);

            Console.WriteLine("********* Product B **********");
            Console.WriteLine(clientFactoryB.GetProductADetails());
            Console.WriteLine(clientFactoryB.GetProductBDetails());
        }
    }


}
