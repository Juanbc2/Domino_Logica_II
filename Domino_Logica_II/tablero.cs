using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Media;

namespace Domino_Logica_II
{
    public partial class tablero : Form
    {
        Jugador jj1, jj2, jj3, jj4;
        string j2n, j3n, j4n;
        //reseteables
        int  turno, pasar = 0, puntosJ1 = 0;
        bool juegoiniciado = false;
        private static PictureBox cajonIzqActual, cajonDerActual;
        private static int cajonIzqSum = 0, cajonDerSum = 0;

        //


        PictureBox[] cajonIzq = new PictureBox[18];
        PictureBox[] cajonDer = new PictureBox[16];
        Assembly assembly = Assembly.GetExecutingAssembly();
        Stream stream;
        //delegadas de form1
        private LSL listaFichas = new LSL();
        private LDL listaTablero = new LDL();
        private int[] fichasMezcladas;
        private Ficha[] fichas;




        public tablero(string j2n, string j3n, string j4n, Jugador jj1, Jugador jj2, Jugador jj3, Jugador jj4)
        {
            
            this.j2n = j2n;
            this.j3n = j3n;
            this.j4n = j4n;
            this.jj1 = jj1;
            this.jj2 = jj2;
            this.jj3 = jj3;
            this.jj4 = jj4;
            InitializeComponent();
            crearFichas();
            fichasMezcladas = generarListaRandom();
            inicializarPartida();
        }


        private void tablero_Load(object sender, EventArgs e)
        {
            setCajones();
            cajonDerActual = cajonDer[0];
            cajonIzqActual = cajonIzq[0];
            listaTablero.setPrimero(new nodoDoble(6));
            listaTablero.setUltimo(new nodoDoble(6));
            j2.Text = j2n;
            j3.Text = j3n;
            j4.Text = j4n;
            primerTurno(jj1, jj2, jj3, jj4);
            puntosJ1Acumulados();

        }

        private void puntosJ1Acumulados()
        {
            nodoSimple p = jj1.getFichas().primerNodo();
            Ficha f;
            while (!jj1.getFichas().finDeRecorrido(p))
            {
                f = (Ficha)p.retornaDato();
                puntosJ1 += f.getN1() + f.getN2();
                p = p.retornaLiga();
            }
        }

