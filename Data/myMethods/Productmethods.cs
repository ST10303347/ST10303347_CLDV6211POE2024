using Microsoft.EntityFrameworkCore;
using ST10303347_CLDV6211POE2024.Models;
using System.Reflection;

namespace ST10303347_CLDV6211POE2024.Data.myMethods
{
    public class Productmethods
    {

        private readonly ApplicationDbContext _context;

        public Productmethods(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Product pro1)
        {
            _context.products.Add(pro1);
            await _context.SaveChangesAsync();
        }
        public IQueryable<Product> GetAll()
        {
            var applicationDbContext = _context.products.Include(p => p.User);
            return applicationDbContext;
        }

    }
}
