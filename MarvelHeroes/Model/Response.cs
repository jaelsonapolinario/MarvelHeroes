using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MarvelHeroes.Model
{
    public class Response
    {
        public int Code { get; set; }
        public string Status { get; set; }
        public string Copyright { get; set; }
        public string AttributionText { get; set; }
        public string AttributionHTML { get; set; }
        public string Etag { get; set; }
        public Data Data { get; set; }
    }
}

