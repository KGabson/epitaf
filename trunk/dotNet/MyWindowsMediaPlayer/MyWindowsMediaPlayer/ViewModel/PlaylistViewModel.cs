using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using MyWindowsMediaPlayer.Model;

namespace MyWindowsMediaPlayer.ViewModel
{
    public class PlaylistViewModel
    {
        private static PlaylistViewModel instance = null;
        public DataTable mediaList;
        private int cptRow;

        public static PlaylistViewModel getInstance()
        {
            if (instance == null)
                instance = new PlaylistViewModel();
            return instance;
        }

        private PlaylistViewModel()
        {
            this.mediaList = new DataTable();
            mediaList.Columns.Add("Title");
            mediaList.Columns.Add("Artist");
            mediaList.Columns.Add("Album");
  //          mediaList.Columns.Add("Time");
            this.cptRow = 0;
        }

        public void addToPlaylist(object sender, DataGridViewCellEventArgs e)
        {
            DataRow ro = MediaViewerViewModel.getInstance().mediasInfo.Rows[e.RowIndex];
            TagLib.Id3v2.Tag tag = TagReader.getInstance().tags[ro["Path"].ToString()];

            this.mediaList.Rows.Add();
            this.mediaList.Rows[this.cptRow].SetField(this.mediaList.Columns["Title"], tag.Title);
            this.mediaList.Rows[this.cptRow].SetField(this.mediaList.Columns["Artist"], tag.Artists[0]);
            this.mediaList.Rows[this.cptRow].SetField(this.mediaList.Columns["Album"], tag.Album);
//            this.mediaList.Rows[this.cptRow].SetField(this.mediaList.Columns["Time"], tag.t);
            this.cptRow++;
         
        }

    }
}
