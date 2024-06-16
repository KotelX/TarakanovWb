using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using TarakannovWb.Controllers;
using TarakannovWb.Models;

namespace TarakanovWb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Dishes = new TarakanovWbContext().Dishes.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Index(string name)
        {
            var context = new TarakanovWbContext();
            context.Dishes.Add(new Dishes() { Name = name });
            context.SaveChanges();
            ViewBag.Dishes = new TarakanovWbContext().Dishes.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Feeds(string userName, string email, string dishs)
        {
            if(string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(dishs)) {  return View("Index"); }
            ViewBag.isNewUser = false;
            var context = new TarakanovWbContext();
            var user = context.Users.FirstOrDefault(x => x.Name == userName && x.Email == email);
            if (user == null)
            {
                user = new User() { Name = userName, Email = email };
                ViewBag.isNewUser = true;
            }
            var dishes = context.Dishes.FirstOrDefault(x => x.Name == dishs);
            var eaten = new Eaten() { User = user, Dishes = dishes, Date = DateTime.Now};
            context.Eatens.Add(eaten);
            context.SaveChanges();
            ViewBag.ThisEatens = eaten;
            ViewBag.EatensThisAlready = context.Eatens.Include(x => x.User).Include(x => x.Dishes).Count(x => x.Dishes.Name == dishs && x.User.Name == userName && x.User.Email == email);
            ViewBag.EatensThisToday = context.Eatens.Include(u => u.Dishes).Count(x => x.Date.Day == DateTime.Today.Day && x.Date.Month == DateTime.Today.Month && x.Date.Year == DateTime.Today.Year && x.Dishes.Name == dishs);
            ViewBag.Eatens = context.Eatens.Include(u => u.User).Include(u => u.Dishes).Take(16).ToList();
            return View();
        }
    }
}