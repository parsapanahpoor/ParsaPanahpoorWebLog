using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Entities.ContactUs
{
    public class ContactUs
    {
        public ContactUs()
        {

        }
        [Key]
        public int ID { get; set; }

        [Display(Name = "نام  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string UserName { get; set; }

        [Display(Name = "ایمیل  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Email { get; set; }

        [Display(Name = "موبایل  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string PhoneNumber { get; set; }

        [Display(Name = "متن پیام   ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string MessageContent { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }
    }
}
