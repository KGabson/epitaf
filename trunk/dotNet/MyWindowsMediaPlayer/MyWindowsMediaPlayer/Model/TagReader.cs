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

        public static TagReader getInstance()
        {
            if (instance == null)
            {
                instance = new TagReader();
            }
            return instance;
        }

        public TagLib.Id3v2.Tag[] getTagsForPath(string path)
        {
            List<TagLib.Id3v2.Tag> tags = new List<TagLib.Id3v2.Tag>();
            String[] files = DirectoryReader.getInstance().getListMusicForPath(path);

            foreach (string file in files)
            {
                tags.Add(this.getTagForTrack(file));
            }
            return tags.ToArray();
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
