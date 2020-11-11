using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_Logica_II
{
    public class nodoSimple
    {
        private object dato;
        private nodoSimple liga;

        public nodoSimple(object d)
        {
            this.dato = d;
            liga = null;
        }

        public void asignaDato(object d)
        {
            this.dato = d;
        }

        public void asignaLiga(nodoSimple x)
        {
            this.liga = x;
        }

        public object retornaDato()
        {
            return this.dato;
        }

        public nodoSimple retornaLiga()
        {
            return this.liga;
        }
    }
}
