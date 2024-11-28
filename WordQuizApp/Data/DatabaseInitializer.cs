using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordQuizApp.Models;

namespace WordQuizApp.Data
{
    public static class DatabaseInitializer
    {
        public static void Initialize()
        {
            using (var context = new QuizDbContext())
            {
                // Az adatbázis létrehozása, ha még nem létezik
                context.Database.EnsureCreated();

                // Ellenőrizzük, hogy van-e már adat az adatbázisban
                if (!context.Words.Any())
                {
                    // Ha nincs adat, adjunk hozzá alapértelmezett szavakat
                    context.Words.AddRange(
                        new Word { ForeignWord = "hello", Translation = "szia", TimesCorrect = 0 },
                        new Word { ForeignWord = "apple", Translation = "alma", TimesCorrect = 0 },
                        new Word { ForeignWord = "table", Translation = "asztal", TimesCorrect = 0 },
                        new Word { ForeignWord = "house", Translation = "ház", TimesCorrect = 0 },
                        new Word { ForeignWord = "dog", Translation = "kutya", TimesCorrect = 0 },
                        new Word { ForeignWord = "cat", Translation = "macska", TimesCorrect = 0 },
                        new Word { ForeignWord = "car", Translation = "autó", TimesCorrect = 0 },
                        new Word { ForeignWord = "book", Translation = "könyv", TimesCorrect = 0 },
                        new Word { ForeignWord = "pen", Translation = "toll", TimesCorrect = 0 },
                        new Word { ForeignWord = "computer", Translation = "számítógép", TimesCorrect = 0 }
                    );

                    // Változtatások mentése az adatbázisba
                    context.SaveChanges();
                }
            }
        }
    }
}
