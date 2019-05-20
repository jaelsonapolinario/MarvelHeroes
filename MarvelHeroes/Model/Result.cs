using System;
using System.Collections.Generic;

namespace MarvelHeroes.Model
{
    public class Result
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Modified { get; set; }
        public Thumbnail Thumbnail { get; set; }
        public string ResourceURI { get; set; }
        public Attachment Comics { get; set; }
        public Attachment Series { get; set; }
        public Attachment Stories { get; set; }
        public Attachment Events { get; set; }
        public List<Link> Urls { get; set; }
    }
}
