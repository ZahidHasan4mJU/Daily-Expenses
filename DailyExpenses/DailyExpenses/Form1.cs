using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSVLib;

namespace DailyExpenses
{
    public partial class ExpensesUIForm : Form
    {
        public ExpensesUIForm()
        {
            InitializeComponent();
        }

        private string fileLocation = @"D:\Expenses\dailyExpenses.csv";
        private void saveButton_Click(object sender, EventArgs e)
        {
            FileStream aStream = new FileStream(fileLocation, FileMode.Append);
            CsvFileWriter write = new CsvFileWriter(aStream);
            List<string> list = new List<string>();
            if (amountTextBox.Text != "" || categoryComboBox.Text != "" || particularTextBox.Text != "")
            {
                list.Add(amountTextBox.Text);
                list.Add(categoryComboBox.Text);
                list.Add(particularTextBox.Text);
                write.WriteRow(list);
                aStream.Close();
                MessageBox.Show(@"success");
            }


        }

        private void showButton_Click(object sender, EventArgs e)
        {
            FileStream aStream2 = new FileStream(fileLocation, FileMode.OpenOrCreate);
            CsvFileReader read = new CsvFileReader(aStream2);
            List<string> list2 = new List<string>();

            double num = 0;
            double max = 0;
            double totalExpense = 0;
            while (read.ReadRow(list2))

            {
               totalExpense += Convert.ToDouble(list2[0]);
                num = Convert.ToDouble(list2[0]);
                if (max < num)
                {
                    max = num;
                }


            }
            totalExpenseTextBox.Text = totalExpense.ToString();
            maximumExpenseTextBox.Text = max.ToString();
            
            aStream2.Close();

        }

        private void showButton2_Click(object sender, EventArgs e)
        {
            FileStream aStream3 = new FileStream(fileLocation, FileMode.OpenOrCreate);
            CsvFileReader read = new CsvFileReader(aStream3);
            List<string> list = new List<string>();
            double total = 0;
            listView.Items.Clear();
            while (read.ReadRow(list))
           
            {
                if (list[1] == categoryComboBox2.Text)
                {
                    ListViewItem item = new ListViewItem(list[1]);
                    item.SubItems.Add(list[2]);
                    listView.Items.Add(item);
                    total += Convert.ToDouble(list[0]);
                } 
                  
                 
                  

            }
            totalTextBox.Text = total.ToString();
            aStream3.Close();

        }
    }
}
