using GerenciadorLixoEletronico.NH.Model;
using GerenciadorLixoEletronico.NH.Repository;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Context;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GerenciadorLixoEletronico.NH.Config
{
    public class ConfigDB
    {
        public static string StringConexao =
            "Persist Security Info=False;server=192.168.11.200;port=3306;" +
            "database=GerenciadorLixoEletronico;uid=root;pwd=root";

        private ISessionFactory SessionFactory;

        private static ConfigDB _instance = null;
        public static ConfigDB Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ConfigDB();
                }

                return _instance;
            }
        }



        public CidadeRepository CidadeRepository { get; set; }
        public EnderecoRepository EnderecoRepository { get; set; }
        public EstadoRepository EstadoRepository { get; set; }
        public PaisRepository PaisRepository { get; set; }
        public PostoDeColetaRepository PostoDeColetaRepository { get; set; }
        public UsuarioRepository UsuarioRepository { get; set; }
        public SolicitacaoDeColetaRepository SolicitacaoDeColetaRepository { get; set; }

        public ConfigDB()
        {
            if (Conexao())
            {
                this.CidadeRepository = new CidadeRepository(Session);
                this.EnderecoRepository = new EnderecoRepository(Session);
                this.EstadoRepository = new EstadoRepository(Session);
                this.PaisRepository = new PaisRepository(Session);
                this.PostoDeColetaRepository = new PostoDeColetaRepository(Session);
                this.UsuarioRepository = new UsuarioRepository(Session);
                this.SolicitacaoDeColetaRepository = new SolicitacaoDeColetaRepository(Session);
            }
        }


        private bool Conexao()
        {
            //Cria a configuração com o NH
            var config = new Configuration();
            try
            {
                //Integração com o Banco de Dados
                config.DataBaseIntegration(c =>
                {
                    //Dialeto de Banco
                    c.Dialect<NHibernate.Dialect.MySQLDialect>();
                    //Conexao String
                    c.ConnectionString = StringConexao;
                    //Drive de conexão com o banco
                    c.Driver<NHibernate.Driver.MySqlDataDriver>();
                    // Provedor de conexão do MySQL 
                    c.ConnectionProvider<NHibernate.Connection.DriverConnectionProvider>();
                    // GERA LOG DOS SQL EXECUTADOS NO CONSOLE
                    c.LogSqlInConsole = true;
                    // DESCOMENTAR CASO QUEIRA VISUALIZAR O LOG DE SQL FORMATADO NO CONSOLE
                    c.LogFormattedSql = true;
                    // CRIA O SCHEMA DO BANCO DE DADOS SEMPRE QUE A CONFIGURATION FOR UTILIZADA
                    c.SchemaAction = SchemaAutoAction.Update;
                });

                //Realiza o mapeamento das classes
                var maps = this.Mapeamento();
                config.AddMapping(maps);

                //Verifico se a aplicação é Desktop ou Web
                if (HttpContext.Current == null)
                {
                    config.CurrentSessionContext<ThreadStaticSessionContext>();
                }
                else
                {
                    config.CurrentSessionContext<WebSessionContext>();
                }

                this.SessionFactory = config.BuildSessionFactory();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private HbmMapping Mapeamento()
        {
            try
            {
                var mapper = new ModelMapper();

                mapper.AddMappings(
                    Assembly.GetAssembly(typeof(CidadeMap)).GetTypes()
                );
                mapper.AddMappings(
                    Assembly.GetAssembly(typeof(EstadoMap)).GetTypes()
                );
                mapper.AddMappings(
                    Assembly.GetAssembly(typeof(EnderecoMap)).GetTypes()
                );
                mapper.AddMappings(
                    Assembly.GetAssembly(typeof(PaisMap)).GetTypes()
                );
                mapper.AddMappings(
                    Assembly.GetAssembly(typeof(PostoDeColetaMap)).GetTypes()
                );
                mapper.AddMappings(
                    Assembly.GetAssembly(typeof(UsuarioRepository)).GetTypes()
                );
                mapper.AddMappings(
                    Assembly.GetAssembly(typeof(SolicitacaoDeColetaRepository)).GetTypes()
                );
                return mapper.CompileMappingForAllExplicitlyAddedEntities();
            }
            catch (Exception)
            {
                throw;

            }
        }

        private ISession Session
        {
            get
            {

                try
                {
                    if (CurrentSessionContext.HasBind(SessionFactory))
                    {
                        return SessionFactory.GetCurrentSession();

                    }
                    var session = SessionFactory.OpenSession();
                    CurrentSessionContext.Bind(session);
                    return session;
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }
    }
}
