﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using DataAccessLayer.Models;
using PresentationLayer.Properties;

namespace PresentationLayer
{
    public partial class Genres : UserControl
    {
      
        public BusinessSongs business;
        public EventHandler btnEvent;

        public Genres()
        {
            this.business = new BusinessSongs();
            InitializeComponent();

            
            
       
        }

        private void SongsItems(List<Song> listSong)
        {


            // Mora jovan da mi prosledi static polje od njegov event
            FillList();
            var Songs = listSong;
            var listLength = listSong.Count;

            SongCard[] listSongs = new SongCard[listLength];

            for (int i = 0; i < listLength; i++)
            {

                // Song info
                listSongs[i] = new SongCard();
                listSongs[i].Icon = Resources.music;
                listSongs[i].IconRating = Resources.star;
                listSongs[i].IconYoutube = Resources.youtube;
                listSongs[i].IconBackground = Color.FromArgb(44, 62, 80);
                listSongs[i].Youtube_hyperlink = Songs[i].Youtube_Url;
                listSongs[i].Title = Songs[i].Title;
                listSongs[i].Genre = Songs[i].Genre;
                listSongs[i].Performer = Songs[i].Performer.Name + Songs[i].Performer.Surname;
                listSongs[i].Rating = Songs[i].Jim_Rating;

                // Add to flow panel
                flowLayoutPanel1.Controls.Add(listSongs[i]);


            }
        }
        private void FillList()
        {
            flowLayoutPanel1.Controls.Clear();
        }
        private void Genres_Load(object sender, EventArgs e)
        {

            this.Show();

            flowLayoutPanel1.Hide();
            
            
        }

      

        private void BtnClicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            var genre = btn.Text;

            var Songs = this.business.GetSongsByGenre(genre);

            SongsItems(Songs);
            flowLayoutPanel1.Show();
            flowLayoutPanel1.BringToFront();
        }


    }
}
