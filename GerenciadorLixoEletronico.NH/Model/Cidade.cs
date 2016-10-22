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
    public class Cidade
    {
        public virtual int Id { get; set; }

        [Display(Name = "Nome da Cidade")]
        [Required(ErrorMessage = "O nome do estado é obrigatorio.")]
        public virtual string Nome { get; set; }

        [Display(Name = "Nome do Estado")]
        [Required(ErrorMessage = "O estado é obrigatorio.")]
        public virtual Estado Estado { get; set; }

    }

    public class CidadeMap : ClassMapping<Cidade>
    {
        public CidadeMap()
        {
            Table("Cidade");

            Id<int>(x => x.Id, m =>
            {
                m.Generator(Generators.Identity);
            });

            Property<string>(x => x.Nome);

            ManyToOne<Estado>(x => x.Estado, m =>
            {
                m.Column("IdEstado");
            });
        }
    }
}
