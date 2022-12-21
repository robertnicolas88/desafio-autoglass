using System;

namespace DesafioAutoGlass.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime ValidateDate { get; set; }
        public DateTime FabricationDate { get; set; }
        public string CodeProvider { get; set; }
        public string DescriptionProvider { get; set; }
        public string RegistryCodeProvider { get; set; }
        public bool Deleted { get; set; }
    }
}
