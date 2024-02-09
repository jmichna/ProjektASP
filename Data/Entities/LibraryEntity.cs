using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("library")]
    public class LibraryEntity
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Autor { get; set; }

        [Required]
        [Column("page_number")]
        public int PageNumber { get; set; }

        [MinLength(17)]
        [MaxLength(17)]
        [Required]
        public string ISBN { get; set; }

        [Required]
        [Column("date_of_release")]
        public DateTime DateOfRelease { get; set; }

        [Column("publishing_house_id")]
        public int PublishingHouseId { get; set; }

        [Column("publishing_house")]
        public PublishingHouseEntity? PublishingHouse { get; set; }

        [Required]
        [Column("rating")]
        public int Rating { get; set; }

        //gdzie masz klucz zewnetrzny do nastepnej tabeli?
        // mówisz o tym, że nie ma jakby FK przypisanego tak? tak i druga tabela nie ma klucza gównego
        //gerneralnie to jako tabela podrzędna do tej to miała być ta publishing a ja ci tylko do jednej dodałem a reszta nie ma nic to jak to madziałac?


    }
}
