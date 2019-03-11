using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    /// <summary>
    /// A word search program
    /// </summary
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Finds other words that end in the requested string
        /// </summary>
        private void button1_Click(object sender, EventArgs e)//Rhyme
        {
            String[] words = Properties.Resources.words.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);

            listBox1.BeginUpdate();
            listBox1.Items.Clear();

            foreach (string line in words)
            {
                bool rhymesWith = line.EndsWith(textBox2.Text);
                if (rhymesWith)
                {
                    listBox1.Items.Add(line);
                }
            }
            listBox1.EndUpdate();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
            
        }
        /// <summary>
        /// Types the selected word into the textbox
        /// </summary>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = listBox1.Text;
        }
        /// <summary>
        /// Displays all the words
        /// </summary>
        private void button4_Click(object sender, EventArgs e)
        {
            String[] word_list = Properties.Resources.words.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
            listBox1.BeginUpdate();
            listBox1.Items.Clear();
            foreach (string s in word_list)
                listBox1.Items.Add(s);
            listBox1.EndUpdate();
        }
        /// <summary>
        /// Finds words made up of the given letters
        /// </summary>
        private void button2_Click(object sender, EventArgs e)//Scrabble
        {
            String[] words = Properties.Resources.words.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);

            listBox1.BeginUpdate();
            listBox1.Items.Clear();
            string holder = textBox2.Text;

            foreach (string line in words)
            {
                int length = line.Length;
                int i;
                int j = 0;
                int k;
                for (i = 0; i < length; i++)
                {
                    if (textBox2.Text.Contains(line[i]))
                    {
                        ///If matched, removes the letter from the user's string to prevent repeats
                        k = textBox2.Text.IndexOf(line[i]);
                        textBox2.Text = textBox2.Text.Remove(k, 1);
                        j++;
                    }
                }
                ///Makes sure words are shorter than 8 letters long and longer than 2
                if (j == i && length < 8 && length > 2)
                    listBox1.Items.Add(line);
                textBox2.Text = holder;
            }
            listBox1.EndUpdate();
        }
        /// <summary>
        /// Finds words that differ from the original word by one letter
        /// </summary>
        private void button3_Click(object sender, EventArgs e)//morph
        {
            String[] words = Properties.Resources.words.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
            listBox1.BeginUpdate();
            listBox1.Items.Clear();

            string morph = textBox2.Text;
            foreach (string line in words)
            {
                int length = morph.Length;
                int length2 = line.Length;
                int i;
                int j = 0;
                ///Makes sure strings are equal length
                if (length == length2)
                {
                    for (i = 0; i < length; i++)
                    {
                        if (morph[i] == line[i])
                            j++;
                    }
                }
                if (j == (length - 1))
                    listBox1.Items.Add(line);
            }
            listBox1.EndUpdate();
        }
    }
}
