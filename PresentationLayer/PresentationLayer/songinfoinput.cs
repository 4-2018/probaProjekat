using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DataAccessLayer.Models;
using BusinessLayer;

namespace PresentationLayer
{
    public partial class Songinfoinput : UserControl
    {
        public BusinessSongs businessSong;
        public BusinessPerfomer businessPerformer;
        public BusinessAdmin businessAdmin;
        public Songinfoinput()
        {
            this.businessSong = new BusinessSongs();
            this.businessPerformer = new BusinessPerfomer();
            this.businessAdmin = new BusinessAdmin();
            InitializeComponent();
            star3.Hide();
            star4.Hide();
            star6.Hide();
            star7.Hide();
            star8.Hide();
            star11.Hide();
            FillList();
        }

        //Filling list box of songs for admin
        private void FillList()
        {
            listBoxSongsForAdmin.Items.Clear();
            List<Song> list = this.businessSong.GetAllSongs();

            foreach (Song item in list)
            {
                listBoxSongsForAdmin.Items.Add(item.ToString());
            }
        }
        // Clear fileds
        private void ClearFields()
        {
            textBoxTitle.Text = null;
            textBoxGenre.Text = null;
            textBoxRatingJIM.Text = null;
            textBoxURLYoutube.Text = null;
            textBoxPerfSurname.Text = null;
            textBoxPerfName.Text = null;
            FillList();
        }
        // listBox
        private void ListBoxSongsForAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fields = listBoxSongsForAdmin.SelectedItem.ToString();
            string[] array = fields.Split('-');
            textBoxPerfName.Text = array[2];
            textBoxPerfSurname.Text = array[3] ;
            textBoxTitle.Text = array[4];
            textBoxGenre.Text = array[5];                        
            textBoxRatingJIM.Text = array[6];
            textBoxURLYoutube.Text = array[7];
        }

        //Insert song
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Song s = new Song();
            Performer p = new Performer();
            Admin a = new Admin();

            if (textBoxGenre.Text.Length == 0 || textBoxTitle.Text.Length == 0 ||
                textBoxPerfName.Text.Length == 0 || textBoxPerfSurname.Text.Length == 0 || textBoxURLYoutube.Text.Length==0)  
            {
                star3.Show();
                star4.Show();
                star6.Show();
                star7.Show();
                star8.Show();
                star11.Show();
                
                MessageBox.Show("Niste uneli sve podatke!");
            }
            else
            {
                // Song
                s.Title = textBoxTitle.Text;
                s.Genre = textBoxGenre.Text;
                s.Youtube_Url = textBoxURLYoutube.Text;
                s.Jim_Rating = Convert.ToDecimal(textBoxRatingJIM.Text);
                s.Picture_Url = " ";
                var name = textBoxPerfName.Text;
                var surname = textBoxPerfSurname.Text;

                // Check if Perfomers Exists
                Performer performer = this.businessPerformer.GetPerformer(name, surname);
                if(performer.Performer_Id < 1)
                {
                    int result = this.businessPerformer.InsertPerformer(name, surname);
                    performer = this.businessPerformer.GetPerformer(name, surname);
                }

                //adminlogin.username, adminlogin.password
                a = this.businessAdmin.AuthenticateAdmin(Adminlogin.adminIDGET);

                if (this.businessSong.InsertSong(performer, a, s))
                {
                    MessageBox.Show("Successfull input of song!");
                    FillList();
                }
                else
                {
                    MessageBox.Show("Unsuccessfull input of song!");
                }
            }
           
        }
        //Update song
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            Song s = new Song();
            Performer p = new Performer();
            s.Title = textBoxTitle.Text;
            s.Genre = textBoxGenre.Text;
            s.Jim_Rating =Convert.ToDecimal(textBoxRatingJIM.Text);
            s.Youtube_Url = textBoxURLYoutube.Text;
            s.Song_Id = Convert.ToInt32(listBoxSongsForAdmin.SelectedItem.ToString().Split('-')[0]);
            p.Performer_Id = Convert.ToInt32(listBoxSongsForAdmin.SelectedItem.ToString().Split('-')[1]);

            p.Name = textBoxPerfName.Text;
            p.Surname = textBoxPerfSurname.Text;
            //(this.performer.UpdatePerformer(p))
            if (this.businessSong.UpdateSong(s) > 0 && this.businessPerformer.UpdatePerformer(p))
            {
                MessageBox.Show("Successfull song update!");
                ClearFields();
            }
            else
            {
                MessageBox.Show("Unsuccessfull song update!");
            }
  
        }
        //Delete song
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Song s = new Song();

            s.Song_Id = Convert.ToInt32(listBoxSongsForAdmin.SelectedItem.ToString().Split('-')[0]);

            if(this.businessSong.DeleteSong(s) > 0)
            {
                MessageBox.Show("Successfull delete!");
                FillList();
            }else
            {
                MessageBox.Show("Unsuccessfull delete!");
            }
        }

       
    }
}
