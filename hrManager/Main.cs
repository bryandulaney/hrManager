using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace hrManager
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        //register button on_click event in first tab
        private void button1_Click(object sender, EventArgs e)
        {
            //very simple form validation to ensure all fields are populated with data
            if (txtName.Text == string.Empty || txtSalary.Text == string.Empty || txtAddress.Text == string.Empty || cboDepartment.SelectedIndex == -1 || cboMaritalStatus.SelectedIndex == -1 || cboOccupation.SelectedIndex == -1)
            {
                MessageBox.Show("All fields required\n" + "Please fill in the empty field(s).");
                return;
            } 

            //create text file to write to
            string path = "employees.txt";

            //create list of Employee objects
            List<Employee> employees = new List<Employee>();

            //create new instance of Employee object, populate properties with data from control fields
            Employee emp = new Employee(txtName.Text, dtpDateOfBirth.ToString(), cboMaritalStatus.Text, float.Parse(txtSalary.Text), cboDepartment.Text, cboOccupation.Text, txtAddress.Text);

            //add new instance of Employee to list of employees
            employees.Add(emp);
            
            //converted 'salary' and 'id' fields to strings so i could write them to text file.
            string salary = emp.Salary.ToString();
            string id = emp.Id.ToString();

            //Instantiate a StringBuilder object for use in writing strings to the text file.
            StringBuilder str = new StringBuilder();

            /*Utilize the Append method of the StringBuilder class to populate StringBuilder object
             * with data from control fields 
             */
            str.Append(id + "," + emp.Name + "," + emp.DateOfBirth + "," + emp.MaritalStatus + "," + salary + "," + emp.Department + "," + emp.Occupation + "," + emp.Address);
            
            /*Utilize C# 6 IO.File method AppendAllText to populate text file (path) with data stored in StringBuilder object (str) after converting it to a string.
             */   
            File.AppendAllText(path, str.ToString());
            

            //displays message to user informing them that a new employee record has been created.
            MessageBox.Show("New employee registered.");
        }

        // KeyPress event that only allows floating point values to be entered into the 'txtSalary' field.
        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            //create a char variable to store keypress data
            char ch = e.KeyChar;

            // conditional test to ensure that char code 46 ('.') is only entered once.
            if(ch == 46 && txtSalary.Text.IndexOf('.') != -1)
            {

                /*the 'Handled' method of the KeyPressEvent class prevents invalid data from being entered *into the form. 
                 */
                e.Handled = true;
                return;
            }

            /*conditional test to ensure that only numbers, backspaces (char code 8), and ('.') can be *entered
             */
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        //Search button on_click event in second tab
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //create a counter that will start reading text file from the first line
            int counter = 0;

            //create a string variable to store data read from text file.
            string line;

            //Instantiate new StreamReader object to read from 'employees.txt' file. 
            StreamReader file = new StreamReader("employees.txt");

            //create a while-loop to continue reading from 'employees.txt' while lines are not null
            while((line = file.ReadLine()) != null)
            {
                /*add lines from 'employees.txt' file to display in listBox, and incremnt to next line
                 * using the counter
                 */
                listBox1.Items.Add(line);
                counter++;
            }

            //call the GetRecords( ) method
            GetRecords();
        }


        /*create GetRecords( ) method to create a list storing the values from the text file as a 
         * string array
         */
        public List<string[]> GetRecords()
        {
            //Instantiate StreamReader object 'rd' to read from 'employees.txt'
            StreamReader rd = new StreamReader("employees.txt");

            //Writes each line from 'employees.txt' file to console.
            Console.WriteLine(rd.ReadToEnd());

            /*Instantiate a string array 'records' with data from the StreamReader object and splits each * array onto a new line. 
             */ 
            string[] records = rd.ReadToEnd().Split('\n');

            //Instantiate a new List of string array objects called 'EmployeeList'
            List<string[]> EmployeeList = new List<string[]>();

            /*Loop through each string in the string array 'records' and adds that string to the *EmployeeList 
             */ 
            foreach(string record in records)
            {
                /*splits each string using the delimiter ',' into individual string elements to be stored *int EmployeeList 
                 */ 
                EmployeeList.Add(record.Split(','));
            }
            //returns the data type of the method. 
            return EmployeeList;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            /* code here will likely utilize TextChanged events to rewrite strings stored in the 
             * text file with new data input by the user
             */
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            /* code here will remove entire lines or records from the 'employees' list of Employee objects
             * as well as remove the corrisponding line from the text file. 
             */
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            /*the code written in the first tab for registering a new employee should be moved here
             * to write list of employees to a csv file. 
             */
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // code here will call method to engage microsoft's printer to print the csv file.
        }

        private void btnPrintPrev_Click(object sender, EventArgs e)
        {
            // code here will show the print preview form of microsoft's printer.
        }
    }
}
