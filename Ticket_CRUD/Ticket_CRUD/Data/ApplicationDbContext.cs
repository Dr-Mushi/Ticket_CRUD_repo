using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Ticket_CRUD.Models;

namespace Ticket_CRUD.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Ticket_CRUD.Models.Ticket> Ticket { get; set; }
        public DbSet<Ticket_CRUD.Models.SignUpModel> SignUpModel { get; set; }
        public DbSet<Ticket_CRUD.Models.LogInModel> LogInModel { get; set; }
    }
}
