using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIC_TOC_TOE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] matriz1 = { "_", "1", "_", "|", "_", "2", "_", "|", "_", "3", "_" };
            string[] matriz2 = { "_", "4", "_", "|", "_", "5", "_", "|", "_", "6", "_" };
            string[] matriz3 = { "_", "7", "_", "|", "_", "8", "_", "|", "_", "9", "_" };

            string[] numeros = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            int ganador = 0;

            bool turno = false;

            Console.WriteLine("Bienvenido jugadores:");
            Console.WriteLine("                     ");
            tablero(matriz1,matriz2,matriz3);

            string player1 = "O";
            string player2 = "X";

            do{
                if (turno == false)
                {
                    Console.WriteLine("Jugador X elija su posicion: ");
                    int jugada = int.Parse(Console.ReadLine());

                    for (int i = 0; i < matriz1.Length; i++)
                    {
                        if (matriz1[i] == numeros[jugada])
                        {
                            matriz1[i] = player2;
                            Console.Clear();
                            tablero(matriz1, matriz2, matriz3);
                        }
                    }

                    for (int i = 0; i < matriz1.Length; i++)
                    {
                        if (matriz2[i] == numeros[jugada])
                        {
                            matriz2[i] = player2;
                            Console.Clear();
                            tablero(matriz1, matriz2, matriz3);
                        }
                    }

                    for (int i = 0; i < matriz1.Length; i++)
                    {
                        if (matriz3[i] == numeros[jugada])
                        {
                            matriz3[i] = player2;
                            Console.Clear();
                            tablero(matriz1, matriz2, matriz3);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Jugador O elija su posicion: ");
                    int jugada = int.Parse(Console.ReadLine());

                    for (int i = 0; i < matriz1.Length; i++)
                    {
                        if (matriz1[i] == numeros[jugada])
                        {
                            matriz1[i] = player1;
                            Console.Clear();
                            tablero(matriz1, matriz2, matriz3);
                        }
                    }

                    for (int i = 0; i < matriz1.Length; i++)
                    {
                        if (matriz2[i] == numeros[jugada])
                        {
                            matriz2[i] = player1;
                            Console.Clear();
                            tablero(matriz1, matriz2, matriz3);
                        }
                    }

                    for (int i = 0; i < matriz1.Length; i++)
                    {
                        if (matriz3[i] == numeros[jugada])
                        {
                            matriz3[i] = player1;
                            Console.Clear();
                            tablero(matriz1, matriz2, matriz3);
                        }
                    }

                }
                ganador = IsWinner(matriz1, matriz2, matriz3);
                turno = (!turno);
            } while (ganador != 1 && ganador != -1);

            string winner = "";
            if (turno == false) winner = player1;
            else  winner = player2;

            if(ganador == 1) 
            {
                Console.WriteLine("El ganador es : " + (winner)); 
            } 
            else if(ganador == -1)
            {
                Console.WriteLine("La partida es empate.");
            }
            else { Console.WriteLine("No quedan mas posiciones!"); }

            Console.ReadKey();

        }


        public static void tablero(Array matriz1,Array matriz2,Array matriz3)
        {
            foreach(string elemento in matriz1)
            { Console.Write(elemento); }
            Console.WriteLine("\n");
            foreach(string elemento in matriz2)
            { Console.Write(elemento); }
            Console.WriteLine("\n");
            foreach (string elemento in matriz3)
            { Console.Write(elemento); }
            Console.WriteLine("\n");
        }
        
        public static int IsWinner(string[] matriz1,string[] matriz2,string[] matriz3)

        {
            //posibilidades de ganar 1,2,3 or 4,5,6 or 7,8,9
            if (matriz1[1] == matriz1[5] && matriz1[1] == matriz1[9])
                return 1;
            else if (matriz2[1] == matriz2[5] && matriz2[1] == matriz2[9]) 
                return 1;
            else if (matriz3[1] == matriz3[5] && matriz3[1] == matriz3[9])
                return 1;
            //posibilidades de ganar 1,4,7 or 2,5,8 or 3,6,9
            else if(matriz1[1] == matriz2[1] && matriz1[1] == matriz3[1])
                return 1;
            else if(matriz1[5] == matriz2[5] && matriz1[5] == matriz3[5])
                return 1;
            else if(matriz1[9] == matriz2[9] && matriz1[9] == matriz3[9])
                return 1;
            //posibilidades de ganar diagonal
            else if(matriz1[1] == matriz2[5] && matriz1[1] == matriz3[9])
                return 1;
            else if(matriz1[9] == matriz2[5] && matriz1[9] == matriz3[1])
                return 1;
            else if(matriz1[1] != "1" && matriz1[5] != "2" && matriz1[9] != "3" &&
                matriz2[1] != "4" && matriz2[5] != "5" && matriz2[9] != "6" && 
                matriz3[1] != "7" && matriz3[5] != "8" && matriz3[9] != "9")
                return -1;
               else 
                return 0;
        }

    }
}

