using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyWindowsMediaPlayer.Model;
using System.Windows.Forms;
using System.Data;

namespace MyWindowsMediaPlayer.ViewModel
{
    public class MediaViewerViewModel : IViewModel
    {
        private static MediaViewerViewModel instance = null;
        
        public TagReader model;
        public DataTable mediasInfo;
        public string selectedPath;
        private int cptRow;

        public static MediaViewerViewModel getInstance()
        {
            if (instance == null)
            {
                instance = new MediaViewerViewModel();
            }
            return instance;
        }

        private MediaViewerViewModel()
        {
            this.cptRow = 0;
            this.mediasInfo = new DataTable();
            model = TagReader.getInstance();
            mediasInfo.Columns.Add("N°");
            mediasInfo.Columns.Add("Title");
            mediasInfo.Columns.Add("Artist");
            mediasInfo.Columns.Add("Album");
            mediasInfo.Columns.Add("Path");
        }

        public void updateList(object sender, TreeViewEventArgs e)
        {
            this.mediasInfo.Clear();
            this.selectedPath = e.Node.Name;
            model.path = e.Node.Name;
            model.fillTags();
            this.cptRow = 0;
            try
            {
                foreach (KeyValuePair<string, TagLib.Id3v2.Tag> t in model.tags)
                {
                    this.mediasInfo.Rows.Add();
                    this.mediasInfo.Rows[this.cptRow].SetField(this.mediasInfo.Columns["N°"], t.Value.Track);
                    this.mediasInfo.Rows[this.cptRow].SetField(this.mediasInfo.Columns["Title"], t.Value.Title);
                    this.mediasInfo.Rows[this.cptRow].SetField(this.mediasInfo.Columns["Artist"], t.Value.AlbumArtists[0]);
                    this.mediasInfo.Rows[this.cptRow].SetField(this.mediasInfo.Columns["Album"], t.Value.Album);
                    this.mediasInfo.Rows[this.cptRow].SetField(this.mediasInfo.Columns["Path"], t.Key);
                    this.cptRow++;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void addToPlaylist(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
