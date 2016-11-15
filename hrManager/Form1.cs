using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hrManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //initialize int variable to count login attempts.
        int loginAttempts = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            //hardcode username & password
            string userName = "Grant Chirpus";
            string password = "abcd1234";

            

            if(userName == textBox1.Text && password == textBox2.Text) //validates a successful login.
            {
                //opens main app window and closes login window.
                Main frm = new Main();
                this.Hide();
                frm.ShowDialog();
                this.Close();    
            }
            else
            {
                //pop-up message that prompts user to re-enter username and password.
                MessageBox.Show("Please enter valid Username and Password!");

                //increment number of unsuccessful login attempts and store value in 'loginAttempts'.
                loginAttempts++;

                //close the application after three unsuccessful login attempts.
                if(loginAttempts == 3)
                {
                    this.Close();
                }
            }
        }
    }
}
