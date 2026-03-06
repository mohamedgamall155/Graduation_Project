using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace projectweb.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Relative> Relatives { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Committee> Committees { get; set; }
        public DbSet<CommitteesAssignment> CommitteesAssignments { get; set; }

        public DbSet<Hall> Halls { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<BlockCommittee> BlockCommittees { get; set; }

        public DbSet<Exam> Exams { get; set; }

        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportPerson> ReportPersons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /* =========================
               Composite Primary Keys
            ========================== */

            modelBuilder.Entity<BlockCommittee>()
                .HasKey(bc => new { bc.BlockID, bc.CommitteeID });

            modelBuilder.Entity<ReportPerson>()
                .HasKey(rp => new { rp.ReportID, rp.PersonID });

            modelBuilder.Entity<CommitteesAssignment>()
                .HasKey(ca => new { ca.PersonID, ca.CommitteeID, ca.RoleID });

            /* =========================
               Relationships
            ========================== */

            modelBuilder.Entity<Relative>()
                .HasOne(r => r.Student)
                .WithMany(s => s.Relatives)
                .HasForeignKey(r => r.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Relative>()
                .HasOne(r => r.Person)
                .WithMany(p => p.Relatives)
                .HasForeignKey(r => r.PersonId)
                .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Person>()
            //    .HasOne(p => p.Role)
            //    .WithMany(p => p.Roles)
            //    .HasForeignKey(r => r.PersonID)
            //    .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<CommitteesAssignment>()
                .HasOne(ca => ca.Person)
                .WithMany(p => p.CommitteesAssignments)
                .HasForeignKey(ca => ca.PersonID)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<CommitteesAssignment>()
                .HasOne(ca => ca.Committee)
                .WithMany(c => c.CommitteesAssignments)
                .HasForeignKey(ca => ca.CommitteeID);

            modelBuilder.Entity<CommitteesAssignment>()
                .HasOne(ca => ca.Role)
                .WithMany()
                .HasForeignKey(ca => ca.RoleID)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Hall>()
                .HasOne(h => h.HallSupervisor)
                .WithMany()
                .HasForeignKey(h => h.HallSupervisorID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Block>()
                .HasOne(b => b.Hall)
                .WithMany(h => h.Blocks)
                .HasForeignKey(b => b.HallID);

            modelBuilder.Entity<BlockCommittee>()
                .HasOne(bc => bc.Block)
                .WithMany(b => b.BlockCommittees)
                .HasForeignKey(bc => bc.BlockID);

            modelBuilder.Entity<BlockCommittee>()
                .HasOne(bc => bc.Committee)
                .WithMany(c => c.BlockCommittees)
                .HasForeignKey(bc => bc.CommitteeID);

            modelBuilder.Entity<Exam>()
                .HasOne(e => e.Committee)
                .WithMany(c => c.Exams)
                .HasForeignKey(e => e.CommitteeID);

            modelBuilder.Entity<Report>()
                .HasOne(r => r.Block)
                .WithMany(b => b.Reports)
                .HasForeignKey(r => r.BlockID);

            modelBuilder.Entity<Report>()
                .HasOne(r => r.Committee)
                .WithMany(c => c.Reports)
                .HasForeignKey(r => r.CommitteeID);

            modelBuilder.Entity<ReportPerson>()
                .HasOne(rp => rp.Report)
                .WithMany(r => r.ReportPersons)
                .HasForeignKey(rp => rp.ReportID);

            modelBuilder.Entity<ReportPerson>()
                .HasOne(rp => rp.Person)
                .WithMany(p => p.ReportPersons)
                .HasForeignKey(rp => rp.PersonID);

            modelBuilder.Entity<ReportPerson>()
                .HasOne(rp => rp.Role)
                .WithMany(r => r.ReportPersons)
                .HasForeignKey(rp => rp.RoleID);
        }
    }
}
