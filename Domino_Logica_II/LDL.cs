using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_Logica_II
{
    public class LDL
    {

        private nodoDoble primero, ultimo;

        public LDL()
        {
        }

        public void setPrimero(nodoDoble primero)
        {
            this.primero = primero;
        }
        public void setUltimo(nodoDoble ultimo)
        {
            this.ultimo = ultimo;
        }
        public nodoDoble getPrimero()
        {
            return this.primero;
        }
        public nodoDoble getUltimo()
        {
            return this.ultimo;
        }
        public Boolean esVacia()
        {
            if (primero == null) return true;
            return false;
        }
        public Boolean finDeRecorrido(nodoDoble p)
        {
            if (p == null)
            {
                return true;
            }
            return false;
        }

        public void recorreIzqDer()
        {
            nodoDoble p = getPrimero();
            while (!finDeRecorrido(p))
            {
                Console.WriteLine(p.retornaDato());
                p = p.retornaLd();
            }
        }
        public void recorreDerIzq()
        {
            nodoDoble p = getUltimo();
            while (!finDeRecorrido(p))
            {
                Console.WriteLine(p.retornaDato());
                p = p.retornaLi();
            }
        }
        public nodoDoble buscarDondeInsertar(object d)
        {
            nodoDoble p = getPrimero();
            nodoDoble y = anterior(p);
            while (!finDeRecorrido(p) && (int)p.retornaDato() < (int)d) //REVISAR EN CASO DE ERROR
            {
                y = p;
                p = p.retornaLd();
            }
            return y;
        }

        public void insertar(object d, nodoDoble y)
        {
            nodoDoble x = new nodoDoble(d);
            conectar(x, y);
        }


        public void conectar(nodoDoble x, nodoDoble y)
        {
            if (y == null)
            {
                if (primero == null)
                {
                    ultimo = x;
                }
                else
                {
                    x.asignaLd(primero);
                    primero.asignaLi(x);
                }
                primero = x;
                return;
            }
            if (y == ultimo)
            {
                x.asignaLi(y);
                y.asignaLd(x);
                ultimo = x;
            }
            else
            {
                x.asignaLi(y);
                x.asignaLd(y.retornaLd());
                y.asignaLd(x);
                y.retornaLd().asignaLi(x);

            }
        }
        public nodoDoble buscarDato(object d)
        {
            nodoDoble p = getPrimero();
            while (!finDeRecorrido(p) && !p.retornaDato().Equals(d))
            {

                    p = p.retornaLd();
                
            }
            return p;
        }

        public void borrar(nodoDoble x)
        {
            if (x == null)
            {
                Console.WriteLine("Not found");
                return;
            }
            desconectar(x);
        }
        public void desconectar(nodoDoble x)
        {
            if (primero == x)
            {
                primero = x.retornaLd();
                if (primero == null)
                {
                    ultimo = null;
                }
                else
                {
                    primero.asignaLi(null);
                }
                return;
            }
            if (x == ultimo)
            {
                ultimo = x.retornaLi();
                ultimo.asignaLd(null);

            }
            else
            {
                x.retornaLi().asignaLd(x.retornaLd());
                x.retornaLd().asignaLi(x.retornaLi());
            }
        }

        public nodoDoble anterior(nodoDoble x)
        {
            nodoDoble p = getPrimero();
            while (p.retornaLi() != x)
            {
                p = p.retornaLi();
            }
            return p;

        }


    }
}
