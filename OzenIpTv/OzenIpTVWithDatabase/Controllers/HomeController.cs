using OzenIpTVWithDatabase.Database;
using OzenIpTVWithDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OzenIpTVWithDatabase.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCategoryList()
        {
            List<Category> categoryList = new List<Category>();

            using (ProjectDbContext _db = new ProjectDbContext())
            {
                categoryList = _db.Categories.ToList();
            }

            List<CategoryDTO> categoryDTOList = new List<CategoryDTO>();

            foreach (Category item in categoryList)
            {
                categoryDTOList.Add(new CategoryDTO() { ID = item.ID, Name = item.Name });
            }

            return Json(categoryDTOList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetChannelList(string channelName, int categoryID)
        {
            List<Channel> channelList = new List<Channel>();

            if ((string.IsNullOrEmpty(channelName) || string.IsNullOrWhiteSpace(channelName)) && categoryID == 0)
            {
                List<ChannelDTO> channelDTOList = new List<ChannelDTO>();

                using (ProjectDbContext _db = new ProjectDbContext())
                {
                    channelList = _db.Channels.ToList();


                    foreach (Channel item in channelList)
                    {
                        channelDTOList.Add(new ChannelDTO() { Name = item.Name, CategoryName = item.Category.Name });
                    }
                }

                return Json(channelDTOList, JsonRequestBehavior.AllowGet);
            }
            else if ((!string.IsNullOrEmpty(channelName) || !string.IsNullOrWhiteSpace(channelName)) && categoryID == 0)
            {
                List<ChannelDTO> channelDTOList = new List<ChannelDTO>();

                using (ProjectDbContext _db = new ProjectDbContext())
                {
                    channelList = _db.Channels.Where(a => a.Name.Contains(channelName)).ToList();


                    foreach (Channel item in channelList)
                    {
                        channelDTOList.Add(new ChannelDTO() { Name = item.Name, CategoryName = item.Category.Name });
                    }
                }

                return Json(channelDTOList, JsonRequestBehavior.AllowGet);
            }
            else if ((string.IsNullOrEmpty(channelName) || string.IsNullOrWhiteSpace(channelName)) && categoryID != 0)
            {
                List<ChannelDTO> channelDTOList = new List<ChannelDTO>();

                using (ProjectDbContext _db = new ProjectDbContext())
                {
                    channelList = _db.Channels.Where(a => a.CategoryID == categoryID).ToList();


                    foreach (Channel item in channelList)
                    {
                        channelDTOList.Add(new ChannelDTO() { Name = item.Name, CategoryName = item.Category.Name });
                    }
                }

                return Json(channelDTOList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<ChannelDTO> channelDTOList = new List<ChannelDTO>();

                using (ProjectDbContext _db = new ProjectDbContext())
                {
                    channelList = _db.Channels.Where(a => a.CategoryID == categoryID && a.Name.Contains(channelName)).ToList();


                    foreach (Channel item in channelList)
                    {
                        channelDTOList.Add(new ChannelDTO() { Name = item.Name, CategoryName = item.Category.Name });
                    }
                }

                return Json(channelDTOList, JsonRequestBehavior.AllowGet);
            }
        }
    }
}