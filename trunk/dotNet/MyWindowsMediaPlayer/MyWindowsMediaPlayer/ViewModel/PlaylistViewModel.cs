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
        public TagReader model;
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
            model = TagReader.getInstance();
            mediaList.Columns.Add("Title");
            mediaList.Columns.Add("Artist");
            mediaList.Columns.Add("Album");
            mediaList.Columns.Add("Path");
            this.cptRow = 0;
        }

        public void addToPlaylist(object sender, DataGridViewCellEventArgs e)
        {
            string path = MediaViewerViewModel.getInstance().mediasInfo.Rows[e.RowIndex].Field<string>(4);
            try
            {
                TagLib.Id3v2.Tag tag = model.tags[path];

                this.mediaList.Rows.Add();
                this.mediaList.Rows[this.cptRow].SetField(this.mediaList.Columns["Title"], tag.Title);
                this.mediaList.Rows[this.cptRow].SetField(this.mediaList.Columns["Artist"], tag.Artists[0]);
                this.mediaList.Rows[this.cptRow].SetField(this.mediaList.Columns["Album"], tag.Album);
                this.mediaList.Rows[this.cptRow].SetField(this.mediaList.Columns["Path"], path);
                this.cptRow++;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("je cherche " + path);
                foreach (KeyValuePair<string, TagLib.Id3v2.Tag> t in model.tags)
                {
                    Console.WriteLine("Ze putain de key : " + t.Key);
                }

            }
        }

    }
}