        private void comenzarJuego()
        {
            if (jj1.getTurno() == 1)
            {
                nodoSimple f1 = jj1.getFichas().primerNodo();
                Ficha fj1 = (Ficha)f1.retornaDato();
                nodoSimple f2 = f1.retornaLiga();
                Ficha fj2 = (Ficha)f2.retornaDato();
                nodoSimple f3 = f2.retornaLiga();
                Ficha fj3 = (Ficha)f3.retornaDato();
                nodoSimple f4 = f3.retornaLiga();
                Ficha fj4 = (Ficha)f4.retornaDato();
                nodoSimple f5 = f4.retornaLiga();
                Ficha fj5 = (Ficha)f5.retornaDato();
                nodoSimple f6 = f5.retornaLiga();
                Ficha fj6 = (Ficha)f6.retornaDato();
                stream = assembly.GetManifestResourceStream("Domino_Logica_II.Resources." + fj1.getId() + ".png");
                ficha1.Image = new Bitmap(stream);

                stream = assembly.GetManifestResourceStream("Domino_Logica_II.Resources." + fj2.getId() + ".png");
                ficha2.Image = new Bitmap(stream);

                stream = assembly.GetManifestResourceStream("Domino_Logica_II.Resources." + fj3.getId() + ".png");
                ficha3.Image = new Bitmap(stream);

                stream = assembly.GetManifestResourceStream("Domino_Logica_II.Resources." + fj4.getId() + ".png");
                ficha4.Image = new Bitmap(stream);

                stream = assembly.GetManifestResourceStream("Domino_Logica_II.Resources." + fj5.getId() + ".png");
                ficha5.Image = new Bitmap(stream);

                stream = assembly.GetManifestResourceStream("Domino_Logica_II.Resources." + fj6.getId() + ".png");
                ficha6.Image = new Bitmap(stream);
            }
            else
            {
                nodoSimple f1 = jj1.getFichas().primerNodo();
                Ficha fj1 = (Ficha)f1.retornaDato();
                nodoSimple f2 = f1.retornaLiga();
                Ficha fj2 = (Ficha)f2.retornaDato();
                nodoSimple f3 = f2.retornaLiga();
                Ficha fj3 = (Ficha)f3.retornaDato();
                nodoSimple f4 = f3.retornaLiga();
                Ficha fj4 = (Ficha)f4.retornaDato();
                nodoSimple f5 = f4.retornaLiga();
                Ficha fj5 = (Ficha)f5.retornaDato();
                nodoSimple f6 = f5.retornaLiga();
                Ficha fj6 = (Ficha)f6.retornaDato();
                nodoSimple f7 = f6.retornaLiga();
                Ficha fj7 = (Ficha)f7.retornaDato();

                stream = assembly.GetManifestResourceStream("Domino_Logica_II.Resources." + fj1.getId() + ".png");
                ficha1.Image = new Bitmap(stream);

                stream = assembly.GetManifestResourceStream("Domino_Logica_II.Resources." + fj2.getId() + ".png");
                ficha2.Image = new Bitmap(stream);

                stream = assembly.GetManifestResourceStream("Domino_Logica_II.Resources." + fj3.getId() + ".png");
                ficha3.Image = new Bitmap(stream);

                stream = assembly.GetManifestResourceStream("Domino_Logica_II.Resources." + fj4.getId() + ".png");
                ficha4.Image = new Bitmap(stream);

                stream = assembly.GetManifestResourceStream("Domino_Logica_II.Resources." + fj5.getId() + ".png");
                ficha5.Image = new Bitmap(stream);

                stream = assembly.GetManifestResourceStream("Domino_Logica_II.Resources." + fj6.getId() + ".png");
                ficha6.Image = new Bitmap(stream);

                stream = assembly.GetManifestResourceStream("Domino_Logica_II.Resources." + fj7.getId() + ".png");
                ficha7.Enabled = true;
                ficha7.Image = new Bitmap(stream);




            }
        }



        private int compararFichas(Ficha fit) //1 para izq, 2 para derecha
        {
            nodoDoble nfi = listaTablero.getPrimero();
            nodoDoble nfd = listaTablero.getUltimo();

            int fi = (int)nfi.retornaDato();
            int fd = (int)nfd.retornaDato();

            if (fit.getN1() == fi)
            {
                listaTablero.insertar(fit.getN2(),null);
                Console.WriteLine(fit.getN2());
                return 1;
            }

            if (fit.getN1() == fd)
            {
                listaTablero.insertar(fit.getN2(),nfd);
                Console.WriteLine(fit.getN2());
                return 2;
            }
            if (fit.getN2() == fi)
            {
                listaTablero.insertar(fit.getN1(),null);
                Console.WriteLine(fit.getN1());
                return 3;
            }

            if (fit.getN2() == fd)
            {
                Console.WriteLine(fit.getN1());
                listaTablero.insertar(fit.getN1(),nfd);
                return 4;
            }
            return 0;

        }





