﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewsletterAppMVC.Models;
using NewsletterAppMVC.Models.ViewModels;

namespace NewsletterAppMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (Newsletter1Entities db = new Newsletter1Entities())
            {
                //var signups = db.SignUps.Where(x => x.Removed == null).ToList();
                var signups = (from c in db.SignUps
                    where c.Removed == null
                    select c).ToList();
                var signupVms = new List<SignupVM>();
                foreach (var signup in signups)
                {
                    var signupVm = new SignupVM();
                    signupVm.Id = signup.Id;
                    signupVm.FirstName = signup.FirstName;
                    signupVm.LastName = signup.LastName;
                    signupVm.EmailAddress = signup.EmailAddress;

                    signupVms.Add(signupVm);

                }
                return View(signupVms);
            }
        }

        public ActionResult Unsubscribe(int Id)
        {
            using (Newsletter1Entities db = new Newsletter1Entities())
            {
                var signup = db.SignUps.Find(Id);
                signup.Removed = DateTime.Now;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}