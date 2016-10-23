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
    public class Usuario
    {
        public virtual int Id { get; set; }

        [Display(Name = "Nome:")]
        [Required(ErrorMessage = "O nome é obrigatorio.")]
        public virtual string Nome { get; set; }

        [Display(Name = "Login")]
        [Required(ErrorMessage = "O Login é obrigatorio.")]
        public virtual string Login { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "A Senha é obrigatoria.")]
        public virtual string Senha { get; set; }
    }

    public class UsuarioMap : ClassMapping<Usuario>
    {
        public UsuarioMap()
        {
            Table("Usuario");

            Id<int>(x => x.Id, m =>
            {
                m.Generator(Generators.Identity);
            });

            Property<string>(x => x.Nome);
            Property<string>(x => x.Login);
            Property<string>(x => x.Senha);
            
        }
    }
}
