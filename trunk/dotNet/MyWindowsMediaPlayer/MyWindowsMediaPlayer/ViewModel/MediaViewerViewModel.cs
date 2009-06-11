using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyWindowsMediaPlayer.Model;
using System.Windows.Forms;
using System.Data;

namespace MyWindowsMediaPlayer.ViewModel
{
    public class MediaViewerViewModel
    {
        private static MediaViewerViewModel instance = null;
        public TagReader model;
        public DataTable mediasInfo;
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
            this.mediasInfo = new DataTable();
            model = TagReader.getInstance();
            mediasInfo.Columns.Add("N°");
            mediasInfo.Columns.Add("Title");
            mediasInfo.Columns.Add("Artist");
            mediasInfo.Columns.Add("Album");
            mediasInfo.Columns.Add("Path");
            this.cptRow = 0;
        }

        public void updateList(object sender, TreeViewEventArgs e)
        {
            this.cptRow = 0;
            this.mediasInfo.Clear();
            try
            {
                foreach (TagLib.Id3v2.Tag tag in TagReader.getInstance().getTagsForPath(e.Node.Name))
                {
                    this.mediasInfo.Rows.Add();
                    this.mediasInfo.Rows[this.cptRow].SetField(this.mediasInfo.Columns["N°"], tag.Track);
                    this.mediasInfo.Rows[this.cptRow].SetField(this.mediasInfo.Columns["Title"], tag.Title);
                    this.mediasInfo.Rows[this.cptRow].SetField(this.mediasInfo.Columns["Artist"], tag.Artists[0]);
                    this.mediasInfo.Rows[this.cptRow].SetField(this.mediasInfo.Columns["Album"], tag.Album);
                    this.mediasInfo.Rows[this.cptRow].SetField(this.mediasInfo.Columns["Path"], e.Node.Name);
                    this.cptRow++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
