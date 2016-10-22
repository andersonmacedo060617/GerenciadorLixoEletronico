using GerenciadorLixoEletronico.NH.Model;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorLixoEletronico.NH.Repository
{
    public class PaisRepository
    {
        private ISession session;
        public PaisRepository(ISession session)
        {
            this.session = session;
        }

        public IList<Pais> GetAll()
        {
            var paises = this.session.CreateCriteria<Pais>().List<Pais>();
            return paises;
        }

        public bool Gravar(Pais pais)
        {
            try
            {
                session.Clear();
                var transacao = this.session.BeginTransaction();
                this.session.SaveOrUpdate(pais);


                transacao.Commit();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Excluir(Pais pais)
        {
            try
            {
                session.Clear();
                var transacao = this.session.BeginTransaction();
                this.session.Delete(pais);

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
