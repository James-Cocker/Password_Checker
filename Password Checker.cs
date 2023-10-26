using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordChecker
{
    public partial class Form1 : Form
    {
        bool Lowercase = false, Uppercase = false, Number = false;
        string MessageText;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            Lowercase = false; Uppercase = false; Number = false;
            MessageText = "";

            // Get text
            string Input = txtInput.Text;

            // Check length
            if(Input.Length >= 6 && Input.Length <= 12)
            {
                // Ensure there is a number, upper and lowercase character with flags
                foreach (Char Character in Input)
                {
                    if (char.IsNumber(Character))
                    {
                        Number = true;
                    }
                    if (Char.IsUpper(Character))
                    {
                        Uppercase = true;
                    }
                    if (Char.IsLower(Character))
                    {
                        Lowercase = true;
                    }
                }

                // Display the corresponding error if one or more of those attributes are missing
                if (!Number)
                {
                    MessageText += "Please include a number\n";
                }
                if (!Lowercase)
                {
                    MessageText += "Please include a lowercase\n";
                }
                if (!Uppercase)
                {
                    MessageText += "Please include an uppercase\n";
                }
                if (!Lowercase || !Uppercase || !Number)
                {
                    Console.WriteLine(Lowercase.ToString()+ Uppercase.ToString() + Number.ToString());
                    MessageBox.Show(MessageText, "CAUTION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Good password", "HELLO!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
            }
            else
            {
                MessageBox.Show("Please have your password between 6 and 12 characters long", "CAUTION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                txtInput.Text = "";
            }
        }
    }
}
