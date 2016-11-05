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
    public class PostoDeColeta
    {
        public virtual int Id { get; set; }

        [Display(Name = "Nome do Local")]
        [Required(ErrorMessage = "O nome é obrigatorio.")]
        public virtual string Nome { get; set; }

        [Display(Name = "Tipo de Estabelecimento")]
        public virtual string TipoEstabelecimento { get; set; }

        [Display(Name = "Horario de funcionamento")]
        public virtual string HorarioFuncionamento { get; set; }

        public virtual Endereco Endereco { get; set; }

        [Display(Name = "Localização Cidade Google Maps.")]
        public virtual string LocalizacaoMap { get; set; }

    }

    public class PostoDeColetaMap : ClassMapping<PostoDeColeta>
    {
        public PostoDeColetaMap()
        {
            Table("Posto_Coleta");

            Id<int>(x => x.Id, m =>
            {
                m.Generator(Generators.Identity);
            });

            Property<string>(x => x.Nome);
            Property<string>(x => x.TipoEstabelecimento);
            Property<string>(x => x.HorarioFuncionamento);
            Property<string>(x => x.LocalizacaoMap, x => x.Length(1000));

            ManyToOne<Endereco>(x => x.Endereco, m =>
            {
                m.Column("IdEndereco");
            });
        }
    }
}
