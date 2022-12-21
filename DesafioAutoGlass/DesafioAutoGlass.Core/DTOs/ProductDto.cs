using System;
using System.ComponentModel.DataAnnotations;

namespace DesafioAutoGlass.Application.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime ValidateDate { get; set; }
        public DateTime FabricationDate { get; set; }
        public string CodeProvider { get; set; }
        public string DescriptionProvider { get; set; }
        public string RegistryCodeProvider { get; set; }

    }
}
