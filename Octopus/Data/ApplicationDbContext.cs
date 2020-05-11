using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Octopus.Models;

namespace Octopus.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public virtual DbSet<Lada> Ladas{ get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<WebService> WebServices { get; set; }
       
        public virtual DbSet<WebServRegion> WebServRegions { get; set; }
        public virtual DbSet<Carrier> Carriers { get; set; }
        public virtual DbSet<WebServDesc> WebServDescs { get; set; }
        public virtual DbSet<Monto> Montos { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Grupo> Grupos { get; set; }
        public virtual DbSet<UsuarioGrupo> UsuarioGrupos { get; set; }
        public virtual DbSet<Status> Statues { get; set; }

        public virtual DbSet<User> User { get; set; }

        public virtual DbSet<Recarga> Recargas { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<WebService>().Ignore(p => p.WSDesc);
            modelBuilder.Entity<User>().Ignore(p => p.UserDesc);
            modelBuilder.Entity<Recarga>().Ignore(p => p.ConfirmPhone);

            base.OnModelCreating(modelBuilder);
        }
    }
}
