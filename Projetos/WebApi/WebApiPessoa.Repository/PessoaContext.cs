using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiPessoa.Repository.Models;

namespace WebApiPessoa.Repository
{
    public class PessoaContext : DbContext
    {
        public PessoaContext(DbContextOptions<PessoaContext> options) : base(options) { }

        public DbSet<TabUsuario> Usuarios { get; set; }

        public DbSet<TabPessoa> Pessoas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TabUsuario>().ToTable("tabusuario");
            modelBuilder.Entity<TabPessoa>().ToTable("tabpessoa");
        }
    }
}
