namespace Vic.SportsStore.WebApp.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Vic.SportsStore.Domain.Abstract;
    using Vic.SportsStore.Domain.Entities;
    using Vic.SportsStore.WebApp.Models;

    public class ProductController : Controller
    {
        public int PageSize = 2;

        private IProductsRepository repository;

        public ProductController(IProductsRepository productRepository)
        {
            this.repository = productRepository;
        }

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
