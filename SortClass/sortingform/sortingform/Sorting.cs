using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SortClass;

namespace SortingForm
{
    public partial class Sorting : Form
    {
        public Sorting()
        {
            InitializeComponent();
            textBox1.KeyDown+=new KeyEventHandler(textBox1_KeyDown);
            textBox1.KeyPress+=new KeyPressEventHandler(textBox1_KeyPress);
        }

        // Boolean flag used to determine when a character other than a number or comma is entered.
        private bool InvalidInput=false;

        // Handle the KeyDown event to determine the type of character entered into the control.
        private void textBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            InvalidInput = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode != Keys.Oemcomma)
                {
                    if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                    {
                        if (e.KeyCode != Keys.Back)
                            InvalidInput = true;
                    }
                }
            }
        }

        // This event occurs after the KeyDown event and can be used to prevent
        // characters from entering the control.
        private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (InvalidInput == true)
            {
                e.Handled = true;
            }
        }

        //QuickSort
        private void button1_Click(object sender, EventArgs e)
        {
            List<int> input = new List<int>();
            List<int> output = new List<int>();
            string[] strings = textBox1.Text.Split(',');
            textBox2.Text = "";
            foreach (string s in strings)
            {
                int i;
                if (int.TryParse(s.Trim(), out i))
                {
                    input.Add(i);
                }
            }
            Sort sc = new Sort();
            output = sc.QuickSort(input);
            foreach (int i in output)
            {
                if (textBox2.Text != "")
                {
                    textBox2.Text = textBox2.Text + ", " + i.ToString();
                }
                else
                    textBox2.Text = i.ToString();

            }
        }
        //InsertionSort
        private void button6_Click(object sender, EventArgs e)
        {
            List<int> input = new List<int>();
            List<int> output = new List<int>();
            string[] strings = textBox1.Text.Split(',');
            textBox2.Text = "";
            foreach (string s in strings)
            {
                int i;
                if (int.TryParse(s.Trim(), out i))
                {
                    input.Add(i);
                }
            }
            Sort sc = new Sort();
            output = sc.InsertionSort(input);
            foreach (int i in output)
            {
                if (textBox2.Text != "")
                {
                    textBox2.Text = textBox2.Text + ", " + i.ToString();
                }
                else
                    textBox2.Text = i.ToString();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<int> input = new List<int>();
            List<int> output = new List<int>();
            string[] strings = textBox1.Text.Split(',');
            textBox2.Text = "";
            foreach (string s in strings)
            {
                int i;
                if (int.TryParse(s.Trim(), out i))
                {
                    input.Add(i);
                }
            }
            Sort sc = new Sort();
            output = sc.SelectionSort(input);
            foreach (int i in output)
            {
                if (textBox2.Text != "")
                {
                    textBox2.Text = textBox2.Text + ", " + i.ToString();
                }
                else
                    textBox2.Text = i.ToString();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<int> input = new List<int>();
            List<int> output = new List<int>();
            string[] strings = textBox1.Text.Split(',');
            textBox2.Text = "";
            foreach (string s in strings)
            {
                int i;
                if (int.TryParse(s.Trim(), out i))
                {
                    input.Add(i);
                }
            }
            Sort sc = new Sort();
            output = sc.BubbleSort(input);
            foreach (int i in output)
            {
                if (textBox2.Text != "")
                {
                    textBox2.Text = textBox2.Text + ", " + i.ToString();
                }
                else
                    textBox2.Text = i.ToString();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<int> input = new List<int>();
            List<int> output = new List<int>();
            string[] strings = textBox1.Text.Split(',');
            textBox2.Text = "";
            foreach (string s in strings)
            {
                int i;
                if (int.TryParse(s.Trim(), out i))
                {
                    input.Add(i);
                }
            }
            Sort sc = new Sort();
            output = sc.MergeSort(input);
            foreach (int i in output)
            {
                if (textBox2.Text != "")
                {
                    textBox2.Text = textBox2.Text + ", " + i.ToString();
                }
                else
                    textBox2.Text = i.ToString();

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<int> input = new List<int>();
            List<int> output = new List<int>();
            string[] strings = textBox1.Text.Split(',');
            textBox2.Text = "";
            foreach (string s in strings)
            {
                int i;
                if (int.TryParse(s.Trim(), out i))
                {
                    input.Add(i);
                }
            }
            Sort sc = new Sort();
            output = sc.HeapSort(input);
            foreach (int i in output)
            {
                if (textBox2.Text != "")
                {
                    textBox2.Text = textBox2.Text + ", " + i.ToString();
                }
                else
                    textBox2.Text = i.ToString();

            }

        }
    }
}
