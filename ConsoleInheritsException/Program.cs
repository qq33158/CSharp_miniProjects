using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInheritsException
{
    class SalaryException : Exception
    {
        public override String ToString()
        {
            return "\n 發生Salary例外類別";
        }
        public override String Message
        {
            get
            {
                return "\n 薪水設定不能為負數或零";
            }
        }
        public void ShowMsg()
        {
            Console.WriteLine("\n 設定員工薪水時請小心!!!");
        }
    }
    class Empolyee
    {
        private string _name;
        private int _salary;
        public Empolyee(string name)
        {
            _name = name;
        }
        public int Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine($"\n 員工{_name}設定薪水{value}失敗");
                    throw new SalaryException();
                }
                else 
                {
                    _salary = value;
                }
            }
        }
        public void ShowSalary()
        {
            Console.WriteLine($"\n 員工{_name}的薪水{Salary}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Empolyee tom = new Empolyee("湯姆");
                tom.Salary = 50000;
                tom.ShowSalary();
                Console.WriteLine("===============================");
                Empolyee peter = new Empolyee("彼得");
                peter.Salary = -100000;
                peter.ShowSalary();
            }
            catch(SalaryException ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.Message);
                ex.ShowMsg();
            }
            Console.Read();
        }
    }
}
