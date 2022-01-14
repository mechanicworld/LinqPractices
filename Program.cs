using System;
using System.Linq;
using LinqPractices.DbOperations;

namespace LinqPractices
{
  class Program
  {
    static void Main(string[] args)
    {
      DataGenerator.Initialize();
      LinqDbContext _context = new LinqDbContext();
      var students = _context.Students.ToList<Student>();

      // Find()
      Console.WriteLine("***** Find ****");
      var student = _context.Students.Where(student => student.StudentId == 1).FirstOrDefault();
      Console.WriteLine(student.Name);
      student = _context.Students.Find(2);
      Console.WriteLine(student.Name);

      // FirstOrDefault()
      // First is also works as same but if there is not any value inside of list , FristOrDefault will return null, First throw and exception
      Console.WriteLine("\n **** FirstOrDefault ****");

      // Version 1
      student = _context.Students.Where(student => student.Surname == "Demir").FirstOrDefault();
      Console.WriteLine(student.Name);
      // Version 2
      student = _context.Students.FirstOrDefault(x => x.Surname == "Demir");
      Console.WriteLine(student.Name);

      // SingleOrDefault()      
      Console.WriteLine("\n");
      Console.WriteLine(" **** SingleOrDefault ****");
      student = _context.Students.SingleOrDefault(student => student.Surname == "Veli");
      Console.WriteLine(student.Name);
      Console.WriteLine("\n");

      // While using where inside of singleordefault we have to sure where gives us only one value
      try
      {
        student = _context.Students.SingleOrDefault(student => student.Surname == "Demir");
        Console.WriteLine("\n");
        Console.WriteLine(student);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }

    // ToList()    
    Console.WriteLine("\n **** ToList ****\n");
    var studentList = _context.Students.Where(student => student.ClassId == 2).ToList();

    Console.WriteLine(studentList.Count());

    // OrderBy()    
    Console.WriteLine("\n **** OrderBy ****\n");
    students = _context.Students.OrderBy( x => x.StudentId).ToList();

    foreach (var each in students)
    {
        Console.WriteLine("{0} - {1} {2}", each.StudentId, each.Name, each.Surname);
    }

    // OrderByDescending()    
    Console.WriteLine("\n **** OrderByDescending ****\n");
    students = _context.Students.OrderByDescending( x => x.StudentId).ToList();

    foreach (var each in students)
    {
        Console.WriteLine("{0} - {1} {2}", each.StudentId, each.Name, each.Surname);
    }

    // Anonymous Object Result
    Console.WriteLine("\n **** Anonymous Object Result ****\n");

    var anonymousObject = _context.Students
                            .Where(x => x.ClassId ==2)
                            .Select(x => new {
                                Id = x.StudentId,
                                FullName= x.Name + " " + x.Surname,                                
                            });

    foreach (var obj in anonymousObject)
    {
        Console.WriteLine(obj.Id + "-" + obj.FullName);
    }

    }
  }
}
