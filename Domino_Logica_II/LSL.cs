using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_Logica_II
{
    public class LSL
    {
        private nodoSimple primero, ultimo;
        public int n=0; //testing

        public LSL()
        {

        }

        public nodoSimple primerNodo()
        {
            return this.primero;
        }
        public nodoSimple ultimoNodo()
        {
            return this.ultimo;

        }

        public Boolean esVacia()
        {
            if (primero == null)
            {
                return true;
            }
            return false;
        }
        public Boolean finDeRecorrido(nodoSimple p)
        {
            if (p== null)
            {
                return true;
            }
            return false;
        }

        public nodoSimple anterior(nodoSimple x)
        {
            nodoSimple p = primerNodo();
            while (p != x)
            {
                p = p.retornaLiga();
            }
            return p;

        }

        public void  mostrarLista(){
         nodoSimple p = primerNodo();
         while  (!finDeRecorrido(p)){
                 Console.Write(p.retornaDato()+",");
                 p = p.retornaLiga();
         }
        }


        public nodoSimple buscarDondeInsertar(object d)
        {
            nodoSimple p = primerNodo();
            nodoSimple y = anterior(p);
            while (p != null)
            {
                if ((int)p.retornaDato() > (int)d)
                {
                    break;
                }
                y = p;
                p = p.retornaLiga();

            }
            return y;
        }
        public void insertar(object d, nodoSimple y)
        {
            nodoSimple x = new nodoSimple(d);
            conectar(x, y);

        }
        public void conectar(nodoSimple x, nodoSimple y)
        {
            n++; //testing
            if (y == null)
            {
                if (primero == null) {
                    primero = x;
                    ultimo = x; 
                }
                else
                {
                    x.asignaLiga(primero);
                }
                return;
            }
            x.asignaLiga(y.retornaLiga());
            y.asignaLiga(x);
            if (y == ultimo) { ultimo = x; }
        }

        public nodoSimple buscarDato(object d, nodoSimple y)
        {
            nodoSimple x = primerNodo();
            while (!finDeRecorrido(x) && x.retornaDato() != d)
            {
                y.asignaDato(x);
                x = x.retornaLiga();
            }
            return x;
        }
        public void borrar(nodoSimple x, nodoSimple y)
        {
            if (x == null)
            {
                Console.WriteLine("no existe.");
                return;
            }
            desconectar(x, y);
        }
        public void desconectar(nodoSimple x, nodoSimple y) 
        {
            if (y == null)
            {
                if (primero == ultimo)
                {
                    ultimo = null;
                    primero = x.retornaLiga();
                }
                else
                {
                    y.asignaLiga(x.retornaLiga());
                    if (x == ultimo)
                    {
                        ultimo = y;
                    }
                }
            }
        }



        public nodoSimple menorDato(nodoSimple y)
        {
            nodoSimple menor = primerNodo();
            nodoSimple q = menor;
            nodoSimple p = q.retornaLiga();
            while (!finDeRecorrido(p))
            {
                if ((int)p.retornaDato() < (int)menor.retornaDato())
                {
                    menor = p;
                    y.asignaDato(q);
                }
                q = p;
                p = p.retornaLiga();
            }
            return menor;
        }

        public void intercambiar(nodoSimple p, nodoSimple ap, nodoSimple q, nodoSimple aq)
        {
            if (p == q)
            {
                return;
            }
            desconectar(p, aq);
            if (ap == q)
            {
                conectar(p, aq);
            }
            else
            {
                if (aq == p)
                {
                    conectar(p, q);
                }
                else
                {
                    desconectar(q, aq);
                    conectar(p, aq);
                    conectar(q, ap);
                }
            }
        }

    }
}
