namespace CRUD_Using_Entity.Models
{
    /// <summary>
    /// Class Representar um Produto
    /// </summary>
    public class Produto
    {
        public int Id { get; set; }
        public string  Nome { get; set; }
        public double Valor { get; set; }
        public string Categoria { get; set; }

    }
}