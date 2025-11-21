using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace es
{
    internal class Cpedone:Cpg
    {
        public event EventHandler pedone_catturato;
        public Cpedone(string nome)
        {
            base.nome = nome;
            base.cattura = true;
        }

        public void catturare_pedone()
        {
            pedone_catturato?.Invoke(this, EventArgs.Empty);
        }

        public override string ToString()
        {
            return $"il pedone {nome} si sta preparando";
        }
    }
}
