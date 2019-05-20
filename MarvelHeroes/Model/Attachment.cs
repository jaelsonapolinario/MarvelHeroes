using System;
using System.Collections.Generic;

namespace MarvelHeroes.Model
{
    public class Attachment
    {
        public int Available { get; set; }
        public string CollectionURI { get; set; }
        public List<Reference> Items { get; set; }
        public int Returned { get; set; }
        public double Height
        {
            get
            {
                return this.Items.Count * 30;
            }
        }
    }
}
