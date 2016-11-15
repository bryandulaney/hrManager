using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrManager
{
    class Employee
    {
        //properties of the class
        private static int ID = 0;
        private int id = 0;
        private string name;
        private string dateOfBirth;
        private string maritalStatus;
        private float salary;
        private string department;
        private string occupation;
        private string address;

        //constructor 
        public Employee(string name, string dateOfBirth, string maritalStatus, float salary, string department, string occupation, string address)
        {
            ID++;
            this.id = ID;
            this.name = name;
            this.dateOfBirth = dateOfBirth;
            this.maritalStatus = maritalStatus;
            this.salary = salary;
            this.department = department;
            this.occupation = occupation;
            this.address = address;
        }

        //getters and setters for each property
        public int Id
        {
            get
            {
                return id;
            }
           
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }
            set
            {
                dateOfBirth = value;
            }
        }

        public string MaritalStatus
        {
            get
            {
                return maritalStatus;
            }
            set
            {
                maritalStatus = value;
            }
        }

        public float Salary
        {
            get
            {
                return salary;
            }
            set
            {
               salary = value;
            }
        }

        public string Department
        {
            get
            {
                return department;
            }
            set
            {
                department = value;
            }
        }

        public string Occupation
        {
            get
            {
                return occupation;
            }
            set
            {
                occupation = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
    }
}
