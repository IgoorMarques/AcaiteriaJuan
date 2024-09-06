namespace webApi.Controllers.Dtos
{
    public class EndEntregaDTO
    {
        public int EndEntrega_PK { get; set; }
        public string EnderecoEntrega { get; set; }
        public int IdUsuario { get; set; }
    }

    public class EndEntregaCreateDTO
    {
        public string EnderecoEntrega { get; set; }
        public int IdUsuario { get; set; }
    }
}
