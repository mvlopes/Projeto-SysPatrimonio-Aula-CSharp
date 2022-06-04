﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysPatrimonio.Models
{
    [Table("usuario", Schema = "public")]

    public class DbUsuario
    {
        [Key]

        public int id { get; set; }
        public string nome { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public char status { get; set; }
    }
}
