﻿using BRMDataManager.Library.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BRMDataManager.Controllers
{

    [Authorize]
    [RoutePrefix("api/User")]
    public class UserController : Controller
    {

        // GET: User/Details/5
        public ActionResult GetById(string id)
        {
            UserData

            return View();
        }

    }
}
