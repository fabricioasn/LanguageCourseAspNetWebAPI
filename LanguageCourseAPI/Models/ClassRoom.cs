using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//model ORM class matching the "Turma" entity 

namespace LanguageCourseAPI.Models
{
    [Table("tbl_Turma")]
    public class ClassRoom
    {
        [Key]
        [Column("turma_ID")]
        public int Id { get; set; }
        /*business logic wich applies the string field 'Language' an length renge(max,min) 
         * and qualfies it as required content*/
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [DataType("varchar")]
        //defines the colum name as "Idioma"
        [Column("Idioma")]
        public string Language { get; set; }
        
        [MaxLength(10, ErrorMessage = "Este campo deve conter entre 3 e 10 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 10 caracteres")]
        [DataType("varchar")]
        [Column("Modulo")]
        public string Module { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}
