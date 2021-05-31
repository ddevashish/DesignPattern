using System;

namespace DesignPattern.Implementation.Factory
{
    public class GetDataFactory
    {
        public DataSource getDataFrom(string dataSourceName)
        {
            DataSource dataSource = null;
            if (dataSourceName.ToUpper() == "CLOUD")
            {
                dataSource = new fromCloud();
            }
            else if (dataSourceName.ToUpper() == "LOCAL")
            {
                dataSource = new fromLocalData();
            }
            else
            {
                dataSource = new fromFileServer();
            }
            return dataSource;
        }
    }

    public interface DataSource
    {
        string getData();
    }

    public class fromCloud : DataSource
    {
        public string getData()
        {
            // Logic to retrieve data from cloud
            return "Data from Cloud";
        }
    }

    public class fromLocalData : DataSource
    {
        public string getData()
        {
            // Logic to retrieve data from cloud
            return "Data from Local";
        }
    }

    public class fromFileServer : DataSource
    {
        public string getData()
        {
            // Logic to retrieve data from cloud
            return "Data from FileServer";
        }
    }

    public class GetDataFactoryTest
    {
        public void GetDataFromFactory()
        {
            GetDataFactory getDataFactory = new GetDataFactory();
            Console.WriteLine(getDataFactory.getDataFrom("Cloud").getData());
            Console.WriteLine(getDataFactory.getDataFrom("Local").getData());
            Console.WriteLine(getDataFactory.getDataFrom("FileServer").getData());
        }
    }
}
