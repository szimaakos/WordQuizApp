using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordQuizApp.Models;

namespace WordQuizApp.Data
{
    public class QuizDbContext : DbContext
    {
        public DbSet<Word> Words { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=quizapp.db");
        }
    }
}
