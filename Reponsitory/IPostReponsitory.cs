using Blog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog
{
    public interface IPostReponsitory
    {
        Task Add(Post post);

        bool Exits(int id);

        Task Update(Post post);

        Task Remove(int id);

        Task<Post> FindById(int id);

        Task<List<Post>> GetAll();
    }
    public class PostReponsitory : IPostReponsitory
    {
        private NewContext context;
        public PostReponsitory(NewContext _context)
        {
            context = _context;
        }
        public async Task Add(Post post)
        {
            context.Add(post);
            await context.SaveChangesAsync();
        }

        public bool Exits(int id)
        {
            Post post = context.Posts.Find(id);
            if (post != null)
            {
                return true;
            }
            return false;
        }

        public async Task<Post> FindById(int id)
        {
            Post post = await context.Posts.FindAsync(id);
            return post;
        }

        public async Task<List<Post>> GetAll()
        {
            return await context.Posts.ToListAsync();
        }

        public async Task Remove(int id)
        {
            Post post = await context.Posts.FindAsync(id);
            context.Remove(post);
            await context.SaveChangesAsync();
        }

        public async Task Update(Post post)
        {
            Post postnew = await context.Posts.FindAsync(post.ID);
            postnew = post;
            //context.Update(post);
            await context.SaveChangesAsync();
        }


    }
}
