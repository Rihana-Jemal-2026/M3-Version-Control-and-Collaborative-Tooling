var service = new EnrollmentService();

var student = new Student
{
    Id = "S1",
    Name = "Abeba",
    Age = 20,
    GPA = 3.8m
};

var course = new Course
{
    Code = "CS101",
    Title = "C# Basics",
    Capacity = 2
};

var record = service.ProcessRegistration(student, course);

Console.WriteLine($"Enrolled: {record.StudentId} in {record.CourseCode}");

List<Student> students = [
    new Student { Id = "S1", Name = "Abeba", Age = 22, GPA = 3.8m },
    new Student { Id = "S2", Name = "Kidane", Age = 21, GPA = 2.4m },
    new Student { Id = "S3", Name = "Dawit", Age = 20, GPA = 3.1m },
    new Student { Id = "S4", Name = "Sara", Age = 23, GPA = 3.9m },
    new Student { Id = "S5", Name = "Frehiwot", Age = 19, GPA = 2.0m }
];

var leaderboard = students
    .Where(s => s.GPA >= 3.5m)
    .OrderByDescending(s => s.GPA)
    .Select(s => s.Name)
    .ToList();

Console.WriteLine("\n--- Honors Students ---");
foreach (var name in leaderboard)
{
    Console.WriteLine(name);
}

decimal averageGpa = students.Average(s => s.GPA);

Console.WriteLine($"\nClass Average GPA: {averageGpa:F2}");

var groups = students.GroupBy(s => s.GPA switch
{
    >= 3.5m => "Honors",
    >= 2.5m => "Good Standing",
    >= 2.0m => "Probation",
    _ => "Academic Warning"
});

Console.WriteLine("\n--- Academic Standing ---");

foreach (var group in groups)
{
    Console.WriteLine($"\n{group.Key}");
    foreach (var s in group)
    {
        Console.WriteLine($"  {s.Name} ({s.GPA})");
    }
}

string[] backendCourses = ["C#", "ASP.NET Core"];
string[] frontendCourses = ["TypeScript", "Angular"];

string[] allCourses = [..backendCourses, ..frontendCourses, "Capstone"];

Console.WriteLine("\n--- Courses ---");
Console.WriteLine(string.Join(", ", allCourses));