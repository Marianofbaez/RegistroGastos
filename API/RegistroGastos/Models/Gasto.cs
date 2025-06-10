using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroGastos.Models
{
    public class Gasto
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Monto { get; set; }
        [MaxLength(250)]
        [Column(TypeName = "varchar(250)")]
        public string Descripcion { get; set; }
        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }
        [MaxLength(250)]
        [Column(TypeName = "varchar(250)")]
        public string NombreComercio { get; set; }
    }
}
