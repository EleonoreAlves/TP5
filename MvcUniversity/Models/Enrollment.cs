
namespace Models;

public class Enrollment {
    public int Id {get;set;}
    public Grade? Grade {get;set;}
    public int StudentId{get;set;}
    public int CourseId{get;set;}
    public Student Students {get;set;}=null!;
    public Course Course {get;set;}=null!;
}