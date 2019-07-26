using Students.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Services
{
   public interface IStudent
    {
        IQueryable<Student> GetStudents { get; }
        Task<Student> GetStudent(int? Id);
        Task<POJO> Save(Student _Student);
        Task<POJO> DeleteAsync(int? Id);


    }
}
