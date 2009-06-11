using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TagLib;

namespace MyWindowsMediaPlayer.Model
{
    public class TagReader
    {
        private static TagReader instance = null;
        public Dictionary<string, TagLib.Id3v2.Tag> tags;
        public string path;

        public static TagReader getInstance()
        {
            if (instance == null)
            {
                instance = new TagReader();
            }
            return instance;
        }

        private TagReader()
        {
            this.tags = new Dictionary<string, TagLib.Id3v2.Tag>();
            path = DirectoryReader.getInstance().MediaPath;
        }

        public void fillTags()
        {
            String[] files = DirectoryReader.getInstance().getListMusicForPath(this.path);

            if (files.Length > 0)
                foreach (string file in files)
                {
                    tags.Add(file, this.getTagForTrack(file));
                }

        }

        public TagLib.Id3v2.Tag getTagForTrack(string path)
        {
            TagLib.File file = TagLib.File.Create(path);
            TagLib.Id3v2.Tag tag =
                                 file.GetTag(TagTypes.Id3v2, true)
                                 as TagLib.Id3v2.Tag;
            return tag;
        }
    }
}
