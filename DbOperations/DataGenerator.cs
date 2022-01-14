using System.Linq;

namespace LinqPractices.DbOperations
{
  public class DataGenerator
  {
    public static void Initialize()
    {
      using(var context = new LinqDbContext())
      {
        if(context.Students.Any())
        {
          return;
        }
        context.Students.AddRange(
          new Student(){
            Name = "Oguz",
            Surname = "Demir",
            ClassId = 2
          },
          new Student(){
            Name = "Ilayda",
            Surname = "Demir",
            ClassId = 2
          },
          new Student(){
            Name = "Ali",
            Surname = "Veli",
            ClassId = 4
          },
          new Student(){
            Name = "Sukriye",
            Surname = "Ozcan",
            ClassId = 4
          }
        );
        context.SaveChanges();
      }
    }
  }
}