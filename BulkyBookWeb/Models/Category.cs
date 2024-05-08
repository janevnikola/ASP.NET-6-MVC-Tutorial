
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        [Key] //primaren kluc
        public int Id { get; set; } //id na kategorijata

        [Required] //zadolzitelen property odnosno da ne e null (isto kako NOT NULL)
        public string Name { get; set; } //imeto na kategorijata

        [DisplayName("Display Order")]
        [Range(1,100, ErrorMessage ="Display order must be between 1 and 100 only")]
        public int DisplayOrder { get; set; } //orderot na prikazuvanje
        public DateTime CreatedDateTime { get; set; } = DateTime.Now; //datumot na kreiranje na kategorijata, 
                                                                       //default vrednosta e DateTime.Now odnosno vo momentot
                                                                       //ke se kreira kategorijata
    }
}
