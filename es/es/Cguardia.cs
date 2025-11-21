using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace es
{
    internal class Cguardia:Cpg
    {
        public event EventHandler guardia_catturata;
        public Cguardia(string nome)
        {
            base.nome = nome;
            base.cattura = true;
        }

        public void catturare_guardia()
        {
            guardia_catturata?.Invoke(this, EventArgs.Empty);
        }

        public override string ToString()
        {
            return $"La guardia {nome} si sta difendendo";
        }
    }
}
