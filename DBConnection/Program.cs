using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnection
{
    //    They have a connection string
    //• They can be opened
    //• They can be closed
    //• They may have a timeout attribute(so if the connection could not be opened within the
    //timeout, an exception will be thrown).
    //Your job is to represent these commonalities in a base class called DbConnection.This class
    //should have two properties:
    //ConnectionString : string
    //Timeout : TimeSpan

    public abstract class DBConnect
    {
        public string ConnectionString { get; set; }
        public TimeSpan Timeout { get; set; }

        public DBConnect()
        {

        }

        public DBConnect(string connectionString)
        {
            if (String.IsNullOrWhiteSpace(connectionString))
            {
                Console.WriteLine("Error");
            }
            else
            {
                connectionString = ConnectionString;
                var comand = new DbCommand(connectionString);
               
            }
            
        }

        public abstract void Open();
        public abstract void Closed();
        

    }

    public class SQLConnection : DBConnect
    {
        public override void Open()
        {
            Console.WriteLine("SQL Connection Opened: ");
        }

        public override void Closed()
        {
            Console.WriteLine("SQL Connection Closed: ");
        }
    }

    public class OracleConnection : DBConnect
    {
        public override void Open()
        {
            Console.WriteLine("Oracle Connection Opened: ");
        }

        public override void Closed()
        {
            Console.WriteLine("Oracle Connection Closed: ");
        }
    }

    public class DbCommand
    {
        public DbCommand(string connection)
        {
            Console.WriteLine("DbCommand initialized: ");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
