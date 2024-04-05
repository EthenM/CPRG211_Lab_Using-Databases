using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Using_Databases
{
    public class EntryPoint
    {
        /// <summary>
        /// Provides methods to interact with the database
        /// </summary>
        private CourseManager courseManager;

        public EntryPoint()
        {
            courseManager = new();
        }

        /// <summary>
        /// The non-static entry point for the program
        /// </summary>
        public void Run()
        {
            //Initialize the table by adding 5 rows of data if they don't exist
            //Create Courses
            InitializeTable();

            //Read Courses
            Console.WriteLine("\n\n*** Reading in courses from the database ***\n\n");

            GetCourses();

            //Update Courses
            Console.WriteLine("\n\n*** Updating a course ***\n\n");

            UpdateCourse();

            //Delete Courses
            Console.WriteLine("\n\n*** Deleting a course ***\n\n");
            DeleteCourse();
        }

        /// <summary>
        /// Initializes the table, clearing any values from previous runs
        /// then creating five new <see cref="Course"/> objects and inserting
        /// them.
        /// </summary>
        private void InitializeTable()
        {
            //reset the table for another run
            courseManager.ClearAllCourses();

            //Create 5 courses
            Course WebDev = new()
            {
                CourseId = "1001",
                Name = "Fundamentals of Web Development",
                Credits = 3
            };
            Course fullStack = new()
            {
                CourseId = "1002",
                Name = "Introduction to Full Stack Programming",
                Credits = 3
            };
            Course databases = new()
            {
                CourseId = "1003",
                Name = "Databases",
                Credits = 3
            };
            Course softwareAnalysis = new()
            {
                CourseId = "1004",
                Name = "Principles of Software Design and Analysis",
                Credits = 4
            };
            Course OOP = new()
            {
                CourseId = "1005",
                Name = "Object-Oriented Programming",
                Credits = 4
            };

            //add the courses to the database
            courseManager.CreateCourse(WebDev);
            courseManager.CreateCourse(fullStack);
            courseManager.CreateCourse(databases);
            courseManager.CreateCourse(softwareAnalysis);
            courseManager.CreateCourse(OOP);
        }

        /// <summary>
        /// Gets all <see cref="Course"/> objects and displays them
        /// then gets one <see cref="Course"/> and displays it
        /// </summary>
        private void GetCourses()
        {
            //read in all courses from the table
            List<Course> courses = courseManager.GetAllCourses();

            Console.WriteLine("** displaying all courses **\n");

            courses.ForEach(course =>
            {
                Console.WriteLine(course);
            });


            //read in just one course from the table
            Course course = courseManager.GetCourse("1002");
            Console.WriteLine(course);
        }
    
        /// <summary>
        /// Updates a <see cref="Course"/> from the courses table and saves
        /// it back.
        /// </summary>
        private void UpdateCourse()
        {
            //get the course and display it to the console.
            Course courseToUpdate = courseManager.GetCourse("1001");
            Console.WriteLine("Course before updating: " + courseToUpdate);

            //update the course and save it back to the database
            courseToUpdate.Name = "Fund. Web Dev";
            courseToUpdate.Credits = 10;

            courseManager.UpdateCourse(courseToUpdate);

            //get the course back from the table to check if it updated
            Course updatedCourse = courseManager.GetCourse("1001");
            Console.WriteLine("Course after updating: " + updatedCourse);
        }

        /// <summary>
        /// Deletes a <see cref="Course"/> from the course table
        /// and displays all remaining courses
        /// </summary>
        private void DeleteCourse()
        {
            //delete the course with the id 1003 (Databases)
            courseManager.DeleteCourse("1003");

            //show all courses in the table
            List<Course> courses = courseManager.GetAllCourses();
            
            courses.ForEach(course =>
            {
                Console.WriteLine(course);
            });
        }
    }
}
