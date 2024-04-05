using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Using_Databases
{
    public class Course
    {
        [Required]
        [PrimaryKey]
        public string? CourseId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int Credits {  get; set; }

        public override string ToString()
        {
            return $"{this.CourseId}, {this.Name}, {this.Credits}";
        }
    }
}
