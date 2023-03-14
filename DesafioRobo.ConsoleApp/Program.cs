using System;

namespace DesafioRobo.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao Desafio do Robô!");
            Console.WriteLine("Por favor, insira as coordenadas do canto superior direito da área:");

            int limiteX, limiteY;

            while (true)
            {
                Console.Write("-> ");
                string[] limites = Console.ReadLine().Split();

                if (limites.Length != 2 || !int.TryParse(limites[0], out limiteX) || !int.TryParse(limites[1], out limiteY))
                {
                    Console.WriteLine("Coordenadas inválidas. Por favor, insira as coordenadas no formato 'X Y'.");
                    continue;
                }

                break;
            }

            Console.WriteLine("Coordenadas válidas. Agora insira a posição inicial do robô e as instruções:");

            while (true)
            {
                Console.WriteLine("\n###Linha1###");
                Console.Write("-> ");
                string linha1 = Console.ReadLine();

                if (linha1 == null)
                {
                    Console.WriteLine("Fim do programa.");
                    break;
                }

                Console.WriteLine("\n###Linha2###\n");
                Console.Write("-> ");
                string linha2 = Console.ReadLine();

                string[] posicao = linha1.Split();

                int x, y;

                if (posicao.Length != 3 || !int.TryParse(posicao[0], out x) || !int.TryParse(posicao[1], out y) ||
                    (posicao[2] != "N" && posicao[2] != "S" && posicao[2] != "L" && posicao[2] != "O"))
                {
                    Console.WriteLine("Posição inicial inválida. Por favor, insira a posição no formato 'X Y D', onde D é a direção inicial (N, S, L ou O).");
                    continue;
                }

                char direcao = char.Parse(posicao[2]);

                foreach (char c in linha2)
                {
                    if (c == 'E')
                    {
                        switch (direcao)
                        {
                            case 'N':
                                direcao = 'O';
                                break;
                            case 'S':
                                direcao = 'L';
                                break;
                            case 'L':
                                direcao = 'N';
                                break;
                            case 'O':
                                direcao = 'S';
                                break;
                        }
                    }
                    else if (c == 'D')
                    {
                        switch (direcao)
                        {
                            case 'N':
                                direcao = 'L';
                                break;
                            case 'S':
                                direcao = 'O';
                                break;
                            case 'L':
                                direcao = 'S';
                                break;
                            case 'O':
                                direcao = 'N';
                                break;
                        }
                    }
                    else if (c == 'M')
                    {
                        switch (direcao)
                        {
                            case 'N':
                                if (y < limiteY) y++;
                                break;
                            case 'S':
                                if (y > 0) y--;
                                break;
                            case 'L':
                                if (x < limiteX) x++;
                                break;
                            case 'O':
                                if (x > 0) x--;
                                break;
                            default:
                                Console.WriteLine("Direção inválida.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Instrução inválida: {c}");
                        break;
                    }
                }

                Console.WriteLine($"Posição final do robô: {x} {y} {direcao}");
            }
        }
    }
}