﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Employees.Classes
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class EmployeesEntities : DbContext
    {
        private static EmployeesEntities _context;
        public EmployeesEntities()
            : base("name=EmployeesEntities")
        {
        }
        public static EmployeesEntities GetContext()
        {
            if (_context == null)
                _context = new EmployeesEntities();
            return _context;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Kid> Kid { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
