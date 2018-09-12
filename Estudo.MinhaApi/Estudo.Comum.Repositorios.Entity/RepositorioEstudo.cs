using Estudo.Comum.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Estudo.Comum.Repositorios.Entity
{
    public abstract class RepositorioEstudo<TDominio, TChave> : IRepositorioEstudo<TDominio, TChave>
        where TDominio : class
    {
        protected DbContext _context;

        public RepositorioEstudo(DbContext context)
        {
            _context = context;
        }

        public List<TDominio> Selecionar(Expression<Func<TDominio, bool>> where = null)
        {
            DbSet<TDominio> dbset = _context.Set<TDominio>();
            if (where == null)
                return dbset.ToList();
            else
                return dbset.Where(where).ToList();
        }

        public TDominio SelecionarPorId(TChave id)
        {
            return _context.Set<TDominio>().Find(id);
        }

        public void Inserir(TDominio dominio)
        {
            _context.Set<TDominio>().Add(dominio);
            _context.SaveChanges();
        }

        public void Atualizar(TDominio dominio)
        {
            _context.Entry(dominio).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Excluir(TDominio dominio)
        {
            _context.Entry(dominio).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void ExcluirPorId(TChave id)
        {
            TDominio dominio = SelecionarPorId(id);
            Excluir(dominio);
        }
    }
}
