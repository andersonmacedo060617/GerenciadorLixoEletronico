using GerenciadorLixoEletronico.NH.Model;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorLixoEletronico.NH.Repository
{
    public class EnderecoRepository
    {
        private ISession session;
        public EnderecoRepository(ISession session)
        {
            this.session = session;
        }

        public IList<Endereco> GetAll()
        {
            var enderecos = this.session.CreateCriteria<Endereco>().List<Endereco>();
            return enderecos;
        }

        public bool Gravar(Endereco endereco)
        {
            try
            {
                session.Clear();
                var transacao = this.session.BeginTransaction();
                this.session.SaveOrUpdate(endereco);


                transacao.Commit();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Excluir(Endereco endereco)
        {
            try
            {
                session.Clear();
                var transacao = this.session.BeginTransaction();
                this.session.Delete(endereco);

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
