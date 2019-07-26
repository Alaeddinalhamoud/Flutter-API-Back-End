using Microsoft.EntityFrameworkCore;
using Students.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Repository
{
  public  class StudentDbContext:DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }
        

      public  DbSet<Student> Students { get; set; }
    }
}
