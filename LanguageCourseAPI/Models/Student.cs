using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*model ORM class matching the "Aluno" entity relationed to Classrooom "turma" entity 
 * has 1 classroom to many student */

namespace LanguageCourseAPI.Models
{
    [Table("tbl_Aluno")]
    public class Student
    {        
        [Key]
        [Column("estudante_ID")]
        public int ID { get; set; }
        /*business logic wich applies the string field 'Name' an length renge(max,min) 
        * and qualfies it as required content*/
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Este campo deve conter entre 10 e 100 caracteres.")]
        [MinLength(10, ErrorMessage = "Este campo deve conter entre 10 e 100 caracteres.")]
        [DataType("varchar")]
        [Column("Nome_Completo")]
        public string FullName { get; set; }

        [MaxLength(100, ErrorMessage = "Este campo deve conter até 150 caracteres.")]        
        [DataType("varchar")]
        [Column("Endereco")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [DataType("Date")]
        [Column("Data_Nascimento")]
        public DateTime BirthDate { get; set; }

        [DataType("varchar")]
        [Column("Telefone")]
        public string Phone { get; set; }

        [DataType("varchar")]
        [Column("Identidade")]
        public string RG { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [DataType("varchar")]
        [Column("CPF")]
        public string CPF { get; set; }

        //relationship of student with classroom declaration
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int ClassRoomID { get; set; }
        //requited class relationship
        [Required]
        public ClassRoom ClassRoom { get; set; }

    }
}
