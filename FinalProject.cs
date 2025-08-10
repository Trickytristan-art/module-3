
using System;
using System.Collections.Generic;

namespace ContractorProject
{
    // Base class Contractor
    public class Contractor
    {
        // Attributes
        private string contractorName;
        private string contractorNumber;
        private DateTime contractorStartDate;

        // Constructor
        public Contractor(string name, string number, DateTime startDate)
        {
            contractorName = name;
            contractorNumber = number;
            contractorStartDate = startDate;
        }

        // Accessors (Getters)
        public string GetContractorName() => contractorName;
        public string GetContractorNumber() => contractorNumber;
        public DateTime GetContractorStartDate() => contractorStartDate;

        // Mutators (Setters)
        public void SetContractorName(string name) => contractorName = name;
        public void SetContractorNumber(string number) => contractorNumber = number;
        public void SetContractorStartDate(DateTime date) => contractorStartDate = date;
    }

    // Derived class Subcontractor
    public class Subcontractor : Contractor
    {
        private int shift; // 1 = day, 2 = night
        private double hourlyPayRate;

        // Constructor
        public Subcontractor(string name, string number, DateTime startDate, int shift, double hourlyRate)
            : base(name, number, startDate)
        {
            this.shift = shift;
            this.hourlyPayRate = hourlyRate;
        }

        // Accessors
        public int GetShift() => shift;
        public double GetHourlyPayRate() => hourlyPayRate;

        // Method to compute pay with shift differential
        public double ComputePay(double hoursWorked)
        {
            double pay = hourlyPayRate * hoursWorked;
            if (shift == 2) // night shift
            {
                pay += pay * 0.03; // 3% differential
            }
            return pay;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Subcontractor> subcontractors = new List<Subcontractor>();
            bool addMore = true;

            while (addMore)
            {
                Console.Write("Enter Contractor Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Contractor Number: ");
                string number = Console.ReadLine();

                Console.Write("Enter Contractor Start Date (yyyy-mm-dd): ");
                DateTime startDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Enter Shift (1 = Day, 2 = Night): ");
                int shift = int.Parse(Console.ReadLine());

                Console.Write("Enter Hourly Pay Rate: ");
                double rate = double.Parse(Console.ReadLine());

                Subcontractor sc = new Subcontractor(name, number, startDate, shift, rate);

                Console.Write("Enter Hours Worked: ");
                double hoursWorked = double.Parse(Console.ReadLine());

                double totalPay = sc.ComputePay(hoursWorked);
                Console.WriteLine($"Total pay for {sc.GetContractorName()} is: ${totalPay:F2}");

                subcontractors.Add(sc);

                Console.Write("Do you want to add another subcontractor? (y/n): ");
                string response = Console.ReadLine().ToLower();
                addMore = response == "y";
            }

            Console.WriteLine("\nAll subcontractors added:");
            foreach (var sc in subcontractors)
            {
                Console.WriteLine($"Name: {sc.GetContractorName()}, Number: {sc.GetContractorNumber()}, Start Date: {sc.GetContractorStartDate():yyyy-MM-dd}, Shift: {sc.GetShift()}, Rate: ${sc.GetHourlyPayRate():F2}");
            }
        }
    }
}
