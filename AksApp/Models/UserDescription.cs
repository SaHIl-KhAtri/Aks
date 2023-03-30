using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AksApp.Models
{
    public class UserDescription
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Heading { get; set; }
        public string description { get; set; }

    }


}
