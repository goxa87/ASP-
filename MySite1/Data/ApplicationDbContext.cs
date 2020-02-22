using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MySite1.Auth;
using MySite1.Models;

namespace MySite1.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        /// <summary>
        /// мои работы
        /// </summary>
        public DbSet<Work> Works { get; set; }
        /// <summary>
        /// комментарии к работам
        /// </summary>
        public DbSet<CommentWork> CommentWorks { get; set; }
        /// <summary>
        /// картинки к работам
        /// </summary>
        public DbSet<WorkPicture> WorkPictures { get; set; }

        /// <summary>
        /// Посты в блоге
        /// </summary>
        public DbSet<BlogPost> BlogPosts { get; set; }
        /// <summary>
        /// комментарии к блогу
        /// </summary>
        public DbSet<CommentBlog> CommentBlogs { get; set; }
        /// <summary>
        /// сообщения из контактов
        /// </summary>
        public DbSet<ContactMessage> ContactMessages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(
                @"Server=.\SQLEXPRESS;DataBase=MySite1;Trusted_Connection=True;"
                );
        }
    }
}
