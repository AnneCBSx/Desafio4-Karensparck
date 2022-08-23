using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Core.Entities;
using WoMakersCode.Biblioteca.Core.Repositories;
using WoMakersCode.Biblioteca.Infra.Database;

namespace WoMakersCode.Biblioteca.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationContext _context;

        public UsuarioRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Atualizar(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public Task Excluir(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public async Task Inserir(Usuario obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public async Task<Usuario> ListarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Usuario>> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
