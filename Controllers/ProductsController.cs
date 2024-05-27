using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ST10303347_CLDV6211POE2024.Data;
using ST10303347_CLDV6211POE2024.Data.Enum;
using ST10303347_CLDV6211POE2024.Data.myMethods;
using ST10303347_CLDV6211POE2024.Models;


namespace ST10303347_CLDV6211POE2024.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly Productmethods _myMethods;

        public ProductsController(Productmethods myMethods)
        {
            _myMethods = myMethods;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _myMethods.GetAll();
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.products
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.productId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            //ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
           
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( ViewProductsModel pro)

        {
           

            
            
          
            if (pro.Image != null) {

                string fileName = Path.GetFileName(pro.Image.FileName);
                var imagesDirec = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ProductImages", fileName);

                using (var fileStream = new FileStream(imagesDirec, FileMode.Create))
                {
                    await pro.Image.CopyToAsync(fileStream);
                }

                Product ProObj = new Product
                {

                    Name = pro.Name,
                    Price = pro.Price,
                    Category = pro.Category,
                    Availability = pro.Availability,
                    Description = pro.Description,
                    ImagePath = imagesDirec,
                    IdentityUserId = pro.IdentityUserId


                };
               //var result = p10.insert_product(ProObj);
               await _myMethods.Add(ProObj);   
                return RedirectToAction("Index");

            }

            
            return View(pro);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", product.IdentityUserId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("productId,Name,Price,Category,Availability,Description,ImagePath,IdentityUserId")] Product product)
        {
            if (id != product.productId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.productId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", product.IdentityUserId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.products
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.productId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.products.FindAsync(id);
            if (product != null)
            {
                _context.products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.products.Any(e => e.productId == id);
        }
    }
}
