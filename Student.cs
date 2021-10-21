namespace Talaba_Malimotlari
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Student
    {
        public int id { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public string MiddilName { get; set; }

        public int Age { get; set; }

        public string Phone { get; set; }
    }
}
