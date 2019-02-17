using Microsoft.AspNetCore.Mvc;
using System.Linq;
using SportsStore.Models;
using SportShop.Models;

namespace SportsStore.Components
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private IProductRepository repository;

        public CategoryMenuViewComponent(IProductRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}