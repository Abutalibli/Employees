//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public int IdEmployee { get; set; }
        public string FIO { get; set; }
        public string male { get; set; }
        public int age { get; set; }
        public string numberphone { get; set; }
        public string email { get; set; }
        public string job_title { get; set; }
        public int stage { get; set; }
        public int idKid { get; set; }
        public int idDepartment { get; set; }
    
        public virtual Department Department { get; set; }
        public virtual Kid Kid { get; set; }
    }
}
