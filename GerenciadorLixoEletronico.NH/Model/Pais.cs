using NHibernate.Mapping;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace GerenciadorLixoEletronico.NH.Model
{
    public class Pais
    {
        public virtual int Id { get; set; }

        [Display(Name = "Nome do País")]
        [Required(ErrorMessage = "O nome do país é obrigatorio.")]
        public virtual string Nome { get; set; }

        public virtual IList<Estado> Estados { get; set; }
        
        public Pais()
        {
            Estados = new List<Estado>();
        }
    }

    public class PaisMap: ClassMapping<Pais>
    {
        public PaisMap()
        {
            Table("Pais");

            Id<int>(x => x.Id, m =>
              {
                  m.Generator(Generators.Identity);
  
              });

            Property<string>(x => x.Nome);

            Bag<Estado>(x => x.Estados, m =>
            {
                m.Cascade(Cascade.All);
                m.Lazy(CollectionLazy.Lazy);
                m.Inverse(true);
                m.Key(k => k.Column("IdPais"));
            },
                r => r.OneToMany()
            );
        }
        
    }
}
