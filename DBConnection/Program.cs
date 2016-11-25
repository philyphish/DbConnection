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

    public class DBConnect
    {
        //private static string _dbString;

        public string ConnectionString {get; set;}

        public TimeSpan Timeout { get; set; }


        

        public DBConnect()
        {
            Console.WriteLine("Enter your connection string: ");
            ConnectionString = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(ConnectionString))
            {
                Console.WriteLine("Error");
            }
            else
            {   
                Console.WriteLine("DBConnect has been initialized:");
               
            }
            
        }

        public virtual void Open()
        {

        }
        public virtual void Closed()
        {

        }
        

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
        public DbCommand()
        {
            var dbConnection = new DBConnect();
           

            dbConnection.ConnectionString = Console.ReadLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var dbComand = new DbCommand();

           
        }
    }
}
