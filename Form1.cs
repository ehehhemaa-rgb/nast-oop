using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nast
{
    public partial class Form1 : Form

    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbDepartment.Items.Add("Все отделы");
            cmbDepartment.Items.AddRange(employees.Select(e => e.Department).Distinct().Cast<object>().ToArray());
            cmbDepartment.SelectedIndex = 0;

            btnApply.Click += (s, ev) => ApplyFilter();
            ApplyFilter();
        }
        private void ApplyFilter()
        {
            var query = employees.AsEnumerable();

            if (cmbDepartment.SelectedIndex > 0)
            {
                query = query.Where(e => e.Department == cmbDepartment.SelectedItem.ToString());
            }

            var result = query.ToList();
            dgvEmployees.DataSource = result;
            lblStatus.Text = $"Найдено сотрудников: {result.Count}";
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();

        }
       

        private void dgvEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Label_Click(object sender, EventArgs e)
        {

        }
    }
}
