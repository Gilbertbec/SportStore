using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vic.SportsStore.Domain.Abstract;
using Vic.SportsStore.Domain.Entities;
using Vic.SportsStore.WebApp.Models;

namespace Vic.SportsStore.WebApp.Controllers
{
    //public class ProductController : Controller
    //{
    //    // GET: Product
    //    public ActionResult Index()
    //    {
    //        return View();
    //    }

    //    private IProductsRepository repository;
    //    public ProductController(IProductsRepository productRepository)
    //    {
    //        this.repository = productRepository;
    //    }

    //    public ViewResult List()
    //    {
    //        return View(repository.Products);
    //    }
    //}

    public class ProductController : Controller
    {
        private IProductsRepository repository;
        public int PageSize = 2;
        public ProductController(IProductsRepository productRepository)
        {
            this.repository = productRepository;
        }
        //public ViewResult List(int page = 1)
        //{
        //    return View(
        //    repository
        //    .Products
        //    .OrderBy(p => p.ProductID)
        //    .Skip((page - 1) * PageSize)
        //    .Take(PageSize));
        //}

        //public ViewResult List(int page = 1)
        //{
        //    ProductsListViewModel model = new ProductsListViewModel
        //    {
        //        Products = repository
        //    .Products
        //    .OrderBy(p => p.ProductID)
        //    .Skip((page - 1) * PageSize)
        //    .Take(PageSize),
        //        PagingInfo = new PagingInfo
        //        {
        //            CurrentPage = page,
        //            ItemsPerPage = PageSize,
        //            TotalItems = repository.Products.Count()
        //        }
        //    };
        //    return View(model);
        //}

        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository
            .Products
            .Where(p => category == null || p.Category == category)
            .OrderBy(p => p.ProductID)
            .Skip((page - 1) * PageSize)
            .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null
? repository.Products.Count()
: repository.Products.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }

        public FileContentResult GetImage(int productId)
        {
            Product prod = repository
            .Products
            .FirstOrDefault(p => p.ProductID == productId);
            if (prod != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }


}