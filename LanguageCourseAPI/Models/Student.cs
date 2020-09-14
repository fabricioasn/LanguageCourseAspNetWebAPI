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

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [StringLength(10, ErrorMessage = "Este campo deve conter exatamente 10 caracteres.")]
        [DataType("varchar")]
        [Column("Matricula")]
        public string Enrollment { get; set; }

        [MaxLength(150, ErrorMessage = "Este campo deve conter até 150 caracteres.")]        
        [DataType("varchar")]
        [Column("Endereco")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [DataType("Date")]
        [StringLength(10, ErrorMessage = "Este campo deve conter 10 caracteres.")]
        [Column("Data_Nascimento")]
        public DateTime BirthDate { get; set; }

        [StringLength(8, ErrorMessage = "Este campo deve conter 8 caracteres.")]
        [DataType("varchar")]
        [Column("Telefone")]
        public string Phone { get; set; }

        [StringLength(9, ErrorMessage = "Este campo deve conter 9 caracteres.")]
        [DataType("varchar")]
        [Column("Identidade")]
        public string RG { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [StringLength(11, ErrorMessage = "Este campo deve conter 11 caracteres.")]
        [DataType("varchar")]
        [Column("CPF")]
        public string CPF { get; set; }

        //relationship of student with classroom declaration
        public int ClassRoomID { get; set; }
        public ClassRoom ClassRoom { get; set; }

    }
}
