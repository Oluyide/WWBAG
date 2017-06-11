using Google.GData.Client;
using Google.YouTube;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WWBG.Models
{
    public class Video
    {
        public string VideoId { get; set; }
        public string Title { get; set; }

        public List<Video> info { get; set; }

    }
 

   
}