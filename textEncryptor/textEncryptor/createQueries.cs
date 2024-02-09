using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using textEncryptor.sources;

namespace textEncryptor
{
    public partial class createQueries : Form
    {
        List<object> columns = new List<object>();
        List<object> entries = new List<object>();
        public createQueries()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new majorConnections().getPlainValueTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new majorConnections().getEncryptorTable();
        }

        private void createQueries_Load(object sender, EventArgs e)
        {
            columns.Add("All");
            comboBox1.Items.Add("All");
            radioButton2.Checked = true;

            object[,] header = new majorConnections().getPlainValues();
            for(int i = 0; i < header.GetLength(1); i++)
            {
                entries.Add(header[0, i]);
                comboBox2.Items.Add(entries[i]);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO " + textBox1.Text;
            object[,] headers = new majorConnections().getPlainValues();
            if (columns.Count > 1)
            {
                query += "(";
                for (int i = 1; i < columns.Count; i++)
                {
                    query += columns.Count - 1 == i ? "" + columns[i] + "" : "" + columns[i] + "" + ", ";
                }
                query += ") VALUES(";

                for (int i = 0; i < entries.Count; i++)
                {
                    query += entries.Count - 1 == i ? "\"" + entries[i] + "\"" : "\"" + entries[i] + "\"" + ", ";
                }
                query += ");";
            }
            else
            {
                query += " VALUES(";
                for (int i = 0; i < entries.Count; i++)
                {
                    query += entries.Count - 1 == i ? "\"" + headers[0, i] + "\"" : "\"" + headers[0, i] + "\"" + ", ";
                }
                query += ");";
            }
            label4.Text = query;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            columns.Add(textBox2.Text);
            comboBox1.Items.Clear();

            for (int j = 0; j < columns.Count; j++)
            {
                comboBox1.Items.Add(columns[j]);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox3.Text = comboBox2.Text;
            entries.Remove(textBox3.Text);
            comboBox2.Items.Clear();

            for (int j = 0; j < entries.Count; j++)
            {
                comboBox2.Items.Add(entries[j]);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string query = "";
            object[,] headers = new majorConnections().getPlainValues();
            for(int a = 0; a < headers.GetLength(0); a++)
            {
                if(columns.Count > 1)
                {
                    query = "INSERT INTO " + textBox1.Text + "(";
                    for(int d = 1; d < columns.Count; d++)
                    {
                        query += columns.Count - 1 == d ? "" + columns[d] + "" : "" + columns[d] + ", ";
                    }
                    query += ") VALUES(";
                    for (int b = 0; b < headers.GetLength(1); b++)
                    {
                        query += entries.Count - 1 == b ? "\'" + headers[a, b] + "\'" : "\"" + headers[a, b] + "\", ";
                    }
                }
                else
                {
                    query = "INSERT INTO " + textBox1.Text + " VALUES(";
                    for (int b = 0; b < headers.GetLength(1); b++)
                    {
                        query += entries.Count - 1 == b ? "\'" + headers[a, b] + "\'" : "\'" + headers[a, b] + "\', ";
                    }
                }
                query += ");";
                richTextBox1.Text += query + "\n";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            main_home home = new main_home();
            home.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            entries.Add(textBox3.Text);
            comboBox2.Items.Clear();
            for(int i = 0; i < entries.Count; i++)
            {
                comboBox2.Items.Add(entries[i]);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = comboBox1.Text;
            columns.Remove(comboBox1.Text);
            comboBox1.Items.Remove(textBox2.Text);
            comboBox2.Items.Clear();
            for (int i = 0; i < entries.Count; i++)
            {
                comboBox2.Items.Add(entries[i]);
            }
        }
    }
}
