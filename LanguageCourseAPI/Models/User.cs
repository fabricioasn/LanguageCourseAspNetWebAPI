using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//model ORM class matching the "Usuário" entity 

namespace LanguageCourseAPI.Models
{
    [Table("Usuario")]
    public class User
    {
        [Key]
        [Column("User_ID")]
        public int Id { get; set; }

        /*business logic wich applies the string field 'Username' an length renge(max,min) 
        * and qualfies it as required content*/
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [MaxLength(20, ErrorMessage = "Este campo deve conter entre 3 e 20 caracteres.")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 20 caracteres.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [MaxLength(20, ErrorMessage = "Este campo deve conter entre 3 e 20 caracteres.")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 20 caracteres.")]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}
