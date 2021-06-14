using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Entities.Sldier
{
  public   class Baner
    {
        public Baner()
        {

        }

        [Key]
        public int BanerId { get; set; }

        [MaxLength(50)]
        public string BanerImageName { get; set; }


    }
}
