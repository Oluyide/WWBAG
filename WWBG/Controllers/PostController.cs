using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WWBG.Filters;

namespace WWBG.Controllers
{
    [InitializeSimpleMembership]
    
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            return View();
        }
    }
}