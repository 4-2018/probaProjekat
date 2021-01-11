using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class contact : UserControl
    {
        public contact()
        {
            InitializeComponent();
        }

        private void Contact_Load(object sender, EventArgs e)
        {
            panelMarko.SendToBack();
            panelIvan.BringToFront();
            panelJovan.SendToBack();
        }



        private void BtnIvanLeft_Click(object sender, EventArgs e)
        {
            panelMarko.BringToFront();
            panelIvan.SendToBack();
            panelJovan.SendToBack();
        }

        private void BtnIvanRight_Click(object sender, EventArgs e)
        {
            panelIvan.SendToBack();
            panelMarko.SendToBack();


            panelJovan.BringToFront();
        }

        private void BtnIvanCenter_Click(object sender, EventArgs e)
        {
            panelIvan.BringToFront();
            panelMarko.SendToBack();


            panelJovan.SendToBack();
        }
    }
}
