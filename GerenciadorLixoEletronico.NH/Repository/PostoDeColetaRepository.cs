using GerenciadorLixoEletronico.NH.Model;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorLixoEletronico.NH.Repository
{
    
    public class PostoDeColetaRepository
    {
        private ISession session;
        public PostoDeColetaRepository(ISession session)
        {
            this.session = session;
        }

        public IList<PostoDeColeta> GetAll()
        {
            var postosDeColeta = this.session.CreateCriteria<PostoDeColeta>().List<PostoDeColeta>();
            return postosDeColeta;
        }

        public bool Gravar(PostoDeColeta postoDeColeta)
        {
            try
            {
                session.Clear();
                var transacao = this.session.BeginTransaction();
                this.session.SaveOrUpdate(postoDeColeta);
                
                transacao.Commit();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Excluir(PostoDeColeta postoDeColeta)
        {
            try
            {
                session.Clear();
                var transacao = this.session.BeginTransaction();
                this.session.Delete(postoDeColeta);

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