        public void primerTurno(Jugador j1, Jugador j2, Jugador j3, Jugador j4)
        {
            foreach (Ficha f in j1.getVectorFichas())
            {
                if (f.getId() == 27)
                {
                    j1.setTurno(1);
                    j2.setTurno(4);
                    j3.setTurno(2);
                    j4.setTurno(3);
                    renovarLista(j1, f);
                    j1.setCantFichas(j1.getCantFichas() - 1);
                    turno = 1;
                    break;
                }

            }
            foreach (Ficha f in j2.getVectorFichas())
            {
                if (f.getId() == 27)
                {
                    j1.setTurno(2);
                    j2.setTurno(1);
                    j3.setTurno(3);
                    j4.setTurno(4);
                    renovarLista(j2, f);
                    j2.setCantFichas(j2.getCantFichas() - 1);
                    Console.WriteLine(j2.getNombre());
                    turno = 2;
                    break;
                }


            }
            foreach (Ficha f in j3.getVectorFichas())
            {
                if (f.getId() == 27)
                {
                    j1.setTurno(4);
                    j2.setTurno(1);
                    j3.setTurno(1);
                    j4.setTurno(2);
                    renovarLista(j3, f);
                    j3.setCantFichas(j3.getCantFichas() - 1);
                    Console.WriteLine(j3.getNombre());
                    turno = 3;
                    break;

                }


            }
            foreach (Ficha f in j4.getVectorFichas())
            {
                if (f.getId() == 27)
                {
                    j1.setTurno(3);
                    j2.setTurno(2);
                    j3.setTurno(4);
                    j4.setTurno(1);
                    renovarLista(j4, f);
                    j4.setCantFichas(j4.getCantFichas() - 1);
                    Console.WriteLine(j4.getNombre());
                    turno = 4;
                    break;
                }

            }
        }

        private void renovarLista(Jugador j, Ficha f)
        {
            LSL aux = new LSL();
            nodoSimple x = j.getFichas().primerNodo();
            while (!j.getFichas().finDeRecorrido(x))
            {
                if (x.retornaDato() != f)
                {
                    aux.insertar(x.retornaDato(), aux.ultimoNodo());

                }
                x = x.retornaLiga();
            }
            j.setFichas(aux);
        }




        private void colocarFichaBots(Jugador j)
        {
            nodoSimple p = j.getFichas().primerNodo();
            Ficha f;
            while (!j.getFichas().finDeRecorrido(p))
            {
                f = (Ficha)p.retornaDato();
                int x = compararFichas(f);
                if (x == 1 || x == 3)
                {
                    cajonIzqActual = (PictureBox)cajonIzq[cajonIzqSum];
                    cajonIzqSum++;
                    stream = assembly.GetManifestResourceStream("Domino_Logica_II.Resources." + f.getId() + ".png");
                    Image img = new Bitmap(stream);

                    if (x == 1)
                    {
                        img.RotateFlip(RotateFlipType.RotateNoneFlipY);
                    }
                    if (f.getN1() == f.getN2())
                    {
                        img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    }

                    if (cajonIzqSum > 6)
                    {
                        img.RotateFlip(RotateFlipType.Rotate90FlipX);
                    }
                    if (cajonIzqSum > 15)
                    {
                        img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    }
                    if (cajonIzqSum > 17)
                    {
                        img.RotateFlip(RotateFlipType.Rotate90FlipX);
                    }
                    cajonIzqActual.Image = img;
                    cajonIzqActual.Show();
                    j.setCantFichas(j.getCantFichas() - 1);
                    renovarLista(j, f);
                    checarPasar(false);
                    actualizarContador();
                    return;
                }
                else if (x == 2 || x == 4)
                {

                    cajonDerActual = (PictureBox)cajonDer[cajonDerSum];
                    cajonDerSum++;
                    stream = assembly.GetManifestResourceStream("Domino_Logica_II.Resources." + f.getId() + ".png");
                    Image img = new Bitmap(stream);
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    if (x == 4)
                    {
                        img.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    }
                    if (f.getN1() == f.getN2())
                    {
                        img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    }
                    if (cajonDerSum > 9)
                    {
                        img.RotateFlip(RotateFlipType.Rotate270FlipY);
                    }
                    if (cajonDerSum > 11)
                    {
                        img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    }
                    if (cajonDerSum > 14)
                    {
                        img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    }

                    cajonDerActual.Image = img;
                    cajonDerActual.Show();
                    j.setCantFichas(j.getCantFichas() - 1);
                    renovarLista(j, f);
                    checarPasar(false);
                    actualizarContador();
                    return;

                }

                p = p.retornaLiga();
            }
            checarPasar(true);

        }

