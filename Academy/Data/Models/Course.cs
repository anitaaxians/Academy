﻿using Academy.Data.Models;

public class Course
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ICollection<UserCourse> UserCourses { get; set; }
}


