using System;

namespace assignment_special_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            staff staff1 = new staff();
            Executive sam = (Executive)staff1.staffList[0];
            sam.awardbonus(500);
            Hourly diane = (Hourly)staff1.staffList[3];
            diane.addhours(40);

            staff1.Payday();
        }
    }

    }
    public class staff
    {
        public StaffMember[] staffList;
        public staff()
        {
            staffList = new StaffMember[6];
            staffList[0] = new Executive("Sam", "123 Main Line", "555-0469", "123-45-6789", 123, 2423.07);
            staffList[1] = new Employee("Salma", "456 Off Line", "555-0101", "987-65-4321", 1246.15);
            staffList[2] = new Employee("Ali", "789 Off Rocker", "555-0000", "010-20-3040", 1169.23);
            staffList[3] = new Hourly("Diane", "678 Fifth Ave.", "555-0690", "958-47-3625", 10, 0);
            staffList[4] = new Volunteer("Noor", "987 10th Ave.", "555-8374");
            staffList[5] = new Volunteer("Khalid", "321 maka st", "555-7282");
        }
        public void Payday()
        {
            for (int i = 0; i < staffList.Length; i++)
            {
                StaffMember employee = staffList[i];
                double payment = employee.pay();
                string employeeInfo = employee.Tostring();
                Console.WriteLine("Payment Details for Employee :" + (i + 1) + "\n" +(employeeInfo)+"\nPayment:" +(payment) +"Jd\n");
            }
        }
    }
        public abstract class StaffMember
        {
            protected string name;
            protected string address;
            protected string phone;
            public StaffMember(string name, string address, string phone)
            {
                this.name = name;
                this.address = address;
                this.phone = phone;
            }
            public virtual string Tostring() { return "Name :" + name + "\nAddress :" + address + "\nPhone Number :" + phone + "\nThe Payment is :" + pay(); }
            public abstract double pay();
        }
        public class Employee : StaffMember
        {
            protected string socialSecurityNumber;
            protected double payRate;
            public Employee(string name, string address, string phone, string Sos, double payRate) : base(name, address, phone)
            {
                this.name = name;
                this.address = address;
                this.phone = phone;
                this.socialSecurityNumber = Sos;
                this.payRate = payRate;
            }
            public override double pay() { return payRate; }
            public override string ToString()
            {
                return base.ToString();
            }
        }
        public class Volunteer : StaffMember
        {
            public Volunteer(string name, string address, string phone) : base(name, address, phone)
            {
                this.name = name;
                this.address = address;
                this.phone = phone;
            }
            public override double pay()
            {
                return 0;
            }
        }
        public class Hourly : Employee
        {
            private int hoursWorked;
            public Hourly(string name, string address, string phone, string Sos, int payRate, int hoursWorked) : base(name, address, phone, Sos, payRate)
            {
                this.hoursWorked = hoursWorked;
            }
            public int addhours(int morehours) { hoursWorked += morehours; return hoursWorked; }
            public override double pay()
            {
                return base.pay() * hoursWorked; ;
            }
            public override string Tostring()
            {
                return base.Tostring() + "\nHours Worked :" + hoursWorked;
            }
        }
        public class Executive : Employee
        {
            private double bonus;
            public Executive(string name, string address, string phone, string Sos, int payRate, double bonus) : base(name, address, phone, Sos, payRate)
            {
                this.bonus = bonus;
            }
            public double awardbonus(double execBonus) { bonus += execBonus; return bonus; }
            public override double pay()
            {
                return base.pay() + bonus;
            }
        }
