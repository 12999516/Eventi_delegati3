using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace es
{
    internal class Cre:Cpg
    {
        public event EventHandler re_attaccato;
        public Cre(string nome)
        {
            base.nome = nome;
            base.cattura = false;
        }

        public void attaccare_re()
        {
            re_attaccato?.Invoke(this, EventArgs.Empty);
        }

        public override string ToString()
        {
            return $"il re {nome} è sotto attacco";
        }
    }
}
