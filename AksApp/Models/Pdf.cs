using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AksApp.Models
{

    public class Pdf
    {
        
        public string pdfId { get; set; }   
        public string heading { get; set; }
        public string pdfPath { get; set; }



        // Navigation property


    }
}
