using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RSSReader.DAL;
using RSSReader.Models;

namespace RSSReader.Controllers
{
    public class HomeController : Controller
    {
        NewsContext db = new NewsContext();
        public ActionResult Index(int page=1, string sourceName="Все", SortState sortOrder = SortState.Name)
        {
            int pageSize = 10;
            int newsBefore = db.News.Count();
            NewsUpdate.Update(db, db.Sources.Find(1));
            NewsUpdate.Update(db, db.Sources.Find(2));
            int newsUpdated = db.News.Count();
            ViewBag.NewsAdded = newsUpdated - newsBefore;
            ViewBag.NewsSum = newsUpdated;
            IQueryable<News> news = db.News.Include(p => p.SourceObj);
            if (!String.IsNullOrEmpty(sourceName) && !sourceName.Equals("Все"))
            {
                news = news.Where(p => p.Source == sourceName);
            }

            switch (sortOrder)
            {
                case SortState.Name:
                    news = news.OrderBy(s => s.Source);
                    break;
                case SortState.Date:
                    news = news.OrderBy(s => s.PublicationTime);
                    break;
                default:
                    news = news.OrderBy(s => s.Source);
                    break;
            }

            var count = news.Count();
            var items = news
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            NewsListViewModel nlvm = new NewsListViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(db.Sources.ToList(), sourceName),
                News = items
            };
            return View(nlvm);
        }
    }
}