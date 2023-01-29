using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Department.Model.Data
{
    /// <summary>
    /// Класс который координирует функциональные возможности EF
    /// </summary>
    internal class ApplicationDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<WorkBook> WorkBooks { get; set; }
        public DbSet<Accounting> Accountings { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<HR_Department> HR_Departments { get; set; }
        public DbSet<Decree> Decrees { get; set; }

        /// <summary>
        /// Создаем БД, базовому классу передаем название БД
        /// </summary>
        public ApplicationDBContext() : base("HR_Department")
        {
        }
        /// <summary>
        /// Метод для определения связи между Employee и Passport (1 к 1)
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // В данном случае основной сущность устанавливается модель Employee к Passport
            modelBuilder.Entity<Employee>()
                        .HasRequired(c => c.Passport)
                        .WithRequiredPrincipal(c => c.Employee);

            // В данном случае основной сущность устанавливается модель Employee к WorkBook
            modelBuilder.Entity<Employee>()
                        .HasRequired(c => c.WorkBook)
                        .WithRequiredPrincipal(c => c.Employee);

            /*
            modelBuilder.Entity<Passport>()
                        .HasKey(t => t.Employee);
            */
        }
    }
}
