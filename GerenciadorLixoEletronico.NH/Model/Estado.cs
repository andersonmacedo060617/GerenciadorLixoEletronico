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
        }
    }
}
