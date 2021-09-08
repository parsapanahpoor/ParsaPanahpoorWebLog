using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Entities.Projects
{
    public class Project
    {

        public Project()
        {

        }



        [Key]
        public int Id { get; set; }

        [Display(Name = "عنوان   ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string ProjectTitle { get; set; }

        [MaxLength(600)]
        public string Tags { get; set; }


        [Required]
        public string CreateDate { get; set; }
        [MaxLength(50)]
        public string ProductImageName { get; set; }

    }
}
