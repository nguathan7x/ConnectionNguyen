using Lab05.BUS;
using Lab05.DAL.Entities;
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
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Lab05.GUI
{
    public partial class frmStudent : Form
    {
        private readonly StudentService _studentService = new StudentService();
        private readonly FacultyService _facultyService = new FacultyService();
        public frmStudent()
        {
            InitializeComponent();
        }
        
        private void frmQuanLySinhVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn thoát không?", "Thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            try
            {
                //setGridViewStyle(dgvStudent);
                var listFacultys = _facultyService.GetAll();
                var listStudents = _studentService.GetAll();
                FillFacultyCombobox(listFacultys);
                BindGrid(listStudents);

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindGrid(List<Student> listStudents)
        {
            dgvStudent.Rows.Clear();
            foreach (var item in listStudents)
            {
                int index = dgvStudent.Rows.Add();
                dgvStudent.Rows[index].Cells[0].Value = item.StudentID;
                dgvStudent.Rows[index].Cells[1].Value = item.FullName;
                if (item.Faculty != null)
                
                    dgvStudent.Rows[index].Cells[2].Value = item.Faculty.FacultyName;
                    dgvStudent.Rows[index].Cells[3].Value = item.AverageScore + "";

                if (item.MajorID != null)                  
                    dgvStudent.Rows[index].Cells[4].Value = item.Major.Name+ "";
               // ShowAvatar(item.Avatar);
             
            }
        }

        //private void ShowAvatar(string ImageName)
        //{

        //    if (string.IsNullOrEmpty(ImageName))
        //    {
        //        picAvatar.Image = null;
        //    }
        //    else
        //    {
        //        string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
        //        string imagePath= Path.Combine(parentDirectory,"Images", ImageName);
        //        picAvatar.Image = Image.FromFile(imagePath);
        //        picAvatar.Refresh();
        //    }
        //}

        private void FillFacultyCombobox(List<Faculty> listFacultys)
        {
           
            listFacultys.Insert(0, new Faculty());
            this.cmbFaculty.DataSource = listFacultys;  
            this.cmbFaculty.DisplayMember = "FacultyName";
            this.cmbFaculty.ValueMember = "FacultyID";
        }

        private void chkUnregisterMajor_CheckedChanged(object sender, EventArgs e)
        {
            var listStudents = new List<Student>();
            if (this.chkUnregisterMajor.Checked)
                listStudents = _studentService.GetAllHasNoMajor();
            else
                listStudents = _studentService.GetAll();
            BindGrid(listStudents);
        }

        private void btnPic_Click(object sender, EventArgs e)
        {

        }

   
    }
}