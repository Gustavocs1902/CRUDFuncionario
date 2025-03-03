using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class FuncionariosDb
    {
        [Key] // Define a propriedade como chave primária
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; } = "";

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        public string Telefone { get; set; } = "";

        [Required(ErrorMessage = "O RG é obrigatório.")]
        public string RG { get; set; } = "";

        [Required(ErrorMessage = "O endereço é obrigatório.")]
        public string Endereco { get; set; } = "";

        [Required(ErrorMessage = "O salário é obrigatório.")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Salario { get; set; }

        [Required(ErrorMessage = "As horas extras são obrigatórias.")]
        [Range(0, int.MaxValue, ErrorMessage = "As horas extras não podem ser negativas.")]
        public int HorasExtras { get; set; }

    }
}
