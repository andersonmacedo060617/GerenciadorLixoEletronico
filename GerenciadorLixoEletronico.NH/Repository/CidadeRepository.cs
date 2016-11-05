using GerenciadorLixoEletronico.NH.Model;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorLixoEletronico.NH.Repository
{
    public class CidadeRepository
    {
        private ISession session;
        public CidadeRepository(ISession session)
        {
            this.session = session;
        }

        public IList<Cidade> GetAll()
        {
            session.Clear();
            var cidades = this.session.CreateCriteria<Cidade>().List<Cidade>();
            return cidades;
        }

        public bool Gravar(Cidade cidade)
        {
            try
            {
                session.Clear();
                var transacao = this.session.BeginTransaction();
                this.session.SaveOrUpdate(cidade);


                transacao.Commit();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Excluir(Cidade cidade)
        {
            try
            {
                session.Clear();
                var transacao = this.session.BeginTransaction();
                this.session.Delete(cidade);

                transacao.Commit();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
