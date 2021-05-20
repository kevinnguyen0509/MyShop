using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.Core3.Models;
using MyShop.Core3.ViewModels;
using MyShop.DataAccess.InMemory3;
    

namespace MyShop.WebUI3.Controllers
{
    public class ProductManagerController : Controller
    {
        ProductRepository context;
        ProductCategoryRepository productCatorgories;
        public ProductManagerController()
        {
            context = new ProductRepository();
            productCatorgories = new ProductCategoryRepository();
        }
        // GET: ProductManager
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }

        public ActionResult Create()
        {
            ProductManagerViewModel viewModel = new ProductManagerViewModel();


            viewModel.Product = new Product();
            viewModel.ProductCategories = productCatorgories.Collection();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                context.Insert(product);
                context.Commit();
                return RedirectToAction("Index");
            }
            
        }

        public ActionResult Edit(string Id)
        {
            Product product = context.Find(Id);

            if(product == null)
            {
                return HttpNotFound();
            }

            else
            {
                ProductManagerViewModel viewModel = new ProductManagerViewModel();
                viewModel.Product = product;
                viewModel.ProductCategories = productCatorgories.Collection();
                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit (Product product, string Id)
        {
            Product productToEdit = context.Find(product.Id);
            if (productToEdit == null)
            {
                return HttpNotFound();
            }

            else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }
                
                productToEdit.Category = product.Category;
                productToEdit.Description = product.Description;
                productToEdit.Name = product.Name;
                productToEdit.Price = product.Price;
                productToEdit.Image = product.Image;

                context.Commit();
                return RedirectToAction("Index");

            }
            
        }

        public ActionResult Delete(string Id)
        {
            Product productDelete = context.Find(Id);

            if (productDelete == null)
            {
                return HttpNotFound();
            }

            else
            {
                return View(productDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Product productToDelete = context.Find(Id);

            if (productToDelete == null)
            {
                return HttpNotFound();
            }

            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }

        }
    }
}