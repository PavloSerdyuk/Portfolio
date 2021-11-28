using DatabaseFirstApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseFirstApp
{
    public partial class Form1 : Form
    {
        int id = 0;
        News model = new News();
        DatabaseFirstDBEntities db = new DatabaseFirstDBEntities();
        public Form1()
        {
            InitializeComponent();
            bindGridView();
        }
        void bindGridView()
        {
            dataGridView1.DataSource = db.News.ToList<News>();
        }
        void ResetTextBoxes()
        {
            TitleTextBox.Clear();
            InfoTextBox.Clear();
            NameTextBox.Clear();
            SurnameTextBox.Clear();
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            model.ArticleTitle = TitleTextBox.Text.Trim();
            model.ArticleInfo = InfoTextBox.Text.Trim();
            model.Author_Name = NameTextBox.Text.Trim();
            model.Author_Surname = SurnameTextBox.Text.Trim();

            db.News.Add(model);
            int a = db.SaveChanges();
            if (a > 0)
            {
                MessageBox.Show("Data Inserted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bindGridView();
                ResetTextBoxes();
            }
            else
            {
                MessageBox.Show("Data not inserted.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            model = db.News.Where(x => x.Id == id).FirstOrDefault();
            TitleTextBox.Text = model.ArticleTitle;
            InfoTextBox.Text = model.ArticleInfo;
            NameTextBox.Text = model.Author_Name;
            SurnameTextBox.Text = model.Author_Surname;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            ResetTextBoxes();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            model.Id = id;
            model.ArticleTitle = TitleTextBox.Text.Trim();
            model.ArticleInfo = InfoTextBox.Text.Trim();
            model.Author_Name = NameTextBox.Text.Trim();
            model.Author_Surname = SurnameTextBox.Text.Trim();
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;

            int a = db.SaveChanges();
            if (a > 0)
            {
                MessageBox.Show("Data Updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bindGridView();
                ResetTextBoxes();
            }
            else
            {
                MessageBox.Show("Data not updated.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dR = MessageBox.Show("Do you really want to delete this news?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dR == DialogResult.Yes)
            {
                model = db.News.Where(x => x.Id == id).FirstOrDefault();
                db.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    MessageBox.Show("Data Deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bindGridView();
                    ResetTextBoxes();
                }
                else
                {
                    MessageBox.Show("Data not deleted.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("You have cancelled the deleted operation.");
            }
        }
    }
}
