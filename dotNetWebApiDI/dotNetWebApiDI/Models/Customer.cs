using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace dotNetWebApiDI.Models
{
    [Table("CUSTOMERS")]
    public class Customer
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public int FirstName { get; set; }
    }
}