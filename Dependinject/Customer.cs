using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependinject
{
    //Data Layer
    public class SqlServer:IDatabase
    {
        public void Add()
        {
            Console.WriteLine("Add to SQL Server");
        }
    }
    public class Oracle:IDatabase
    {
        public void Add()
        {
            Console.WriteLine("Add to oracle server");
        }
    }
    //Interface
    public interface IDatabase
    {
        void Add();
        //void Remove();
    }
    //Programming logic
    class Customer
    {
        // SqlServer db = new SqlServer();
        IDatabase db;
        public Customer(IDatabase db)
        {
            this.db = db;
        }
        public bool Validate()
        {
            return true;
        }
        public void AddNewCustomer()
        {
            if (Validate())
            {
                db.Add();
            }
        }
    }
    //UI layer
    public class ClassUI
    {
        static void Main(string[] args)
        {
            IDatabase db = null;
            int dbType = Convert.ToInt32(Console.ReadLine());
            
                if (dbType == 1)
                {
                    db = new SqlServer();
                }
                else if (dbType == 2)
                {
                    db = new Oracle();
                }
            
            Customer customer = new Customer(db);
            customer.AddNewCustomer();
        }
    }

    }

    