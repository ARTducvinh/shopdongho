using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shopdongho.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public int? Orders { get; set; }
        public string Slug { get; set; }
        public string Metakey { get; set; }
        public string Metadese { get; set; }
        public int? Create_by { get; set; }
        public DateTime? Create_at { get; set; }
        public int? Update_by { get; set; }
        public DateTime? Update_at { get; set; }
        public int Status { get; set; }
    }
}