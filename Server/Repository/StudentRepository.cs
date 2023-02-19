using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using NWSInventaire.Server.Data;
using NWSInventaire.Shared.Models;
using System.Net;

namespace NWSInventaire.Server.Repository
{
    public class StudentRepository : RepositoryBase
    {

        public StudentRepository(DataContext context) : base(context) { }

        public List<Student> GetAllStudent()
        {
            try
            {

                List<Student> getStudent = Context.students.ToList();

                if (getStudent == null)
                    return null;

                return getStudent;

            }
            catch { return null; }
        }

        public Student GetStudent(int id)
        {
            try
            {

                Student getStudent = Context.students.FirstOrDefault(x => x.StudentId == id);

                if (getStudent == null)
                    return null;

                return getStudent;

            }
            catch{ return null; }

        }

        public IActionResult AddStudent(Student student)
        {
            try
            {
                if (student == null)
                    return new StatusCodeResult(404);

                if (student.StudentFirstName == null && student.StudentLastName == null && student.StudentMail == null)
                    return new StatusCodeResult(404);


                Context.students.Add(student);
                Context.SaveChanges();
                return new StatusCodeResult(202);

            }
            catch { return new StatusCodeResult(404); }
        }

        public IActionResult DeleteStudent(int id)
        {
            try
            {
                Student getStudent = Context.students.FirstOrDefault(x => x.StudentId == id);

                if (getStudent == null)
                    return new StatusCodeResult(404);

                Context.Remove(getStudent);
                Context.SaveChanges();
                return new StatusCodeResult(200);
                    
            }
            catch { return new StatusCodeResult(404); }

        }


        public IActionResult PutStudent(Student student)
        {
            try
            {
                if (student == null)
                    return new StatusCodeResult(404);

                if (student.StudentFirstName == "" && student.StudentLastName == "" && student.StudentMail == "")
                    return new StatusCodeResult(404);

                Student? getStudent = Context.students.FirstOrDefault(x => x.StudentId == student.StudentId);

                if (getStudent != null)
                    return new StatusCodeResult(404);

                Context.Attach(getStudent);
                Context.Entry(getStudent).CurrentValues.SetValues(student);
                Context.SaveChanges();

                return new StatusCodeResult(200);

            }
            catch{ return new StatusCodeResult(404); }   
        }

    }
}
