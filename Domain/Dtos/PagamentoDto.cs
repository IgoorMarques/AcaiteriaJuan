namespace webApi.Controllers.Dtos
{
    public class PagamentoDTO
    {
        public int IdPagamento { get; set; }
        public decimal Valor { get; set; }
        public string Status { get; set; }
        public string Descricao { get; set; }
        public int IdPedido { get; set; }
    }

    public class PagamentoCreateDTO
    {
        public decimal Valor { get; set; }
        public string Status { get; set; }
        public string Descricao { get; set; }
        public int IdPedido { get; set; }
    }
}
