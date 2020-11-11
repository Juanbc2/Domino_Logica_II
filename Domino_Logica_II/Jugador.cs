using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino_Logica_II
{
    public class Jugador
    {
        private int cantFichas = 7;
        private int puntos = 0;
        private string nombre;
        private int turno;
        private LSL fichas;
        private Ficha[] vectorFichas = new Ficha[7];

        public Jugador(string nombre)
        {
            this.nombre = nombre;
            
        }

        public int getTurno()
        {
            return this.turno;
        }

        public void setTurno(int turno)
        {
            this.turno = turno;
        }

        public void setVectorFichas(int i,Ficha numFicha)
        {
            this.vectorFichas[i] = numFicha;
        }

        public Ficha[] getVectorFichas()
        {
            return this.vectorFichas;
        }
        public int getCantFichas()
        {
            return cantFichas;
        }
        public void setCantFichas(int cantFichas)
        {
            this.cantFichas = cantFichas;
        }

        public string getNombre()
        {
            return this.nombre;
        }

        public int getPuntos()
        {
            return this.puntos;
        }
        public void setPuntos(int puntos)
        {
            this.puntos += puntos;
        }

        public void setFichas(LSL fichas)
        {
            this.fichas = fichas;
        }

        public LSL getFichas()
        {
            return this.fichas;
        }

        public void resetear()
        {
            this.setCantFichas(7);
            this.setFichas(null);
            this.setTurno(0);
            this.setVectorFichas(0,null);
        }


    }
}
