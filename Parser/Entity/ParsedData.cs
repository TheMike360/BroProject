using Microsoft.EntityFrameworkCore;
using Parser.Enums;
using System.ComponentModel.DataAnnotations;

namespace Parser.Entity
{
    [Index(nameof(Time),nameof(HeaderText))]
    public class ParsedData
    {
        [Key]
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string HeaderText { get; set; }
        public string PostText { get; set; }
        [StringLength(50)]
        public string Category { get; set; }
        public CategoryEnum CategoryId { get; set; }
        public DateTime? PostedTime { get; set; }
        [StringLength(250)]
        public string SourceUrl { get; set; }
        public CountriesEnum Countries { get; set; }
    }
}
