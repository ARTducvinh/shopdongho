using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace shopdongho.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public int CatId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Detail { get; set; }
        public string Metakey { get; set; }
        public string Metadese { get; set; }
        public string Img { get; set; }
        public int Number { get; set; }
        public double Price { get; set; }
        public double Pricesale { get; set; }
        public int? Create_by { get; set; }
        public DateTime? Create_at { get; set; }
        public int? Update_by { get; set; }
        public DateTime? Update_at { get; set; }
        public int Status { get; set; }
    }
}