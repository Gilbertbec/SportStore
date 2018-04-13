using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vic.SportsStore.WebApp.Models
{
    public class CartIndexViewModel
    {
        public Domain.Entities.Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}