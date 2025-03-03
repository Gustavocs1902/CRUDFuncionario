using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Shared.Models
{
    public class BancoDB : DbContext
    {
        public DbSet<FuncionariosDb> Funcionario { get; set; }

        public BancoDB(DbContextOptions<BancoDB> options) : base(options)
        {
        }

        // Configuração do modelo (opcional)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações adicionais do modelo, se necessário
            modelBuilder.Entity<FuncionariosDb>().ToTable("Funcionarios"); // Define o nome da tabela
        }

    }
}
