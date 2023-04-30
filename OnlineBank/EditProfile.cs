﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace OnlineBank
{
    public partial class EditProfile : Form
    {
        User user = new User();
        
        public EditProfile()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && textBox3.Text != string.Empty && textBox4.Text != string.Empty && textBox5.Text != string.Empty && textBox6.Text != string.Empty && textBox7.Text != string.Empty)
                {
                    if (textBox6.Text == textBox7.Text)
                    {
                        string tempEmail = user.Email;
                        user.Email = textBox4.Text;
                        Console.WriteLine($"01    {user.Email}");
                        if (user.PreviousAccountCheck(user) == false || user.Email == tempEmail)
                        {
                            user.FirstName = textBox1.Text;
                            user.LastName = textBox2.Text;
                            user.DateOfBirth = DateTime.ParseExact(textBox3.Text, "yyyy-mm-dd", null);
                            user.Password = textBox5.Text;
                            user.Password = textBox6.Text;

                            if (user.UpdateUser(user))
                            {
                                LogInPage.uEmail = user.Email;
                                Console.WriteLine($"02    {user.Email}");
                                MessageBox.Show("Update Complete");
                                UserHomePage userHomePage = new UserHomePage();
                                userHomePage.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Something Wrong!\nTry again!");
                            }
                        }
                        else
                        {
                            user.Email = tempEmail;
                            MessageBox.Show("User email already in use!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Passwords are not same!");
                    }
                }
                else
                {
                    MessageBox.Show("Fill all fields!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Invalid data format!");
            }
        }

        private void EditProfile_Load(object sender, EventArgs e)
        { 
            user = user.GetUser(LogInPage.uEmail);
            textBox1.Text = user.FirstName;
            textBox2.Text = user.LastName;
            textBox3.Text = user.DateOfBirth.ToString("yyyy-MM-dd");
            textBox4.Text = user.Email;
            textBox5.Text = user.Address;
            textBox6.Text = user.Password;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = user.FirstName;
            textBox2.Text = user.LastName;
            textBox3.Text = user.DateOfBirth.ToString("yyyy-MM-dd");
            textBox4.Text = user.Email;
            textBox5.Text = user.Address;
            textBox6.Text = user.Password;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserHomePage userHomePage = new UserHomePage();
            userHomePage.Show();
            this.Hide();
        }
    }
}