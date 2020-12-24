using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_022_YunusNiandySaputro
{
    public partial class Form1 : Form
    {
        ClassData classData = new ClassData();

        public Form1()
        {
            InitializeComponent();
            label5.Enabled = false;
            button4.Enabled = false;
            button3.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tNIM.Text.Length <= 12 && 
                tAngkatan.Text.Length <= 4 &&
                tProdi.Text.Length <= 30 &&
                tNama.Text.Length <= 20)
            {
                try
                {
                    string nim = tNIM.Text;
                    string nama = tNama.Text;
                    string prodi = tProdi.Text;
                    string angkatan = tAngkatan.Text;
                    classData.insertMahasiswa(nim, nama, prodi, angkatan);
                    clear();
                    dataGridView1.DataSource = classData.getAllData();
                    MessageBox.Show("Data successfuly inserted");
                }
                catch (Exception ex)
                {
                    label7.Text = "Server Error";
                }
            }
            else
            {
                MessageBox.Show("Please check your data");
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string data = classData.sumData();
                label5.Enabled = true;
                label6.Text = data.ToString();
            }
            catch (Exception ex)
            {
                label7.Text = "Server Error";
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            if (tNIM.Text != "")
            {
                string nim = tNIM.Text;
                List<Mahasiswa> mhs = new List<Mahasiswa>();
                mhs.Add(classData.search(nim));
                clear();
                dataGridView1.DataSource = mhs;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = classData.getAllData();
            }
            catch
            {
                label7.Text = "Server error";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tNIM.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            tNama.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            tProdi.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
            tAngkatan.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value);

            button4.Enabled = true;
            button3.Enabled = true;
            button2.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (tNIM.Text.Length <= 12 &&
                tAngkatan.Text.Length <= 4 &&
                tProdi.Text.Length <= 30 &&
                tNama.Text.Length <= 20)
            {
                try
                {
                    Mahasiswa mhs = new Mahasiswa();
                    mhs.nim = tNIM.Text;
                    mhs.nama = tNama.Text;
                    mhs.prodi = tProdi.Text;
                    mhs.angkatan = tAngkatan.Text;

                    ClassData classData = new ClassData();
                    classData.updateDatabase(mhs, tNIM.Text);
                    MessageBox.Show("Data successfuly updated");
                    clear();
                    dataGridView1.DataSource = classData.getAllData();
                }
                catch
                {
                    label7.Text = "Server Error";
                }
            }
            else
            {
                MessageBox.Show("Please check your data");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    ClassData classData = new ClassData();
                    classData.deleteMahasiswa(tNIM.Text);
                    clear();
                    dataGridView1.DataSource = classData.getAllData();
                    MessageBox.Show("Data successfuly deleted");
                }
                catch (Exception ex)
                {
                    label7.Text = "Server Error";
                }
            }
        }

        public void clear()
        {
            tNIM.Text = "";
            tNama.Text = "";
            tProdi.Text = "";
            tAngkatan.Text = "";
            button3.Enabled = false;
            button4.Enabled = false;
            button2.Enabled = true;
            label7.Text = "";
            dataGridView1.DataSource = null;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
