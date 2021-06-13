using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Entities.Sldier
{
    public  class Slider
    {
        public Slider()
        {

        }

        [Key]
        public int SliderId { get; set; }

        [MaxLength(50)]
        public string SliderImageName { get; set; }

        [Display(Name = " متن  ")]
        public string SliderText { get; set; }
    }
}
