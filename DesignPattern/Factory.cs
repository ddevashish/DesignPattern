using System;

namespace DesignPattern
{
    public class Factory
    {
        public ClassType getClassType(string className)
        {
            ClassType classType = null;
            if(className.ToUpper() == "STUDENT")
            {
                classType = new Student();
            }
            else
            {
                classType = new Teacher();
            }
            return classType;
        }
    }

    public interface ClassType
    {
        string getClassName();
    }

    public class Student: ClassType
    {
        public string getClassName()
        {
            return "Class: Student";
        }
    }

    public class Teacher: ClassType
    {
        public string getClassName()
        {
            return "Class: Teacher";
        }
    }

    // Client Application
    public class FactorTest
    {
        public void FactorTestDemo()
        {
            Factory factory = new Factory();
            Console.WriteLine(factory.getClassType("student").getClassName());
            Console.WriteLine(factory.getClassType("teacher").getClassName());
        }
    }
}
