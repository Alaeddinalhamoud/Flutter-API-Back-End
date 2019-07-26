using Microsoft.EntityFrameworkCore;
using Students.Data;
using Students.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Repository
{
    public class StudentRepository : IStudent
    {
        private readonly StudentDbContext _db;

       

        public StudentRepository(StudentDbContext db)
        {
            _db = db;
        }

        public IQueryable<Student> GetStudents => _db.Students;

        public async Task<POJO> DeleteAsync(int? Id)
        {
            POJO model = new POJO();

            Student _Student = await GetStudent(Id);
            if (_Student != null)
            {
                try
                {
                    _db.Students.Remove(_Student);
                    await _db.SaveChangesAsync();
                    //Msg
                    model.Flag = true;
                    model.Message = "Has been Deleted.";
                }
                catch (Exception ex)
                {
                    model.Flag = false;
                    model.Message = ex.ToString();
                }
            }
            else
            {
                model.Flag = false;
                model.Message = "Student does not exist.";
            }

            return model;

        }

        public async Task<Student> GetStudent(int? Id)
        {
            Student _Student = new Student();
            if (Id != null)
            {
                _Student = await _db.Students.FindAsync(Id);
            }

            return _Student;
        }

        public async Task<POJO> Save(Student _Student)
        {
            POJO model = new POJO();
            //Add if  StudentId=0
            if (_Student.Id == 0)
            {
                try
                {
                    await _db.AddAsync(_Student);
                    await _db.SaveChangesAsync();

                    model.Id = _Student.Id;
                    model.Flag = true;
                    model.Message = "Has Been Added.";

                }
                catch (Exception ex)
                {
                    model.Flag = false;
                    model.Message = ex.ToString();
                }
            }
            //else if Student Id is not 0
            else if (_Student.Id != 0)
            {
                Student _Entity = await GetStudent(_Student.Id);
                _Entity.Id = _Student.Id;
                _Entity.FirstName = _Student.FirstName;
                _Entity.LastName = _Student.LastName;
                _Entity.DOB = _Student.DOB;
                _Entity.Gender = _Student.Gender;
                try
                {
                    await _db.SaveChangesAsync();
                    model.Id = _Student.Id;
                    model.Flag = true;
                    model.Message = "Has Been Updated.";
                }
                catch (Exception ex)
                {
                    model.Flag = false;
                    model.Message = ex.ToString();
                }
            }

            return model;

        }
    }

}