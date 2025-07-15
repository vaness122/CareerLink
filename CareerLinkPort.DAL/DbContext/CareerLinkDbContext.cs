using CareerLinkPort.Core.Models.JobModels;
using CareerLinkPort.Core.Models.UserModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerLinkPort.DAL.Data
{
    public class CareerLinkDbContext : IdentityDbContext<AppUser>
    {
        public CareerLinkDbContext(DbContextOptions<CareerLinkDbContext>options) : base(options) { }

        public DbSet <Alumni> Alumnus { get; set; }
        public DbSet <Employer> Employers {  get; set; }
        public DbSet <Admin> Admins { get; set; }
        public DbSet <Job> Jobs {  get; set; }
        public DbSet <JobApplication> JobApplications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>()
                .HasDiscriminator<string>("UserType")
                .HasValue<Alumni>("Alumni")
                .HasValue<Employer>("Employer")
                .HasValue<Admin>("Admin");

            builder.Entity<Job>()
       .HasOne(j => j.Employer)
       .WithMany(e => e.Jobs)
       .HasForeignKey(j => j.EmployerId)
       .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<JobApplication>()
        .HasOne(ja => ja.Job)
        .WithMany(j => j.Applications)
        .HasForeignKey(ja => ja.JobId)
        .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<JobApplication>()
    .HasOne(ja => ja.Alumni)
    .WithMany(a => a.Applications)
    .HasForeignKey(ja => ja.AlumniId)
    .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany()
                .HasForeignKey(n => n.UserId);
        }









    }

    }

