using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinkyYCerebro
{
    class Program
    {

        static void ImprimirMatriz(int[,] matriz)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" C = Cerebro ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" P = Pinky ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" ■ = Queso");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(" ■ = Aceituna ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(" ■ = Chocolate\n\n ");

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    switch (matriz[i, j])
                    {
                        case 0:
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" ■ ");
                            break;
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" C ");
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(" P ");
                            break;
                        case 3:
                            //queso
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write(" ■ ");
                            break;
                        case 4:
                            //aceituna
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write(" ■ ");
                            break;
                        case 5:
                            //chocolate
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(" ■ ");
                            break;

                    }
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Black;
        }

        static void InicializarMatriz(int[,] matriz, int elemento)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    matriz[i, j] = elemento;
                }
            }
        }

        static void Proceso(int[,] tablero, int[] puntajes, bool scaner, int filaActual, int filaActual2, int columnaActual, int columnaActual2)
        {
            int turnos = 0;
            ConsoleKeyInfo direccion;
            do
            {
                Console.WriteLine(" Turno de Cerebro\n");
                Console.WriteLine(" Puntos de Cerebro: " + puntajes[0] + "\n");
                Console.WriteLine(" Puntos de Pinky: " + puntajes[1] + "\n");
                ImprimirMatriz(tablero);
                turnos++;

                do
                {
                    scaner = true;
                    direccion = Console.ReadKey(true);
                    if (direccion.Key != ConsoleKey.UpArrow && direccion.Key != ConsoleKey.DownArrow && direccion.Key != ConsoleKey.RightArrow && direccion.Key != ConsoleKey.LeftArrow) scaner = false;
                    switch (direccion.Key)
                    {
                        case ConsoleKey.UpArrow:
                            MoverPortal(tablero, ref filaActual, ref columnaActual, ref scaner, filaActual - 1, columnaActual, puntajes, turnos);
                            break;
                        case ConsoleKey.DownArrow:
                            MoverPortal(tablero, ref filaActual, ref columnaActual, ref scaner, filaActual + 1, columnaActual, puntajes, turnos);
                            break;
                        case ConsoleKey.RightArrow:
                            MoverPortal(tablero, ref filaActual, ref columnaActual, ref scaner, filaActual, columnaActual + 1, puntajes, turnos);
                            break;
                        case ConsoleKey.LeftArrow:
                            MoverPortal(tablero, ref filaActual, ref columnaActual, ref scaner, filaActual, columnaActual - 1, puntajes, turnos);
                            break;
                    }
                } while (!scaner);

                Console.Clear();
                Console.WriteLine(" Turno de Pinky\n");
                Console.WriteLine(" Puntos de Cerebro: " + puntajes[0] + "\n");
                Console.WriteLine(" Puntos de Pinky: " + puntajes[1] + "\n");
                ImprimirMatriz(tablero);


                turnos++;
                do
                {
                    scaner = true;
                    direccion = Console.ReadKey(true);
                    if (direccion.Key != ConsoleKey.W && direccion.Key != ConsoleKey.S && direccion.Key != ConsoleKey.D && direccion.Key != ConsoleKey.A) scaner = false;
                    switch (direccion.Key)
                    {
                        case ConsoleKey.W:
                            MoverPortal(tablero, ref filaActual2, ref columnaActual2, ref scaner, filaActual2 - 1, columnaActual2, puntajes, turnos);
                            break;
                        case ConsoleKey.S:
                            MoverPortal(tablero, ref filaActual2, ref columnaActual2, ref scaner, filaActual2 + 1, columnaActual2, puntajes, turnos);
                            break;
                        case ConsoleKey.D:
                            MoverPortal(tablero, ref filaActual2, ref columnaActual2, ref scaner, filaActual2, columnaActual2 + 1, puntajes, turnos);
                            break;
                        case ConsoleKey.A:
                            MoverPortal(tablero, ref filaActual2, ref columnaActual2, ref scaner, filaActual2, columnaActual2 - 1, puntajes, turnos);
                            break;
                    }
                } while (!scaner);
                Console.Clear();
            } while (puntajes[0] < 10 && puntajes[1] < 10 && puntajes[0] < puntajes[1] + 5 && puntajes[1] < puntajes[0] + 5);
        }

        static void MoverPortal(int[,] matriz, ref int filaActual, ref int columnaActual, ref bool scaner, int filaDestino, int columnaDestino, int[] puntajes, int turnos)
        {
            if (columnaDestino < 0)
            {
                columnaDestino = matriz.GetLength(1) - 1;
            }
            if (columnaDestino > matriz.GetLength(1) - 1)
            {
                columnaDestino = 0;
            }

            if (filaDestino < 0)
            {
                filaDestino = matriz.GetLength(0) - 1;
            }
            if (filaDestino > matriz.GetLength(0) - 1)
            {
                filaDestino = 0;
            }

            if (matriz[filaDestino, columnaDestino] != 1 && matriz[filaDestino, columnaDestino] != 2)
            {
                Random rdm = new Random((int)DateTime.Now.Ticks);
                //ME MUEVO
                int elementoAMover = matriz[filaActual, columnaActual];
                matriz[filaActual, columnaActual] = 0;
                //impar Cerebro
                //par Pinky
                if (matriz[filaDestino, columnaDestino] == 3)
                {
                    if (turnos % 2 != 0)
                    {
                        puntajes[0]--;
                        matriz[filaDestino, columnaDestino] = elementoAMover;
                        PosicionarRandom(matriz, 3);
                    }

                    else
                    {
                        puntajes[1]++;
                        matriz[filaDestino, columnaDestino] = elementoAMover;
                        PosicionarRandom(matriz, 3);
                    }
                }
                else if (matriz[filaDestino, columnaDestino] == 4)
                {
                    if (turnos % 2 != 0)
                    {
                        puntajes[0]++;
                        matriz[filaDestino, columnaDestino] = elementoAMover;
                        PosicionarRandom(matriz, 4);
                    }

                    else
                    {
                        puntajes[1]--;
                        matriz[filaDestino, columnaDestino] = elementoAMover;
                        PosicionarRandom(matriz, 4);
                    }
                }
                else if (matriz[filaDestino, columnaDestino] == 5)
                {
                    puntajes[0] += 2;
                    matriz[filaDestino, columnaDestino] = elementoAMover;
                }
                else
                {
                    matriz[filaDestino, columnaDestino] = elementoAMover;

                }
                filaActual = filaDestino;
                columnaActual = columnaDestino;
                if (rdm.Next(0, 100 + 1) <= 5) PosicionarRandom(matriz, 5);
            }
            else
            {
                scaner = false;
            }

        }

        static Tuple<int, int> PosicionarRandom(int[,] matriz, int elemento)
        {
            int fila, columna;
            Random rdm = new Random((int)DateTime.Now.Ticks);
            do
            {
                fila = rdm.Next(0, matriz.GetLength(0));
                columna = rdm.Next(0, matriz.GetLength(1));
            } while (matriz[fila, columna] != 0);
            matriz[fila, columna] = elemento;
            return Tuple.Create(fila, columna);
        }

        static void ValidarRango(int condicionMinimo, ref int num, int condicionMaximo, bool esNumero)
        {
            while (num < condicionMinimo || num > condicionMaximo)
            {
                Console.WriteLine("\nEl valor debe estar entre los valores " + condicionMinimo + " y " + condicionMaximo);
                Console.Write("\nReingrese: ");
                do
                {
                    esNumero = Int32.TryParse(Console.ReadLine(), out num);
                    Console.WriteLine("\n Ingrese un numero valido: ");
                } while (!esNumero);
                Console.Clear();
            }
        }

            static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("Ingrese tamaño del tablero: ");
            int tamaño = 0;
            bool esNumero=true;
            //SUPONGO QUE ESTA TODO BIEN
            do
            {
                esNumero = Int32.TryParse(Console.ReadLine(), out tamaño);

            } while (!esNumero);
            ValidarRango(3,ref tamaño, 10, esNumero);
            int[,] tablero = new int[tamaño, tamaño];
            InicializarMatriz(tablero, 0);
            Tuple<int, int> posRaton = PosicionarRandom(tablero, 1);
            Tuple<int, int> posRaton2 = PosicionarRandom(tablero, 2);
            PosicionarRandom(tablero, 3);
            PosicionarRandom(tablero, 4);
            PosicionarRandom(tablero, 5);
            bool scaner = true;
            int[] puntajes = new int[2] { 0, 0 };
            int filaActual, columnaActual;
            filaActual = posRaton.Item1;
            columnaActual = posRaton.Item2;
            int filaActual2, columnaActual2;
            filaActual2 = posRaton2.Item1;
            columnaActual2 = posRaton2.Item2;
            Proceso(tablero, puntajes, scaner, filaActual, filaActual2, columnaActual, columnaActual2);
            Console.WriteLine("\n Puntos de Cerebro: " + puntajes[0]);
            Console.WriteLine("\n Puntos de Pinky: " + puntajes[1]);
            ImprimirMatriz(tablero);
            if (puntajes[0] > puntajes[1])
            {
                Console.WriteLine("Cerebro ha ganado este juego ");
            }
            else if (puntajes[0] < puntajes[1])
            {
                Console.WriteLine("Pinky ha ganado este juego ");
            }
            else
            {
                Console.WriteLine("Han empatado los dos ratones");
            }

            Console.ReadKey();
        }
    }
}
