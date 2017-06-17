using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Google.Apis.YouTube.v3;
using Google.Apis.Services;
using WWBG.Models;

namespace WWBG.Controllers
{
    public class HomeController : Controller
    {



        public ActionResult LiveYouTube()
        {
       

            return View();
        }
        public ActionResult YouTubeVideos()
        {
            Video model = new Video();
            var list = ListProfile();
           
            model.info = list;
          
            
            return View(model);
        }
        public ActionResult Fixture()
        {
            
            return View();
        }
        public ActionResult LearningResources()
        {
            
            return View();
        }
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            Video model = new Video();
            var list = ListProfile();
           
            model.info = list;
          
            
            return View(model);
          

        }
              public List<Video> ListProfile()
        {
            Video model = new Video();
            YouTubeService yt = new YouTubeService(new BaseClientService.Initializer() { ApiKey = "AIzaSyBmoq4BYgfkMLGFl3bxhoRLyF2Z7Ld0tRM" });


            var searchListRequest = yt.Search.List("snippet");
            searchListRequest.ChannelId = "UCuBQGeSiAZQzmqs43Qd82kw";
            searchListRequest.MaxResults = 50;
            var searchListResult = searchListRequest.Execute();
            List<Video> listProfile = new List<Video>();

            foreach (var item in searchListResult.Items)
            {
                
                model.VideoId = item.Id.VideoId;
                model.Title = item.Snippet.Title;
                listProfile.Add(model);

                ViewBag.videoid = model.VideoId;
                ViewBag.vid = model.Title;

            }
            return listProfile;
           
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    
    
}
}