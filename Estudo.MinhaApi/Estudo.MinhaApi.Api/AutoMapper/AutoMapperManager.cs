using AutoMapper;
using Estudo.MinhaApi.Api.DTOs;
using Estudo.MinhaApi.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Estudo.MinhaApi.Api.AutoMapper
{
    public class AutoMapperManager
    {
        private static readonly Lazy<AutoMapperManager> _instance =
            new Lazy<AutoMapperManager>(() =>
            {
                return new AutoMapperManager();
            });

        private readonly MapperConfiguration _config;

        private AutoMapperManager()
        {
            _config = new MapperConfiguration((cfg) =>
            {
                cfg.CreateMap<Aluno, AlunoDTO>();
                cfg.CreateMap<AlunoDTO, Aluno>();
            });
        }

        public static AutoMapperManager Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public IMapper Mapper
        {
            get
            {
                return _config.CreateMapper();
            }
        }
    }
}