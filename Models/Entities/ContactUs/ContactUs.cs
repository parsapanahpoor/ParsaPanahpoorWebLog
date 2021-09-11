using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Entities.ContactUs
{
    public class ContactUs
    {
        [Key]
        public int ContactUsID { get; set; }

        [Display(Name = "نام  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string UserName { get; set; }

        [Display(Name = "ایمیل  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Emial { get; set; }

        [Display(Name = "موبایل  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string PhoneNumber { get; set; }

        [Display(Name = "متن پیام   ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string MessageContent { get; set; }
    }
}
