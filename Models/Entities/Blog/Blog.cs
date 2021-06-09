using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Entities
{
    public  class Blog
    {
        public Blog()
        {

        }

        [Key]
        public int BlogId { get; set; }


    }
}
