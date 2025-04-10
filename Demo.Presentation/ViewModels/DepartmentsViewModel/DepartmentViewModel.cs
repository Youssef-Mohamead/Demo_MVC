﻿namespace Demo.Presentation.ViewModels.DepartmentsViewModel
{
    public class DepartmentViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateOnly CreatedOn { get; set; }
    }
}