        private void actualizarContador()
        {
            fichasj2.Text = "Fichas: " + jj2.getCantFichas().ToString();
            fichasj3.Text = "Fichas: " + jj3.getCantFichas().ToString();
            fichasj4.Text = "Fichas: " + jj4.getCantFichas().ToString();
        }

        private void turnoSiguiente()
        {

            if (turno == 3)
            {
                colocarFichaBots(jj4);
                colocarFichaBots(jj2);

            }
            if (turno == 4)
            {

                colocarFichaBots(jj2);
            }
            if (turno == 1)
            {
                colocarFichaBots(jj3);
                colocarFichaBots(jj4);
                colocarFichaBots(jj2);
            }
        }

        private void turnoBots()  //TURNO DE LOS BOTS
        {

            colocarFichaBots(jj3);
            if (comprobarGanador(jj3))
            {
                panel2.Enabled = false;
                button1.Enabled = false;
            }
            else
            {
                colocarFichaBots(jj4);
                if (comprobarGanador(jj4))
                {
                    panel2.Enabled = false;
                    button1.Enabled = false;
                }
                else
                {
                    colocarFichaBots(jj2);
                    if (comprobarGanador(jj2))
                    {
                        panel2.Enabled = false;
                        button1.Enabled = false;
                    }
                }
            }


        }






