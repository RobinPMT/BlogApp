using Blog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog
{
    public interface ICategoryReponsitory
    {
        Task Add(Category category);

        bool Exits(int id);

        Task Update(Category category);

        Task Remove(int id);

        Task<Category> FindById(int id);

        Task<List<Category>> GetAll();
    }
    public class CategoryReponsitory : ICategoryReponsitory
    {
        private NewContext context;
        public CategoryReponsitory(NewContext _context)
        {
            context = _context;
        }
        public async Task Add(Category category)
        {
            context.Add(category);
            await context.SaveChangesAsync();
        }

        public bool Exits(int id)
        {
            Category category = context.Categories.Find(id);
            if (category != null)
            {
                return true;
            }
            return false;
        }

        public async Task<Category> FindById(int id)
        {
            Category category = await context.Categories.FindAsync(id);
            return category;
        }

        public async Task<List<Category>> GetAll()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task Remove(int id)
        {
            Category category = await context.Categories.FindAsync(id);
            context.Remove(category);
            await context.SaveChangesAsync();
        }

        public async Task Update(Category category)
        {
            Category categorynew = await context.Categories.FindAsync(category.ID);
            categorynew = category;
            //context.Update(post);
            await context.SaveChangesAsync();
        }
    }
}
