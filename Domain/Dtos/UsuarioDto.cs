namespace webApi.Controllers.Dtos
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string NomeCompleto { get; set; }
        public decimal? TaxaEntrega { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
    }

    public class UsuarioCreateDTO
    {
        public string NomeCompleto { get; set; }
        public decimal? TaxaEntrega { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
    }
}

