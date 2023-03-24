using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace shopdongho.Models
{
    [Table("DonHangs")]
    public class DonHang
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FullNameUser { get; set; }
        public int DiaChi { get; set; }
        public string Phone { get; set; }
        public string TenSanPham { get; set; }
        public string MoTaSanPham { get; set; }
        public string Img { get; set; }
        public DateTime? Create_at { get; set; }       
        public int Status { get; set; }
    }
}