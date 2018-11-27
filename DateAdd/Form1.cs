using DateAdd.Presenters;
using DateAdd.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DateAdd
{
    public partial class Form1 : Form, IDateAddView
    {
        private IDateAddPresenter dateAddPresenter;

        public Form1(IDateAddPresenter dateAddPresenter)
        {
            this.dateAddPresenter = dateAddPresenter;
            InitializeComponent();
        }

        public string DateText
        { get
            {
                return txtDate.Text;
            }
            set
            {
                txtDate.Text = value;
            }
        }

        public string DaysToAddText
        { get
            {
                return txtDaysToAdd.Text;
            }
            set
            {
                txtDaysToAdd.Text = value;
            }
        }

        public string OutputText
        {
            get
            {
                return lblOutput.Text;
            }
            set
            {
                lblOutput.Text = value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dateAddPresenter.SetDateAddView(this);
            OutputText = dateAddPresenter.AddDays();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
