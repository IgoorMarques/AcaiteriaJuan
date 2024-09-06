namespace webApi.Controllers.Dtos
{
    public class PedidoAcaiDTO
    {
        public int IdPedido { get; set; }
        public string IdAcai { get; set; }
        public int Qtd { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
    }

    public class PedidoAcaiCreateDTO
    {
        public int IdAcai { get; set; }
        public int Qtd { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
