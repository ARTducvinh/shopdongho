
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shopdongho.Models
{
    [Table("GioHangs")]
    public class GioHang
    {
        [Key]
        public int Id { get; set; }
        public DonHang a { get; set; }
    }
}