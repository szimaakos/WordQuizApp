using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordQuizApp.Models
{
    public class Word
    {
        [Key]
        public int Id { get; set; }
        public string ForeignWord { get; set; }
        public string Translation { get; set; }
        public int TimesCorrect { get; set; }
    }
}
