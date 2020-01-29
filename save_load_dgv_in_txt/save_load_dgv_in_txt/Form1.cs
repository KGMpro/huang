using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace save_load_dgv_in_txt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("Column1", "ФИО");
            dataGridView1.Columns.Add("Column1", "Возраст");
            dataGridView1.Columns.Add("Column1", "Стаж работы");
            dataGridView1.Columns.Add("Column1", "Зароботная плата");
            dataGridView1.Columns.Add("Column1", "Пол");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"C:\Users\Markushin_DS\Desktop\save_load_dgv_in_txt\save_load_dgv_in_txt\bin\Debug\datag322.txt", FileMode.Create);
            StreamWriter streamWriter = new StreamWriter(fs);

            try
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    for (int i = 0; i < dataGridView1.Rows[j].Cells.Count; i++)
                    {
                        streamWriter.Write(dataGridView1.Rows[j].Cells[i].Value + "     ");
                    }

                    streamWriter.WriteLine();
                }

                streamWriter.Close();
                fs.Close();

                MessageBox.Show("Файл успешно сохранен");
            }
            catch
            {
                MessageBox.Show("Ошибка при сохранении файла!");
            }

            //for (int i = 0; i < dataGridView1.Columns.Count; i++)
            //{
            //    object obj = dataGridView1[i, dataGridView1.CurrentCell.RowIndex].Value;
            //    if (obj != null) listBox1.Items.Add(obj);

            //}
            String x;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                if (!row.IsNewRow)
                {
                    x = row.Cells[0].Value.ToString() + " " + row.Cells[1].Value.ToString() + " " + row.Cells[2].Value.ToString() + " " + row.Cells[3].Value.ToString() + " " + row.Cells[4].Value.ToString();
                    listBox1.Items.Add(x);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fStream = new FileStream(@"C:\Users\Markushin_DS\Desktop\save_load_dgv_in_txt\save_load_dgv_in_txt\bin\Debug\datag322.txt", FileMode.Open);
            StreamReader streamReader = new StreamReader(fStream);

            string[] str;
            int numberOfRows = 0;
            try
            {
                string[] str1 = streamReader.ReadToEnd().Split('$');
                numberOfRows = str1.Count();

                dataGridView1.RowCount = numberOfRows - 1;
                for (int i = 0; i < numberOfRows - 1; i++)
                {
                    str = str1[i].Split('#');
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = str[j];
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при открытии файла!");
            }
            
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_Enter(object sender, EventArgs e)
        {
            
        }
    }
}
