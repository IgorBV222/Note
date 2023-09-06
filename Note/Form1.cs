using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Note
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            monthCalendar1.MaxSelectionCount = 1;
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }        
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt = dateTimePicker1.Value;
            monthCalendar1.AddBoldedDate(dt);
            textDate.Text += $"\n{dateTimePicker1.Text}";            
        }
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            var dt = monthCalendar1.SelectionRange.Start;
            textDate.Text += $"\n {dt.ToString("yyyy-MM-dd HH:mm:ss")}";
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, textDate.Text);
            MessageBox.Show($" Результат сохранен в файл:\n{filename}\n");
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            string fileText = System.IO.File.ReadAllText(filename);
            textDate.Text = fileText;
            MessageBox.Show($"Открыт файл:\n{filename}\n");
        }
    }
}