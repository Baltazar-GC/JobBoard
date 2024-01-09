using backend.Entities;
using backend.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backend.Contexts
{
    public class ApplicationUtnContext : IdentityDbContext<User>
    {
        public ApplicationUtnContext(DbContextOptions options)
        : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<TechnologyLevel> TechnologyLevels { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<StudentPersonalInformation> StudentsPersonalInformation { get; set; }
        public DbSet<StudentCollegeInformation> StudentsCollegeInformation { get; set; }
        public DbSet<BusinessInformation> BusinessesInformation { get; set; }
        public DbSet<BusinessContact> BusinessesContacts { get; set; }
        public DbSet<InternshipOffer> InternshipOffers { get; set; }
        public DbSet<HiredEmployeeOffer> HiredEmployeeOffers { get; set; }
        public DbSet<OtherSkills> OtherSkills { get; set; }
        public DbSet<StudentExtraData> StudentsExtraData { get; set; }
        public DbSet<ApplicationInternship> InternshipApplications { get; set; }
        public DbSet<ApplicationHired> HiredApplications { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            string ADMIN_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
            string ROLE_ID = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";

            //seed admin role
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });

            //seed student role

            string ROLE_STUDENT_ID = "601f0ede-374e-45f0-9373-50cba7a8183e";
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Student",
                NormalizedName = "STUDENT",
                Id = ROLE_STUDENT_ID,
                ConcurrencyStamp = ROLE_STUDENT_ID
            });

            //seed employer role

            string ROLE_EMPLOYER_ID = "886bad89-d81f-4c6d-8c98-e3ba074c23dd";
            //seed student role
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Employer",
                NormalizedName = "EMPLOYER",
                Id = ROLE_EMPLOYER_ID,
                ConcurrencyStamp = ROLE_EMPLOYER_ID
            });




            //create student user
            string STUDENT_ID = "272cf1fd-6e8b-4bdb-87b8-b136033fad9e";
            var studentUser = new User
            {
                Id = STUDENT_ID,
                Email = "student@frro.utn.edu.ar",
                NormalizedEmail = "STUDENT@FRRO.UTN.EDU.AR",
                EmailConfirmed = true,
                FirstName = "Carlos",
                LastName = "Perez",
                UserName = "student1",
                NormalizedUserName = "STUDENT1"
            };

            //set user password
            PasswordHasher<User> ph1 = new PasswordHasher<User>();
            studentUser.PasswordHash = ph1.HashPassword(studentUser, "12345");

            //seed user
            builder.Entity<User>().HasData(studentUser);

            //set user role to admin
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_STUDENT_ID,
                UserId = STUDENT_ID
            });




            //create employer user
            string EMPLOYER_ID = "bdc961f7-6fb6-4b7e-9319-c35a8b09dd36";

            var employerUser = new User
            {
                Id = EMPLOYER_ID,
                Email = "employer@frro.utn.edu.ar",
                NormalizedEmail = "EMPLOYER@FRRO.UTN.EDU.AR",
                EmailConfirmed = true,
                FirstName = "Mercado Libre",
                LastName = "Argentina",
                UserName = "employer1",
                NormalizedUserName = "EMPLOYER1"
            };

            //set user password
            PasswordHasher<User> ph3 = new PasswordHasher<User>();
            employerUser.PasswordHash = ph3.HashPassword(employerUser, "12345");

            //seed user
            builder.Entity<User>().HasData(employerUser);

            //set user role to admin
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_EMPLOYER_ID,
                UserId = EMPLOYER_ID
            });


            //create admin user

            var adminUser = new User
            {
                Id = ADMIN_ID,
                Email = "admin@frro.utn.edu.ar",
                NormalizedEmail = "ADMIN@FRRO.UTN.EDU.AR",
                EmailConfirmed = true,
                FirstName = "administracion",
                LastName = "UTN",
                UserName = "admin1",
                NormalizedUserName = "ADMIN1"
            };

            //set user password
            PasswordHasher<User> ph4 = new PasswordHasher<User>();
            adminUser.PasswordHash = ph4.HashPassword(adminUser, "12345");

            //seed user
            builder.Entity<User>().HasData(adminUser);

            //set user role to admin
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
        }



    }
}
