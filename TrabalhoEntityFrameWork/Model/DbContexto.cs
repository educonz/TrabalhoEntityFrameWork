using System.Data.Entity;

namespace TrabalhoEntityFrameWork.Model
{
    public class DbContexto : DbContext
    {
        public DbContexto() : base("dboTrabalho") { }

        public DbSet<Funcionario> Funcionarios { get; set; }
    }
}
