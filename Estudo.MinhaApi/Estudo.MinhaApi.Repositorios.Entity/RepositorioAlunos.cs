using Estudo.Comum.Repositorios.Entity;
using Estudo.MinhaApi.AcessoADados.Entity.Context;
using Estudo.MinhaApi.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudo.MinhaApi.Repositorios.Entity
{
    public class RepositorioAlunos : RepositorioEstudo<Aluno, int>
    {
        public RepositorioAlunos(MinhaApiDbContext context)
            :base(context)
        {

        }
    }
}
