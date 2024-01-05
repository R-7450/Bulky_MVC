using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {
        [Key]                                   // this is data annotation for primary key;
        public int Id { get; set; }            // this will be our primary key
                                               // `[Required]` attribute is used to specify that a property or parameter is required and must have a value
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,1000,ErrorMessage ="Display Order must be between 1-1000.")]
        public int DisplayOrder { get; set; }
    }
}
