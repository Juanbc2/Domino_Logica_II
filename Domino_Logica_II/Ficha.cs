using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_Logica_II
{
    public class Ficha
    {

        private int n1, n2,id;

        public Ficha(int n1, int n2, int id)
        {
            this.n1 = n1;
            this.n2 = n2;
            this.id = id;
        }

        public int getN1()
        {
            return this.n1;
        }

        public int getN2()
        {
            return this.n2;
        }

        public int getId()
        {
            return this.id;
        }

        public void mostrarFichaDerIzq()
        {
            Console.WriteLine("|"+this.n1+"|"+this.n2+"|");
        }
        public void mostrarFichaIzqDer()
        {
            Console.WriteLine("|" + this.n2 + "|" + this.n1 + "|");
        }
    }
}
