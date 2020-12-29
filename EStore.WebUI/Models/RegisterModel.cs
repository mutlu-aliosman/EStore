using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.WebUI.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="Lütfen Adınızı ve Soyadınızı giriniz.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Lütfen Kullanıcı adınızı giriniz.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen Şifre giriniz.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen Şifre giriniz.")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Şifreler Aynı Değil !")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "Lütfen Mail adresinizi giriniz.")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Lütfen geçerli bir adres giriniz !")]
        public string Email { get; set; }
    }
}
