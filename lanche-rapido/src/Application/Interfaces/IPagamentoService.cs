using Domain.Entities;
using Domain.Entities.Output;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPagamentoService
    {
        Task<PagamentoOutput> ProcessarPagamento(Pagamento pagamentoInput);
        Task<PagamentoStatusOutput?> GetStatusPagamento(int idPedido);
        Task<QRCodeOutput?> ObterQRCodePagamento(int idPedido);
        Task ProcessarNotificacaoPagamento(long id_merchant_order);
    }
}
