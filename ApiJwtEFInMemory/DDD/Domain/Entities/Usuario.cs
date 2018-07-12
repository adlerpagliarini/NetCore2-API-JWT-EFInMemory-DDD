using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ApiJwtEFInMemory.DDD.Domain.Entities
{
    public class Usuario
    {

        public string ID { get; set; }
        public string ChaveAcesso { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }

        public Usuario()
        {
            Produtos = new Collection<Produto>();
        }
        public bool Equals(Usuario other)
        {
            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return ID.Equals(other.ID) && ChaveAcesso.Equals(other.ChaveAcesso);
        }

        public static bool operator ==(Usuario x, Usuario y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(Usuario x, Usuario y)
        {
            return !(x == y);
        }
    }
}
