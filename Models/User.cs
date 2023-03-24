using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace shopdongho.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Conten { get; set; }

        [Display(Name ="Tên Đăng Nhập")]
        [Required(ErrorMessage ="Nhập Tài Khoản")]
        public string UserName { get; set; }

        
        [Required(ErrorMessage = "Nhập Mật Khẩu")]
        [Display(Name = "Mật Khẩu")]
        public string Pass { get; set; }
        public int Roles { get; set; }
    }
}