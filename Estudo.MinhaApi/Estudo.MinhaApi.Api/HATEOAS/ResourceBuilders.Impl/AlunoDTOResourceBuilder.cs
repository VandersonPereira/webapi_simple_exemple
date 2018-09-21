using Estudo.MinhaApi.Api.DTOs;
using Estudo.MinhaApi.Api.HATEOAS.ResourceBuilders.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;

namespace Estudo.MinhaApi.Api.HATEOAS.ResourceBuilders.Impl
{
    public class AlunoDTOResourceBuilder : IResourceBuilder
    {
        public void BuildResource(object resource, HttpRequestMessage request)
        {
            AlunoDTO dto = resource as AlunoDTO;

            if (dto == null)
            {
                throw new ArgumentException($"Era esperado um AlunoDTO, porém, foi enviado um {resource.GetType().Name}");
            }

            UrlHelper urlHelper = new UrlHelper(request);
            string alunoDTORoute = urlHelper.Link("DefaultApi", new { controller = "Alunos", id = dto.Id });

            // Recuperar o aluno
            dto.Links.Add(new RestLink
            {
                Rel = "self",
                Href = alunoDTORoute
            });

            // Atualizar o aluno
            dto.Links.Add(new RestLink
            {
                Rel = "edit",
                Href = alunoDTORoute
            });

            // Deletar o aluno
            dto.Links.Add(new RestLink
            {
                Rel = "delete",
                Href = alunoDTORoute
            });
        }
    }
}