using Domain.Entities;
using Domain.Interfaces;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class PagamentoRepository : IPagamentoRepository
    {
        private readonly FiapDbContext _context;

        public PagamentoRepository(FiapDbContext context)
        {
            _context = context;
        }

        public async Task<Pagamento?> GetPagamentoByIdPedido(int idPedido)
        {
            if (_context.Pagamentos is null)
                throw new InvalidOperationException("Contexto de pagamento nulo.");

            // Caso encontre mais de um registro pega sempre o ultimo.
            return await _context.Pagamentos.Where(p => p.IdPedido == idPedido)
                                           .OrderByDescending(p => p.DataPagamento)
                                           .FirstOrDefaultAsync();
        }

        public async Task<Pagamento> PostPagamento(Pagamento pagamento)
        {
            if (_context.Pagamentos is not null)
            {
                _context.Pagamentos.Add(pagamento);
                await _context.SaveChangesAsync();
            }
            return pagamento;
        }

        public async Task<Pagamento> PutPagamento(Pagamento pagamento)
        {
            if (_context.Pagamentos is not null)
            {
                var pagto = await _context.Pagamentos.FirstOrDefaultAsync(p => p.IdPagamento == pagamento.IdPagamento);
                pagto.StatusPagamento = pagamento.StatusPagamento;
                _context.Pagamentos.Update(pagto);
                await _context.SaveChangesAsync();
            }
            return pagamento;
        }
    }
}
