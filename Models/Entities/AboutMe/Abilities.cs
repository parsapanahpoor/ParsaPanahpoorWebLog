using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Entities.AboutMe
{
    public class Abilities
    {

        public Abilities()
        {

        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "نام تخصص ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string AbilityName { get; set; }

        [Display(Name = "درصد پیشرفت  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string AbilityPercent { get; set; }
    }
}
