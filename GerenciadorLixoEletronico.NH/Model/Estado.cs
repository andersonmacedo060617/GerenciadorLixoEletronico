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
    public class Estado
    {
        public virtual int Id { get; set; }

        [Display(Name = "Nome do Estado")]
        [Required(ErrorMessage = "O nome do estado é obrigatorio.")]
        public virtual string Nome { get; set; }

        [Display(Name = "Nome do País")]
        [Required(ErrorMessage = "O país é obrigatorio.")]
        public virtual Pais Pais { get; set; }

        public virtual IList<Cidade> Cidades { get; set; }

        public Estado()
        {
            Cidades = new List<Cidade>();
        }

    }

    public class EstadoMap : ClassMapping<Estado>
    {
        public EstadoMap()
        {
            Table("Estado");

            Id<int>(x => x.Id, m =>
            {
                m.Generator(Generators.Identity);
            });

            Property<string>(x => x.Nome);

            ManyToOne<Pais>(x => x.Pais, m =>
            {
                m.Column("IdPais");
            });

            Bag<Cidade>(x => x.Cidades, m =>
            {
                m.Cascade(Cascade.All);
                m.Lazy(CollectionLazy.Lazy);
                m.Inverse(true);
                m.Key(k => k.Column("idEstado"));
            },
                r => r.OneToMany()
            );
        }
    }
}
