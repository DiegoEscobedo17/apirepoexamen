using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ApiExamenesFinal2.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Examenes> Examenes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Examenes>()
                .Property(e => e.texto)
                .IsUnicode(false);

            modelBuilder.Entity<Examenes>()
                .Property(e => e.procentaje)
                .IsUnicode(false);

            modelBuilder.Entity<Examenes>()
                .Property(e => e.curso)
                .IsUnicode(false);

            modelBuilder.Entity<Examenes>()
                .Property(e => e.precio)
                .IsUnicode(false);
        }
    }
}
