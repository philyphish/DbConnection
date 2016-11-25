using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnection
{
  
    public class DBConnect
    {

        public string ConnectionString {get; set;}
        public bool Status { get; set; }
        public TimeSpan Timeout { get; set; }

        public DBConnect()
        {
            Console.WriteLine("Enter your connection string: ");
            ConnectionString = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(ConnectionString))
            {
                Console.WriteLine("Error");
                Status = false;
            }
            else
            {   
                Console.WriteLine("Connected to the Database");
                Status = true;
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
            Console.WriteLine("SQL connection opened");
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
            
        }

        public DbCommand(string Tsql)
        {
            
            
            if (string.IsNullOrWhiteSpace(Tsql))
                Console.WriteLine("Failed to initialize DbCommand. T-SQL not sent.");
            else
                Console.WriteLine("Sending T-SQL comand");
        }

        public void Execute()
        {
            //varnection = new DBConnect();
            var sqlConnection = new SQLConnection();

            if (sqlConnection.Status)
            {
                sqlConnection.Open();
                //run the comand
                Console.WriteLine("Enter your comand.");
                var cmd = Console.ReadLine();
                //this is causing the enter your string to execute twice.
                var dbComand = new DbCommand(cmd);
                //close the connection
                sqlConnection.Closed();
            }
            else
            {
                Console.WriteLine("An error occured. ");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var cmd = new DbCommand();
            cmd.Execute();
            
        }
    }
}
