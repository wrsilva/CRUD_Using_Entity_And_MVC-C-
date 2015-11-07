using System.Data.Entity;
using CRUD_Using_Entity.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CRUD_Using_Entity.Contexto
{
    public class Contexto:DbContext
    {
        public Contexto():base("Conection")
        {
            
        }

        public DbSet<Produto> Produtos { get; set; }
        /// <summary>
        /// Configuraçao da tabela
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            //Definindo a primary Key: Sempre que o nome vinher seguido de Id
            modelBuilder.Properties().Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());
            //Configurando para tudo que for string, o entity cria como varchar e nao nvarchar 
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));
            //Caso nao informa o tamanho da string por padrao recebe 100 
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));
        }
    }
}