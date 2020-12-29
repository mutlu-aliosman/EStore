using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.WebUI.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Kullanıcı adınızı giriniz !")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Şifrenizi giriniz !")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