        private void colocarFichaJugador(PictureBox ficha, Ficha f)
        {

            int x = compararFichas(f);
            if (x == 1 || x == 3)  // FICHA AL LADO IZQUIERDO DEL TABLERO
            {

                cajonIzqActual = (PictureBox)cajonIzq[cajonIzqSum];
                cajonIzqSum++;

                Image img = ficha.Image;
                if (x == 1)
                {
                    img.RotateFlip(RotateFlipType.RotateNoneFlipY);
                }
                if (f.getN1() == f.getN2())
                {
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
                if (cajonIzqSum > 6)
                {
                    img.RotateFlip(RotateFlipType.Rotate90FlipX);
                }
                if (cajonIzqSum > 15)
                {
                    img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                }
                if (cajonIzqSum > 17)
                {
                    img.RotateFlip(RotateFlipType.Rotate90FlipX);
                }
                cajonIzqActual.Image = img;
                cajonIzqActual.Show();
                ficha.Dispose();
                jj1.setCantFichas(jj1.getCantFichas() - 1);
                puntosJ1 -= f.getN1() + f.getN2();
                playSound();
                checarPasar(false);
                if (!comprobarGanador(jj1))
                {
                    turnoBots();
                }
                else
                {
                    panel2.Enabled = false;
                    button1.Enabled = false;
                }

            }
            else if (x == 2 || x == 4) // FICHA AL LADO DERECHO DEL TABLERO
            {

                cajonDerActual = (PictureBox)cajonDer[cajonDerSum];
                cajonDerSum++;

                Image img = ficha.Image;
                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                if (x == 4)
                {
                    img.RotateFlip(RotateFlipType.RotateNoneFlipX);
                }
                if (f.getN1() == f.getN2())
                {
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
                if (cajonDerSum > 9)
                {
                    img.RotateFlip(RotateFlipType.Rotate270FlipY);
                }
                if (cajonDerSum > 11)
                {
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
                if (cajonDerSum > 14)
                {
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }

                cajonDerActual.Image = img;
                cajonDerActual.Show();
                ficha.Dispose();
                jj1.setCantFichas(jj1.getCantFichas() - 1);
                puntosJ1 -= f.getN1() + f.getN2();
                playSound();
                checarPasar(false);
                if (!comprobarGanador(jj1))
                {
                    turnoBots();
                }
                else
                {
                    panel2.Enabled = false;
                    button1.Enabled = false;
                }

            }

            fichasj1.Text = "Fichas: " + jj1.getCantFichas().ToString();

        }


        //Click events---------------------------------------------------------------------------


        private void ficha1_MouseClick(object sender, MouseEventArgs e)
        {
            Ficha f = (Ficha)jj1.getFichas().primerNodo().retornaDato();
            colocarFichaJugador(this.ficha1, f);
        }

        private void ficha2_Click(object sender, EventArgs e)
        {
            Ficha f = (Ficha)jj1.getFichas().primerNodo().retornaLiga().retornaDato();
            colocarFichaJugador(this.ficha2, f);
        }

        private void ficha3_Click(object sender, EventArgs e)
        {
            Ficha f = (Ficha)jj1.getFichas().primerNodo().retornaLiga().retornaLiga().retornaDato();
            colocarFichaJugador(this.ficha3, f);
        }

        private void ficha4_Click(object sender, EventArgs e)
        {
            Ficha f = (Ficha)jj1.getFichas().primerNodo().retornaLiga().retornaLiga().retornaLiga().retornaDato();
            colocarFichaJugador(this.ficha4, f);
        }

        private void ficha5_Click(object sender, EventArgs e)
        {
            Ficha f = (Ficha)jj1.getFichas().primerNodo().retornaLiga().retornaLiga().retornaLiga().retornaLiga().retornaDato();
            colocarFichaJugador(this.ficha5, f);
        }

        private void ficha6_Click(object sender, EventArgs e)
        {
            Ficha f = (Ficha)jj1.getFichas().primerNodo().retornaLiga().retornaLiga().retornaLiga().retornaLiga().retornaLiga().retornaDato();
            colocarFichaJugador(this.ficha6, f);
        }

        private void ficha7_Click(object sender, EventArgs e)
        {
            Ficha f = (Ficha)jj1.getFichas().primerNodo().retornaLiga().retornaLiga().retornaLiga().retornaLiga().retornaLiga().retornaLiga().retornaDato();
            colocarFichaJugador(this.ficha7, f);
        }

        //----------------------------------------------------------------------------------------

        private void setCajones()
        {
            cajonDer[0] = this.d1; cajonDer[1] = this.d2; cajonDer[2] = this.d3; cajonDer[3] = this.d4; cajonDer[4] = this.d5; cajonDer[5] = this.d6; cajonDer[6] = this.d7;
            cajonDer[7] = this.d8; cajonDer[8] = this.d9; cajonDer[9] = this.d10; cajonDer[10] = this.d11; cajonDer[11] = this.d12; cajonDer[12] = this.d13; cajonDer[13] = this.d14;
            cajonDer[14] = this.d15; cajonDer[15] = this.d16;

            cajonIzq[0] = this.i1; cajonIzq[1] = this.i2; cajonIzq[2] = this.i3; cajonIzq[3] = this.i4; cajonIzq[4] = this.i5; cajonIzq[5] = this.i6; cajonIzq[6] = this.i7;
            cajonIzq[7] = this.i8; cajonIzq[8] = this.i9; cajonIzq[9] = this.i10; cajonIzq[10] = this.i11; cajonIzq[11] = this.i12; cajonIzq[12] = this.i13; cajonIzq[13] = this.i14;
            cajonIzq[14] = this.i15; cajonIzq[15] = this.i16; cajonIzq[16] = this.i17; cajonIzq[17] = this.i18;

        }



        private bool comprobarGanador(Jugador j)
        {
            if (j.getCantFichas() == 0)
            {
                j.setPuntos(j.getPuntos() + puntosJ1 + puntosAcumulados(jj2) + puntosAcumulados(jj3) + puntosAcumulados(jj4));
                ganador.Text = j.getNombre() + " Dominó la ronda!!\n";
                //j.setPuntos(contarPuntos());
                marcadores.Text = "Puntos\n"+
                                  "Usted: " + jj1.getPuntos() + "\n" +
                                  jj2.getNombre() + ": " + jj2.getPuntos() + "\n" +
                                  jj3.getNombre() + ": " + jj3.getPuntos() + "\n" +
                                  jj4.getNombre() + ": " + jj4.getPuntos() + "\n";

                sigRonda.Visible = true;
                sigRonda.Enabled = true;
                checarGanadorFinal();
                return true;
            }
            return false;
        }

        private Jugador ganadorAlCierre()
        {
            int pj1 = puntosJ1;
            int pj2 = puntosAcumulados(jj2);
            int pj3 = puntosAcumulados(jj3);
            int pj4 = puntosAcumulados(jj4);
            if (pj1 < pj2 && pj1 < pj3 && pj1 < pj4)
            {
                return jj1;
            }
            if (pj2 < pj1 && pj2 < pj3 && pj2 < pj4)
            {
                return jj2;
            }
            if (pj3 < pj1 && pj3 < pj2 && pj3 < pj4)
            {
                return jj3;
            }
            if (pj4 < pj1 && pj4 < pj2 && pj4 < pj3)
            {
                return jj4;
            }
            else
            {
                return null;
            }


        }

        private int puntosAcumulados(Jugador j)
        {
            nodoSimple p = j.getFichas().primerNodo();
            Ficha f;
            int puntos = 0;
            while (!j.getFichas().finDeRecorrido(p))
            {
                f = (Ficha)p.retornaDato();
                puntos += f.getN1() + f.getN2();
                p = p.retornaLiga();
            }
            return puntos;
        }




        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(turno);
            if (juegoiniciado)
            {
                checarPasar(true);
                turnoBots();
            }
            else
            {
                stream = assembly.GetManifestResourceStream("Domino_Logica_II.Resources.inicial.png");
                Image img = new Bitmap(stream);
                inicial.Image = img;
                turnoSiguiente();
                juegoiniciado = true;
                comenzarJuego();
                this.button1.BackColor = Color.Orange;
                this.button1.ForeColor = Color.Black;
                this.button1.Text = "PASAR";
                this.button1.Hide();
                this.button1.Show();

            }
        }

        private void checarPasar(bool r)
        {

            if (r)
            {
                Console.WriteLine("Alguien pasó, van:" + pasar);
                pasar++;
            }
            else
            {
                pasar = 0;
            }
            if (pasar == 4)
            {
                Console.WriteLine("Se cerró.");
                Jugador j = ganadorAlCierre();
                int difPuntos = puntosJ1 - puntosAcumulados(jj2) - puntosAcumulados(jj3) - puntosAcumulados(jj4);
                if (difPuntos<0)
                {
                    difPuntos = difPuntos * -1;
                }
                j.setPuntos(difPuntos);                  
                

                ganador.Text = j.getNombre() + " Dominó la ronda cerrada!!\n";
                //j.setPuntos(contarPuntos());
                marcadores.Text = "Puntos\n" + 
                                  "Usted: " + jj1.getPuntos() + "\n" +
                                  jj2.getNombre() + ": " + jj2.getPuntos() + "\n" +
                                  jj3.getNombre() + ": " + jj3.getPuntos() + "\n" +
                                  jj4.getNombre() + ": " + jj4.getPuntos() + "\n";

                pasar = 0;
                panel2.Enabled = false;
                button1.Enabled = false;
                sigRonda.Visible = true;
                sigRonda.Enabled = true;
                checarGanadorFinal();
            }

        }

        private void sigRonda_Click(object sender, EventArgs e)
        {
            jj1.resetear();
            jj2.resetear();
            jj3.resetear();
            jj4.resetear();
            pasar = 0; puntosJ1 = 0; pasar = 0;
            juegoiniciado = false;
            cajonIzqActual = null; cajonDerActual = null;
            cajonIzqSum = 0; cajonDerSum = 0;
            inicializarPartida();
            tablero tableroJuego = new tablero(j2n, j3n, j4n, jj1, jj2, jj3, jj4);
            this.Hide();
            tableroJuego.Show();

        }

        private void checarGanadorFinal()
        {
            if (jj1.getPuntos() >= 101)
            {
                ganador.Text = "Ha ganado Usted!!\n";
                sigRonda.Enabled = false;
                sigRonda.Visible = false;
                salir.Enabled = true;
                salir.Visible = true;
            }
            else if (jj2.getPuntos() >= 101)
            {
                ganador.Text = "Ha ganado "+jj2.getNombre()+"!!";
                sigRonda.Enabled = false;
                sigRonda.Visible = false;
                salir.Enabled = true;
                salir.Visible = true;
            }
            else if (jj3.getPuntos() >= 101)
            {
                ganador.Text = "Ha ganado " + jj3.getNombre() + "!!";
                sigRonda.Enabled = false;
                sigRonda.Visible = false;
                salir.Enabled = true;
                salir.Visible = true;
            }
            else if (jj4.getPuntos() >= 101)
            {
                ganador.Text = "Ha ganado " + jj4.getNombre() + "!!";
                sigRonda.Enabled = false;
                sigRonda.Visible = false;
                salir.Enabled = true;
                salir.Visible = true;
            }
        }

        public void inicializarPartida()
        {

            crearlistaFichas();
            repartirFichas(jj1, 0);
            repartirFichas(jj2, 1);
            repartirFichas(jj3, 2);
            repartirFichas(jj4, 3);
            fichasToLSL(jj1);
            fichasToLSL(jj2);
            fichasToLSL(jj3);
            fichasToLSL(jj4);

        }

        //MANEJO DE FICHAS 
        public void crearFichas()
        {
            fichas = new Ficha[28];
            int j = 0;
            for (int i = 0; i <= 6; i++)
            {

                for (int k = i; k <= 6; k++)
                {

                    fichas[j] = new Ficha(i, k, j);
                    j++;
                }
            }
        }

        public void crearlistaFichas()
        {
            listaFichas = new LSL();
            int j = 0;
            for (int i = 0; i <= 6; i++)
            {

                for (int k = i; k <= 6; k++)
                {
                    listaFichas.insertar(new Ficha(i, k, j), listaFichas.ultimoNodo());
                    j++;
                }

            }
        }

        public int[] generarListaRandom()
        {
            Random rd1 = new Random();
            int[] numFichas = new int[28];
            for (int i = 0; i < 28; i++)
            {
                int aux = 0;
                while (isInList(numFichas, aux) == true)
                { //si el número está en la lista, buscar otro
                    aux = rd1.Next(1, 29);
                }
                numFichas[i] = aux;
            }
            return numFichas;
        }




        public void repartirFichas(Jugador j, int turno)
        {
            for (int i = 0 + (7 * turno); i < 7 + (7 * turno); i++)
            {
                j.setVectorFichas(i - (7 * turno), fichas[fichasMezcladas[i] - 1]);
            }
        }


        public void fichasToLSL(Jugador j)
        {
            int i = 0;
            LSL aux = new LSL();
            while (i != 7)
            {
                aux.insertar(j.getVectorFichas()[i], aux.ultimoNodo());
                i++;
            }
            j.setFichas(aux);
        }

        public Boolean isInList(int[] list, int value)
        {
            int i = 0;
            while (i < 28)
            {
                if (value == list[i])
                {
                    return true;
                }
                i++;
            }
            return false;
        }
        //-----------------------------------------------------------------------------------
        private void playSound()
        {
            stream = assembly.GetManifestResourceStream("Domino_Logica_II.Resources.fichaSound.wav");
            SoundPlayer snd = new SoundPlayer(stream);
            snd.Play();
        }

        private void tablero_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void salir_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }

}

