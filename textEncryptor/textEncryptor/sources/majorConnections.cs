using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using textEncryptor.sources;

namespace textEncryptor.sources
{
    class majorConnections
    {
        private string createPath(string filePath)
        {
            return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 12.0;IMEX=1;'";
        }

        public DataTable connect(string filePath, string sheetName)
        {
            OleDbConnection connection = new OleDbConnection(createPath(filePath));
            OleDbDataAdapter adapter = new OleDbDataAdapter("select * from ["+ sheetName +"$]", connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public void loadValues(object[,] values)
        {
            GlobalStorage.plainValues = new object[values.GetLength(0), values.GetLength(1)];
            GlobalStorage.plainValues = values;
        }

        public void loadEncryptingArray(object[,] values)
        {
            GlobalStorage.encryptedValues = new object[values.GetLength(0), values.GetLength(1)];
            GlobalStorage.encryptedValues = values;
        }

        public int getPercentage(int numerator, int denomenator)
        {
            return (numerator / denomenator) * 100;
        }

        public object[,] getPlainValues()
        {
            return GlobalStorage.plainValues;
        }

        public string loadEncryptor(string value)
        {

            return new encryptor().Encrypt(value);
        }

        public DataTable getPlainValueTable()
        {
            DataTable table = new DataTable();
            for (int i = 0; i < GlobalStorage.plainValues.GetLength(1); i++)
            {
                table.Columns.Add("Column " + i);
            }

            for (int i = 0; i < GlobalStorage.plainValues.GetLength(0); i++)
            {
                DataRow row = table.NewRow();
                for (int j = 0; j < GlobalStorage.plainValues.GetLength(1); j++)
                {
                    row[j] = GlobalStorage.plainValues[i, j];
                }
                table.Rows.Add(row);
            }

            return table;
        }

        public DataTable getEncryptorTable()
        {
            DataTable table = new DataTable();
            for (int i = 0; i < GlobalStorage.encryptedValues.GetLength(1); i++)
            {
                table.Columns.Add("Column " + i);
            }

            for (int i = 0; i < GlobalStorage.encryptedValues.GetLength(0); i++)
            {
                DataRow row = table.NewRow();
                for (int j = 0; j < GlobalStorage.encryptedValues.GetLength(1); j++)
                {
                    row[j] = GlobalStorage.encryptedValues[i, j];
                }
                table.Rows.Add(row);
            }

            return table;
        }

        public void storeFilename(string fileName)
        {
            GlobalStorage.fileName = fileName;
        }
        public string getFileName()
        {
            return GlobalStorage.fileName;
        }

        public void storeSheetname(string sheetName)
        {
            GlobalStorage.sheetName = sheetName;
        }
        public string getSheetName()
        {
            return GlobalStorage.sheetName;
        }
    }

    public static class GlobalStorage
    {
        public static object[,] plainValues;
        public static object[,] encryptedValues;
        public static string fileName = "", sheetName = "";
    }
}
