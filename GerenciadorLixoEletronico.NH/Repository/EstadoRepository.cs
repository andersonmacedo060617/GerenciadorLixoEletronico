using GerenciadorLixoEletronico.NH.Model;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorLixoEletronico.NH.Repository
{
       
    public class EstadoRepository
    {
        private ISession session;
        public EstadoRepository(ISession session)
        {
            this.session = session;
        }

        public IList<Estado> GetAll()
        {
            var estados = this.session.CreateCriteria<Estado>().List<Estado>();
            return estados;
        }

        public bool Gravar(Estado estado)
        {
            try
            {
                session.Clear();
                var transacao = this.session.BeginTransaction();
                this.session.SaveOrUpdate(estado);


                transacao.Commit();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Excluir(Estado estado)
        {
            try
            {
                session.Clear();
                var transacao = this.session.BeginTransaction();
                this.session.Delete(estado);

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
