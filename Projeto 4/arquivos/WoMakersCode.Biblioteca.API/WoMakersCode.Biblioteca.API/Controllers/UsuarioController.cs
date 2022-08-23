using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Application.Models.AdicionarUsuario;
using WoMakersCode.Biblioteca.Application.UseCases;

namespace WoMakersCode.Biblioteca.API.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUseCaseAsync<AdicionarUsuarioRequest, AdicionarUsuarioResponse> _useCaseAsync;

        public UsuarioController(IUseCaseAsync<AdicionarUsuarioRequest, AdicionarUsuarioResponse> useCaseAsync)
        {
            _useCaseAsync = useCaseAsync;
        }

        //Inserir()
        [HttpPost]
        public async Task<ActionResult<AdicionarUsuarioResponse>> Post([FromBody] AdicionarUsuarioRequest request)
        {
            return await _useCaseAsync.ExecuteAsync(request);
        }
    }
}
