namespace Application.ViewModel.Request
{
    public class PostProdutoRequest
    {
        public string NomeProduto { get; set; }
        public decimal ValorProduto { get; set; }
        public int IdCategoria { get; set; }
        public bool Ativo { get; set; } = true;

    }
}
