using System;
using System.Collections.Generic;
using System.Text;

namespace WpfAppDemoCRUD.Data
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Job_Title { get; set; }
        public double Salary { get; set; }
        public int Contract_Period { get; set; }
    }
}
