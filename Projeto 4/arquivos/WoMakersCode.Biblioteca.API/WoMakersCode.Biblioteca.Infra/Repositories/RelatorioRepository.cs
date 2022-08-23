using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Core.DTOs;
using WoMakersCode.Biblioteca.Core.Repositories;
using WoMakersCode.Biblioteca.Infra.Database;

namespace WoMakersCode.Biblioteca.Infra.Repositories
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly ApplicationContext _context;

        public RelatorioRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LivrosAtrasadosDTO>> RelatorioLivrosEmAtraso(DateTime? dataInicio, DateTime? dataDevolucao, string nomeUsuario, string tituloLivro)
        {
           // var registros = _context
           //     .Emprestimos
           //     .Include(i => i.Livro)
           //         .ThenInclude(ti => ti.Autor)
           //     .Include(i => i.Usuario)
           //     .AsNoTracking()
           //     .AsQueryable();

           // if (dataInicio != null)
           //     registros = registros.Where(w => w.DataEmprestimo == dataInicio);

           //await registros
           //     .ToListAsync();

            return new List<LivrosAtrasadosDTO>();
        }

        public async Task<IEnumerable<LivroEmprestadoDTO>> RelatorioLivrosEmprestados()
        {
            return new List<LivroEmprestadoDTO>();
        }

        public async Task<IEnumerable<LivrosDisponiveisDTO>> RelatorioLivrosDisponiveis()
        {
            return new List<LivrosDisponiveisDTO>();
        }
    }
}
