using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Application.Models.AdicionarEmprestimo;
using WoMakersCode.Biblioteca.Core.Entities;
using WoMakersCode.Biblioteca.Core.Repositories;

namespace WoMakersCode.Biblioteca.Application.UseCases
{
    public class AdicionarEmprestimoUseCase : IUseCaseAsync<AdicionarEmprestimoRequest, AdicionarEmprestimoResponse>
    {
        private readonly IEmprestimoRepository _repository;
        private readonly IMapper _mapper;

        public AdicionarEmprestimoUseCase(IEmprestimoRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AdicionarEmprestimoResponse> ExecuteAsync(AdicionarEmprestimoRequest request)
        {
            if (request == null)
                throw new Exception("AdicionarEmprestimoRequest está nulo.");

            var emprestimo = _mapper.Map<Emprestimo>(request);

            await _repository.Inserir(emprestimo);

            return new AdicionarEmprestimoResponse(){};
        }
    }
}
