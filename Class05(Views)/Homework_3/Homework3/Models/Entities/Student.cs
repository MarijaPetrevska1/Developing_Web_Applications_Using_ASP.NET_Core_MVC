﻿using Homework3.Models.Entites;

namespace Homework3.Models.Entites
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Course ActiveCourse { get; set; }
    }
}

