using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Students.Data
{
    public enum Genders
    {
        Female, Male, NA
    }
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        public Genders? Gender { get; set; }



    }
}
