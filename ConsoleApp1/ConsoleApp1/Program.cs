using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        //the path to text file
        string filePath = "F:\\mphasis\\practice projects\\3rd project\\student_data.txt";

        // Read student data from the file
        List<Student> students = ReadStudentData(filePath);

        // Display the unsorted student data
        DisplayStudentData("Unsorted Student Data", students);

        // Sort the student data by name
        students = SortStudentsByName(students);

        // Display the sorted student data
        DisplayStudentData("Sorted Student Data", students);

        // Search for a student by name
        Console.Write("Enter the name to search: ");
        string searchName = Console.ReadLine();
        SearchAndDisplayStudent(students, searchName);
        Console.ReadKey();
    }

    static List<Student> ReadStudentData(string filePath)
    {
        List<Student> students = new List<Student>();

        try
        {
            // Read each line from the file and create Student objects
            foreach (string line in File.ReadLines(filePath))
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2)
                {
                    string name = parts[0].Trim();
                    string className = parts[1].Trim();
                    students.Add(new Student { Name = name, ClassName = className });
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found. Please check the file path.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return students;
    }

    static List<Student> SortStudentsByName(List<Student> students)
    {
        return students.OrderBy(student => student.Name).ToList();
    }

    static void DisplayStudentData(string title, List<Student> students)
    {
        Console.WriteLine($"\n{title}:\n");
        foreach (var student in students)
        {
            Console.WriteLine($"Name: {student.Name}, Class: {student.ClassName}");
        }
    }

    static void SearchAndDisplayStudent(List<Student> students, string searchName)
    {
        Student foundStudent = students.Find(student => student.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));

        if (foundStudent != null)
        {
            Console.WriteLine($"Student found - Name: {foundStudent.Name}, Class: {foundStudent.ClassName}");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }
}

class Student
{
    public string Name { get; set; }
    public string ClassName { get; set; }
}
