using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class Form1 : Form
    {
        

        private readonly BusinessAdmin businessAdmin;
        

        public Form1()
        {
            InitializeComponent();
            businessAdmin = new BusinessAdmin();
            
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            newsongs1.Show();
            adminlogin1.Hide();
            songinfoinput1.Hide();

            btnEditSongs.Hide();
            genres1.Hide();
            contact1.Hide();
           


          
        }

        

        private void BtnNewSongs_Click(object sender, EventArgs e)
        {
            newsongs1.Show();
            adminlogin1.Hide();
            songinfoinput1.Hide();
            genres1.Hide();
            contact1.Hide();

        }
        private void BtnGenres_Click(object sender, EventArgs e)
        {
           


            newsongs1.Hide();
            newsongs1.SendToBack();
            adminlogin1.Hide();
            songinfoinput1.Hide();
            genres1.Show();

            genres1.flowLayoutPanel1.Hide();
            contact1.Hide();



        }

        private void BtnAdmin_Click(object sender, EventArgs e)
        {
            Adminlogin al = new Adminlogin();
            newsongs1.Hide();
            adminlogin1.Show();
            songinfoinput1.Hide();
            genres1.Hide();
            contact1.Hide();


        }

        private void BtnContact_Click(object sender, EventArgs e)
        {
            newsongs1.Hide();
            newsongs1.SendToBack();
            adminlogin1.Hide();
            songinfoinput1.Hide();
            genres1.Show();

            genres1.flowLayoutPanel1.Hide();
            contact1.Show();
        }

        private void BtnHelp_Click(object sender, EventArgs e)
        {

        }
        private void BtnEditSongs_Click(object sender, EventArgs e)
        {
            
            newsongs1.Hide();
            adminlogin1.Hide();
            songinfoinput1.Show();
            btnEditSongs.Show();
            genres1.Hide();
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       /* private void BtnHamburger_Click(object sender, EventArgs e)
        {
           
            if (panelMenu.Width == 70)
            {

                panelMenu.Width = 190;
                logo.Show();
                btnHamburger.Location = new Point(140, 12);
                btnNewSongs.Text = "New Songs";
                btnGenres.Text = "Genres";
                btnAdmin.Text = "Admin";
                btnContact.Text = "Contact";
                btnHelp.Text = "Help";
                btnEditSongs.Text = "EditSongs";
                btnExit.Text = "Exit";


            }
            else
            {
                panelMenu.Width = 70;
                
                
                logo.Hide();
                btnHamburger.Location = new Point(10, 12);
                
                btnNewSongs.Text = " ";               
                btnGenres.Text = " ";
                btnAdmin.Text = " ";
                btnContact.Text = " ";
                btnHelp.Text = " ";
                btnEditSongs.Text = " ";
                btnExit.Text = " ";
                
                
                
            }
        }*/

     
    }
}
