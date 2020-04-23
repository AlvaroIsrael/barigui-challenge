using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace desafio_barigui.Models {
  public class CostumerItem {
    [Key] public long Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(100)")]
    public string Name { get; set; }

    [Required]
    [Column(TypeName = "varchar(11)")]
    public string Document { get; set; }

    [Required]
    [Column(TypeName = "varchar(100)")]
    public string CarModel { get; set; }

    [Required] [Column(TypeName = "int")] public int CarYear { get; set; }

    [Required]
    [Column(TypeName = "varchar(8)")]
    public string CarPlate { get; set; }
  }
}
