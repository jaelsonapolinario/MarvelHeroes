using System;
namespace MarvelHeroes.Model
{
    public class Thumbnail
    {
        public string Path { get; set; }
        public string Extension { get; set; }
        public string PathFormatted
        {
            get
            {
                return string.Format("{0}/portrait_medium.{1}", this.Path, this.Extension);
            }
        }
        public string PathStandardXlarge
        {
            get
            {
                return string.Format("{0}/standard_xlarge.{1}", this.Path, this.Extension);
            }
        }
    }
}
