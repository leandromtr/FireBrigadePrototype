﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MapaDaForca.Controllers
{
    public class TipoEscalaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}