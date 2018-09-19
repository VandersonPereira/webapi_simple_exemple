using Estudo.Comum.Repositorios.Interfaces;
using Estudo.MinhaApi.AcessoADados.Entity.Context;
using Estudo.MinhaApi.Api.AutoMapper;
using Estudo.MinhaApi.Api.DTOs;
using Estudo.MinhaApi.Api.Filters;
using Estudo.MinhaApi.Dominio;
using Estudo.MinhaApi.Repositorios.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Estudo.MinhaApi.Api.Controllers
{
    public class AlunosController : ApiController
    {
        private IRepositorioEstudo<Aluno, int> _repositorioAlunos = new RepositorioAlunos(new MinhaApiDbContext());

        public IHttpActionResult Get()
        {
            List<Aluno> alunos = _repositorioAlunos.Selecionar();
            List<AlunoDTO> dtos
                = AutoMapperManager.Instance.Mapper.Map<List<Aluno>, List<AlunoDTO>>(alunos);

            return Ok(dtos);
        }

        public IHttpActionResult Get(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var aluno = _repositorioAlunos.SelecionarPorId(id.Value);

            if (aluno == null)
                return NotFound();

            AlunoDTO dto = AutoMapperManager.Instance.Mapper.Map<Aluno, AlunoDTO>(aluno);
            return Content(HttpStatusCode.Found, dto);
        }

        [ApplyModelValidation]
        public IHttpActionResult Post([FromBody] AlunoDTO dto)
        {
            try
            {
                Aluno aluno = AutoMapperManager.Instance.Mapper.Map<AlunoDTO, Aluno>(dto);
                _repositorioAlunos.Inserir(aluno);
                return Created($"{Request.RequestUri}/{aluno.Id}", aluno);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [ApplyModelValidation]
        public IHttpActionResult Put(int? id, [FromBody] AlunoDTO dto)
        {
            try
            {
                if (!id.HasValue)
                    return BadRequest();

                Aluno aluno = AutoMapperManager.Instance.Mapper.Map<AlunoDTO, Aluno>(dto);
                aluno.Id = id.Value;

                _repositorioAlunos.Atualizar(aluno);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return BadRequest();

                var aluno = _repositorioAlunos.SelecionarPorId(id.Value);
                if (aluno == null)
                    return NotFound();

                _repositorioAlunos.ExcluirPorId(id.Value);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
