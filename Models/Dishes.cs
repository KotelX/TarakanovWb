using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TarakannovWb.Controllers;

namespace TarakannovWb.Models
{
    public class Dishes
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
    }
}