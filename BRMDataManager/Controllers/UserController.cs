﻿using BRMDataManager.Library.DataAccess;
using BRMDataManager.Library.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BRMDataManager.Controllers
{

    [Authorize]
    public class UserController : ApiController
    {

        [HttpGet]
        public UserModel GetById()
        {
            string userId = RequestContext.Principal.Identity.GetUserId();
            UserData data = new UserData();

            return data.GetUserById(userId).First();
        }

    }
}
