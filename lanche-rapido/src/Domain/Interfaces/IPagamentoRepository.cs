﻿using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPagamentoRepository
    {
        Task<Pagamento> PostPagamento(Pagamento pagamento);
        Task<Pagamento> PutPagamento(Pagamento pagamento);
        Task<Pagamento?> GetPagamentoByIdPedido(int idPedido);
    }
}
