using lab1;
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

namespace lab1
{
    public partial class Form1 : Form
    {
        MyMatrix matrixObject = new MyMatrix();

        public Form1()
        {
            InitializeComponent();
            matrixObject.FillMatrix();
            DisplayMatrixInGridView();
        }

        private void DisplayMatrixInGridView()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            for (int i = 0; i < matrixObject.RowCount; i++)
            {
                dataGridView1.Columns.Add("Колонка" + i, "Колонка" + i);
            }
            for (int i = 0; i < matrixObject.RowCount; i++)
            {
                DataGridViewRow row = new DataGridViewRow();

                for (int j = 0; j < matrixObject.ColCount; j++)
                {
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = matrixObject.matrix[i, j] });
                }

                dataGridView1.Rows.Add(row);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            matrixObject.FillMatrix();
            DisplayMatrixInGridView();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            int columnWithoutNegative = matrixObject.FirstColumnWithoutNegativeElement();
            if (columnWithoutNegative != -1)
            {
                textBox3.Text = (columnWithoutNegative).ToString(); 
            }
            else
            {
                textBox3.Text = "такої немає";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            matrixObject.SortRowsByCountOfEqualElements();
            DisplayMatrixInGridView();
        }
    }
}

