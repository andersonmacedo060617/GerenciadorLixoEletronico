using GerenciadorLixoEletronico.NH.Model;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorLixoEletronico.NH.Repository
{
    

    public class SolicitacaoDeColetaRepository
    {
        private ISession session;
        public SolicitacaoDeColetaRepository(ISession session)
        {
            this.session = session;
        }

        public IList<SolicitacaoDeColeta> GetAll()
        {
            var solicitacoesDeColeta = this.session.CreateCriteria<SolicitacaoDeColeta>().List<SolicitacaoDeColeta>();
            return solicitacoesDeColeta;
        }

        public bool Gravar(SolicitacaoDeColeta solicitacaoDeColeta)
        {
            try
            {
                session.Clear();
                var transacao = this.session.BeginTransaction();
                this.session.SaveOrUpdate(solicitacaoDeColeta);

                transacao.Commit();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Excluir(SolicitacaoDeColeta solicitacaoDeColeta)
        {
            try
            {
                session.Clear();
                var transacao = this.session.BeginTransaction();
                this.session.Delete(solicitacaoDeColeta);

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
