using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TarakannovWb.Models;

namespace TarakannovWb.Controllers
{
    public class Eaten
    {
        [Key]
        public int Id { get; set; }
        public User User { get; set; }
        public Dishes Dishes { get; set; }
        public DateTime Date { get; set; }
    }
}