using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MikesTimeCalc
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            LoadFormData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.mikesWidget1.IsValid &&
                this.mikesWidget2.IsValid &&
                this.mikesWidget3.IsValid &&
                this.mikesWidget4.IsValid )
               
            {
                TimeSpan ts = this.mikesWidget2.DateTimeData - this.mikesWidget1.DateTimeData +
                             (this.mikesWidget4.DateTimeData - this.mikesWidget3.DateTimeData);

                txtResult.Text = String.Format("{0}:{1}", ts.Hours, ts.Minutes);
            }else{
                MessageBox.Show("Please correct time values.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormData.Instance["mikeswidget1"] = this.mikesWidget1.Data;
            FormData.Instance["mikeswidget2"] = this.mikesWidget2.Data;
            FormData.Instance["mikeswidget3"] = this.mikesWidget3.Data;
            FormData.Instance["mikeswidget4"] = this.mikesWidget4.Data;
            //
            FormData.Instance.Save();
            
            

             this.Dispose();
        }


        private void LoadFormData()    
        {
            FormData.Instance.Load();
            this.mikesWidget1.Data = FormData.Instance["mikeswidget1"];
            this.mikesWidget2.Data = FormData.Instance["mikeswidget2"];
            this.mikesWidget3.Data = FormData.Instance["mikeswidget3"];
            this.mikesWidget4.Data = FormData.Instance["mikeswidget4"];
        }
    }//eoc
}//eon
