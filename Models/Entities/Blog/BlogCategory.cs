using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace Models.Entities.Blog
{
    public class BlogCategory
    {
        public BlogCategory()
        {

        }
        [Key]
        public int BlogCategoryId { get; set; }

        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string CategoryTitle { get; set; }

        [Display(Name = "حذف شده ؟")]
        public bool IsDelete { get; set; }

        [Display(Name = "گروه اصلی")]
        public int? ParentId { get; set; }


        #region Relations

        public virtual List<BlogSelectedCategory> BlogSelectedCategory { get; set; }

        #endregion


    }
}
