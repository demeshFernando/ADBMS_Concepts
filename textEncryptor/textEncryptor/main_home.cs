using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using textEncryptor.sources;

namespace textEncryptor
{
    public partial class main_home : Form
    {
        int numeratorValue = 0, denomenatorValue = 1;
        bool isEncrypted = false, isPlainTextAvailable = false;
        public main_home()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }
        protected object[,] values;
        private void button2_Click(object sender, EventArgs e)
        {
            this.Text = "Loading...";
            this.Enabled = false;
            //if there is not correct filename
            if(textBox2.Text == "")
            {
                MessageBox.Show("Select a proper file path before proceeding", "textEncryptor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
            }

            //if there is no sheet name
            else if(textBox1.Text == "")
            {
                MessageBox.Show("Sheet name required", "textEncryptor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
            //if everything is OK
            else
            {
                try
                {
                    List<List<string>> files = new List<List<string>>();
                    List<string> columns = new List<string>();
                    columns.Add("First Name");
                    columns.Add("Last Name");
                    columns.Add("Other Names");

                    List<string> temp1 = new List<string>();
                    temp1.Add("Demesh");
                    temp1.Add("Fernando");
                    temp1.Add("Warnakulasuriya");
                    files.Add(temp1);

                    temp1 = new List<string>();
                    temp1.Add("Thilani");
                    temp1.Add("Sewwandi");
                    temp1.Add("Jayasuriya");
                    files.Add(temp1);

                    temp1 = new List<string>();
                    temp1.Add("Senudu");
                    temp1.Add("Weerawardana");
                    temp1.Add("");
                    files.Add(temp1);

                    temp1 = new List<string>();
                    temp1.Add("Nimasha");
                    temp1.Add("Fernandez");
                    temp1.Add("Warnakulasuriya");
                    files.Add(temp1);

                    DataTable table = new DataTable();
                    table.Columns.Add(columns[0]);
                    table.Columns.Add(columns[1]);
                    table.Columns.Add(columns[2]);

                    for(int i = 0; i < files.Count; i++)
                    {
                        List<string> temp2 = files[i];
                        DataRow row = table.NewRow();
                        for(int j = 0; j < temp2.Count; j++)
                        {
                            row[j] = temp2[j];
                        }
                        table.Rows.Add(row);
                    }
                    dataGridView1.DataSource = table;
                }
                catch(Exception message)
                {
                    MessageBox.Show("There is an error read the error file: " + message.Message, "textEncryptor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.Text = "Finializing...";

                values = new object[dataGridView1.Rows.Count, dataGridView1.Columns.Count];
                numeratorValue = 0;
                denomenatorValue = dataGridView1.Rows.Count * dataGridView1.Columns.Count;
                for (int i = 0; i < values.GetLength(0); i++)
                {
                    for (int j = 0; j < values.GetLength(1); j++)
                    {
                        values[i, j] = this.dataGridView1.Rows[i].Cells[j].Value;
                        this.Text = "Finializing..." + new majorConnections().getPercentage(++numeratorValue, denomenatorValue) + "%";
                    }
                }
                new majorConnections().loadValues(values);
                dataGridView1.DataSource = new majorConnections().getPlainValueTable();

                if (checkBox1.Checked == true)
                {
                    this.Text = "Encrypting...";
                    this.isEncrypted = true;
                }
            }

            isPlainTextAvailable = false;
            this.Enabled = true;
            this.Text = "Start Encrypting";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    new majorConnections().storeFilename(fileDialog.FileName);
                    textBox2.Text = new majorConnections().getFileName();
                    isEncrypted = false;
                }
            }
            catch (Exception message)
            {
                MessageBox.Show("There is an error read the error file: " + message.Message, "textEncryptor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            createQueries queries = new createQueries();
            queries.Show();
            this.Hide();
        }

        private void main_home_Load(object sender, EventArgs e)
        {
            textBox2.Text = "C:\\Users\\User\\Desktop\\Book1.xlsx";
            new majorConnections().storeSheetname("sheet1");
            new majorConnections().storeFilename("C:\\Users\\User\\Desktop\\Book1.xlsx");
            textBox1.Text = "sheet1";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Text = "Loading...";
            this.Enabled = false;
            try
            {
                dataGridView1.DataSource = new majorConnections().getPlainValueTable();
                isEncrypted = false;
            }
            catch (Exception message)
            {
                MessageBox.Show("There is an error read the error file: " + message.Message, "textEncryptor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Enabled = true;
            this.Text = "Start Encrypting";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            if (isEncrypted == false)
            {
                this.Text = "Encrypting...";
                numeratorValue = 0;
                object[,] encryptedgValues = new majorConnections().getPlainValues();
                string[,] encryptedItems = new string[encryptedgValues.GetLength(0), encryptedgValues.GetLength(1)];
                for (int i = 0; i < encryptedItems.GetLength(0); i++)
                {
                    for (int j = 0; j < encryptedItems.GetLength(1); j++)
                    {
                        encryptedItems[i, j] = new majorConnections().loadEncryptor(string.Format("{0}", encryptedgValues[i, j]));
                        this.Text = "Encrypting..." + new majorConnections().getPercentage(++numeratorValue, denomenatorValue) + "%";
                    }
                }
                
                for(int i = 0; i < encryptedgValues.GetLength(0); i++)
                {
                    for(int j = 0; j < encryptedgValues.GetLength(1); j++)
                    {
                        encryptedgValues[i, j] = encryptedItems[i, j];
                    }
                }

                new majorConnections().loadEncryptingArray(encryptedgValues);
                this.isEncrypted = true;
            }
            if (GlobalStorage.encryptedValues == null)
            {
                MessageBox.Show("The array is null");
            }
            else
            {
                try
                {
                    dataGridView2.DataSource = new majorConnections().getEncryptorTable();
                }
                catch (Exception message)
                {
                    MessageBox.Show("There is an error read the error file: " + message.Message, "textEncryptor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.Enabled = true;
            this.Text = "Start Encrypting";
        }
    }
}
