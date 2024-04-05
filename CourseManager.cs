using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Using_Databases
{
    internal class CourseManager
    {
        /// <summary>
        /// The object to connect to the database with
        /// </summary>
        private readonly SQLiteConnection database;

        public CourseManager()
        {
            //establishes the connection to the database
            this.database = new(Constants.DatabasePath);

            //Creates the new table if it does not exist
            this.database.CreateTable<Course>();
        }


        /// <summary>
        /// Creates a new <see cref="Course"/> object in the database
        /// </summary>
        /// <param name="course">the <see cref="Course"/> to be created</param>
        public void CreateCourse(Course course)
        {
            this.database.Insert(course);
        }

        /// <summary>
        /// Gets a <see cref="Course"/> from the database given the
        /// <paramref name="id"/>
        /// </summary>
        /// <param name="id">The id of the <see cref="Course"/> to find</param>
        /// <returns>The found <see cref="Course"/></returns>
        public Course GetCourse(string id)
        {
            Course course = this.database.Get<Course>(id);

            return course;
        }


        /// <summary>
        /// Gets a <c>List&lt;&lt;<see cref="Course"/>&gt;&gt;</c> of all the
        /// <see cref="Course"/> objects in the database
        /// </summary>
        /// <returns>A <c>List&lt;&lt;<see cref="Course"/>&gt;&gt;</c> of all <see cref="Course"/> objects in the databse</returns>
        public List<Course> GetAllCourses()
        {
            List<Course> courses = [.. this.database.Table<Course>()];

            return courses;
        }


        /// <summary>
        /// Updates a given <paramref name="course"/>
        /// </summary>
        /// <param name="course">The updated <see cref="Course"/></param>
        public void UpdateCourse(Course course)
        {
            this.database.Update(course);
        }

        /// <summary>
        /// Deletes a <see cref="Course"/> from the database based on the
        /// <paramref name="id"/> given
        /// </summary>
        /// <param name="id">The id of the <see cref="Course"/> to delete</param>
        public void DeleteCourse(string id)
        {
            this.database.Delete<Course>(id);
        }

        /// <summary>
        /// Clears all <see cref="Course"/> objects currently in the table
        /// </summary>
        public void ClearAllCourses()
        {
            this.database.DeleteAll<Course>();
        }
    }
}
