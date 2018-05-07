using XmasShop.Domain.Abstract;
using XmasShop.WebUI.Models;
using System.Linq;
using System.Web.Mvc;
using System.Threading;
using XmasShop.Domain.Entities;

namespace XmasShop.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 6;

        //dependency from IProductRepository
        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        public ViewResult List(string category, int page = 1)
        {
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsPartial = "true";
            }
                ProductsListViewModel model = new ProductsListViewModel()
                {
                    Products = repository.Products
                .Where(p => category == null || p.Category == category) //Если значение category не равно null, значит выбираем только те объекты продукт которые соотвествуют категории.
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemPerPage = PageSize,
                        TotalItem = category == null ?
                    repository.Products.Count() :
                    repository.Products.Where(e => e.Category == category).Count()
                    },

                    CurrentCategory = category
                };

                return View(model);
        }

        public FileContentResult GetImage(int productId)
        {
            Product prod = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (prod !=null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else { return null; }
        }


    }
}