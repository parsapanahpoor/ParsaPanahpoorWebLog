using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Entities.AboutMe
{
    public  class AboutMe
    {
        public AboutMe()
        {

        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "نام برنامه نویس ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string UserName { get; set; }


        [Display(Name = "نام تخصص ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string JobAbility { get; set; }


        [Display(Name = "ایمیل ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Email { get; set; }


        [Display(Name = "تلفن همراه  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string PhoneNumber { get; set; }

        [MaxLength(50)]
        public string AvatarName { get; set; }

        [Display(Name = "شرح کامل  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string LongDescription { get; set; }


    }
}
