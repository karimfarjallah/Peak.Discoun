using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Peak.Discount.Model;
using Peak.Discount.Dashboard.Repository;
using Peak.Discount.Dashboard.ViewModels;
using System;
using System.IO;

namespace Peak.Discoun.Dashboard.Controllers
{
    [Authorize(Roles ="admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        public ProductController(IProductRepository productRepository, IHostingEnvironment hostingEnvironment)
        {
            _productRepository = productRepository;
            this.hostingEnvironment = hostingEnvironment;
        }
      
        // GET: Product
        public IActionResult Index()
        {
            var model = _productRepository.GetAllProduct();
            return View(model);
        }
 
        // GET: Product/Details/id
        public ActionResult Details(int id)
        {
            var product = _productRepository.GetProductById(id);
            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        public String FileName(CreateProductModelView product)
        {
            string uniqueFileName = null;
            if (product.Image != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");

                uniqueFileName = Guid.NewGuid().ToString() + "_" + product.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                product.Image.CopyTo(new FileStream(filePath, FileMode.Create));
            }
            return uniqueFileName;
        }


        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateProductModelView product)
        {
            string uniqueFileName = FileName(product);

            if (ModelState.IsValid)
            {
                Product newProduct = new Product
                {
                    Name = product.Name,
                    Description = product.Description,
                    Stock = product.Stock,
                    Price = product.Price,
                    ImagePath = uniqueFileName
                };

                _productRepository.Add(newProduct);
                return RedirectToAction("details", new { id = newProduct.Id });
            }

            return View();
        }
       
        // GET: Product/Edit/id
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = _productRepository.GetProductById(id);
            var viewModel = new CreateProductModelView
            {   Id=product.Id,
                Name = product.Name,
                Description = product.Description,
                Stock = product.Stock,
                Price = product.Price,
                ImagePath = product.ImagePath
            };
            return View(viewModel);
        }

        // POST: Product/Edit/id

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(CreateProductModelView product)
        {
            string uniqueFileName = FileName(product);

            if (ModelState.IsValid)
            {
                Product EditProduct = new Product
                {   Id=product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Stock = product.Stock,
                    Price = product.Price,
                    ImagePath = uniqueFileName
                };


                _productRepository.Update(EditProduct);
          
                return RedirectToAction("Index" , "Product");

            }
            else
            {
                return View(product);
            }
        }

        // GET: Product/Delete/id
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var product = _productRepository.GetProductById(id);
            return View(product);
        }

        // POST: Product/Delete/id
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            _productRepository.Delete(id);
            return RedirectToAction("Index", "Product");
        }


    }
}
