using AutoMapper;
using WoMakersCode.Biblioteca.Application.Models.AdicionarAutor;
using WoMakersCode.Biblioteca.Application.Models.AdicionarUsuario;
using WoMakersCode.Biblioteca.Application.Models.DevolucoesEmAtraso;
using WoMakersCode.Biblioteca.Application.Models.ListarLivros;
using WoMakersCode.Biblioteca.Application.Models.LivrosDisponiveis;
using WoMakersCode.Biblioteca.Application.Models.LivrosEmEmprestimo;
using WoMakersCode.Biblioteca.Core.DTOs;
using WoMakersCode.Biblioteca.Core.Entities;

namespace WoMakersCode.Biblioteca.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AdicionarUsuarioRequest, Usuario>()
                .ForMember(dest => dest.Nome, fonte => fonte.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Endereco, fonte => fonte.MapFrom(src => src.Endereco))
                .ForMember(dest => dest.Telefone, fonte => fonte.MapFrom(src => src.Telefone));

            CreateMap<AdicionarAutorRequest, Autor>()
                .ForMember(dest => dest.Nome, fonte => fonte.MapFrom(src => src.Nome));

            CreateMap<Livro, ListarLivrosResponse>()
               .ForMember(dest => dest.Id, fonte => fonte.MapFrom(src => src.Id))
               .ForMember(dest => dest.Titulo, fonte => fonte.MapFrom(src => src.Titulo))
               .ForMember(dest => dest.QuantidadeDisponivel, fonte => fonte.MapFrom(src => src.QuantidadeDisponivel))
               .ForMember(dest => dest.IdAutor, fonte => fonte.MapFrom(src => src.IdAutor));

            CreateMap<LivrosAtrasadosDTO, DevolucoesEmAtrasoResponse>();

            CreateMap<LivrosDisponiveisDTO, LivrosDisponiveisResponse>();

            CreateMap<LivroEmprestadoDTO, LivrosEmEmprestimoResponse>();
        }
    }
}
