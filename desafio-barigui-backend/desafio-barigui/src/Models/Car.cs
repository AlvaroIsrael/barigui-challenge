using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace desafio_barigui.Models {
  public class Car {
    [Key] public string id { get; set; }

    [Required]
    [Column(TypeName = "varchar(100)")]
    public string name { get; set; }

    [Required] [Column(TypeName = "int")] public string yearModel { get; set; }
  }
}
