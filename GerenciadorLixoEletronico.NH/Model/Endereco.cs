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
    public class Endereco
    {
        public virtual int Id { get; set; }

        [Display(Name = "Nome da Rua")]
        [Required(ErrorMessage = "O nome da rua é obrigatorio.")]
        public virtual string Rua { get; set; }

        [Display(Name = "Numero")]
        [Required(ErrorMessage = "O numero é obrigatorio.")]
        public virtual string Numero { get; set; }

        [Display(Name = "Complemento")]
        public virtual string Complemento { get; set; }

        [Display(Name = "Bairro")]
        public virtual string Bairro { get; set; }

        [Display(Name = "CEP")]
        public virtual string CEP { get; set; }

        [Display(Name = "Nome da Cidade")]
        [Required(ErrorMessage = "A cidade é obrigatoria.")]
        public virtual Cidade Cidade { get; set; }
        

    }

    public class EnderecoMap : ClassMapping<Endereco>
    {
        public EnderecoMap()
        {
            Table("Endereco");

            Id<int>(x => x.Id, m =>
            {
                m.Generator(Generators.Identity);
            });

            Property<string>(x => x.Rua);
            Property<string>(x => x.Numero);
            Property<string>(x => x.Complemento);
            Property<string>(x => x.Bairro);
            Property<string>(x => x.CEP);

            ManyToOne<Cidade>(x => x.Cidade, m =>
            {
                m.Column("IdCidade");
            });
        }
    }
}
