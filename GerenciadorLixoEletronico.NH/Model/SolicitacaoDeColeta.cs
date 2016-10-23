using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorLixoEletronico.NH.Model
{
    
    public class SolicitacaoDeColeta
    {
        public virtual int Id { get; set; }

        [Display(Name = "Nome do Responsavel:")]
        [Required(ErrorMessage = "O nome é obrigatorio.")]
        public virtual string Nome { get; set; }
        
        public virtual Endereco Endereco { get; set; }

        [Display(Name = "Descrição do Material:")]
        public virtual string Material { get; set; }

        [Display(Name = "Horario desejado:")]
        public virtual string Horario { get; set; }

        [Display(Name = "Coleta Executada:")]
        public virtual bool Executado { get; set; }

    }

    public class SolicitacaoDeColetaMap : ClassMapping<SolicitacaoDeColeta>
    {
        public SolicitacaoDeColetaMap()
        {
            Table("SolicitacaoDeColeta");

            Id<int>(x => x.Id, m =>
            {
                m.Generator(Generators.Identity);
            });

            Property<string>(x => x.Nome);
            Property<string>(x => x.Horario);
            Property<bool>(x => x.Executado);
            Property<string>(x => x.Material);

            ManyToOne<Endereco>(x => x.Endereco, m =>
            {
                m.Column("IdEndereco");
            });

        }
    }
}
