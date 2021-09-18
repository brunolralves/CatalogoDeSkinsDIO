
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoDeSkinsDIO.DTO.InputModel
{
    public class SkinInputModel
    {
        [Required]
        [StringLength(100,MinimumLength =3,ErrorMessage ="Nome da Skin deve conter entre 3 e 100 caracteres")]
        public string Name { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Nome do pacote deve conter entre 3 e 100 caracteres")]
        public string PackageName { get; set; }

        [Required]
        [Range(1,5000, ErrorMessage = "O preço em valorant points deve ser no minimo 1 VP e no maximo 5000 VP")]
        public double Price { get; set; }
    }
}
