using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {
        [Key]                                   // this is data annotation for primary key;
        public int Id { get; set; }            // this will be our primary key

        [Required]                             // `[Required]` attribute is used to specify that a property or parameter is required and must have a value
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
