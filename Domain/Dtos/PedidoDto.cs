namespace webApi.Controllers.Dtos
{
    public class PedidoDTO
    {
        public int IdPedido { get; set; }
        public string Status { get; set; }
        public DateTime DataPedido { get; set; }
        public string FormaPagamento { get; set; }
        public int IdUsuario { get; set; }
        public List<PedidoAcaiDTO> PedidoAçais { get; set; }
        public PagamentoDTO Pagamento { get; set; }
    }

    public class PedidoCreateDTO
    {
        public string Status { get; set; }
        public DateTime DataPedido { get; set; }
        public string FormaPagamento { get; set; }
        public int IdUsuario { get; set; }
        public List<PedidoAcaiCreateDTO> PedidoAçais { get; set; }
    }
}
