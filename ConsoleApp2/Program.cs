using System;
using System.Linq;

class Program
{
    static char[,] board = new char[3, 3];
    static char jogadoratual = 'X';
    static bool isGameOver = false;

    static void Main()
    {
        iniciamatriz();
        matriz();

        while (!isGameOver)
        {
            vez();
            matriz();
            checaseganha();
            troca();
        }

        Console.ReadLine();

    }


    static void iniciamatriz()
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                board[row, col] = ' ';
            }
        }
    }

    static void matriz()
    {
        Console.Clear();
        Console.WriteLine("  1 2 3");
        for (int row = 0; row < 3; row++)
        {
            Console.Write(row + 1 + " ");
            for (int col = 0; col < 3; col++)
            {
                Console.Write(board[row, col]);
                if (col < 2)
                    Console.Write("|");
            }
            Console.WriteLine();
            if (row < 2)
                Console.WriteLine("  -----");
        }
    }

    static void vez()
    {
        Console.WriteLine($"É a vez do jogador {jogadoratual}.");
        Console.Write("Informe a linha (1-3): ");
        int row = int.Parse(Console.ReadLine()) - 1;
        Console.Write("Informe a coluna (1-3): ");
        int col = int.Parse(Console.ReadLine()) - 1;

        if (IsValidMove(row, col))
        {
            board[row, col] = jogadoratual;
        }
        else
        {
            Console.WriteLine("Jogada inválida! Tente novamente.");
            vez();
        }
    }

    static bool IsValidMove(int row, int col)
    {
        if (row < 0 || row >= 3 || col < 0 || col >= 3 || board[row, col] != ' ')
        {
            return false;
        }
        return true;
    }

    static void checaseganha()
    {
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == jogadoratual && board[i, 1] == jogadoratual && board[i, 2] == jogadoratual)
            {
                Console.WriteLine($"Jogador {jogadoratual} venceu!");
                isGameOver = true;
            }
            if (board[0, i] == jogadoratual && board[1, i] == jogadoratual && board[2, i] == jogadoratual)
            {
                Console.WriteLine($"Jogador {jogadoratual} venceu!");
                isGameOver = true;
            }
        }

        if (board[0, 0] == jogadoratual && board[1, 1] == jogadoratual && board[2, 2] == jogadoratual)
        {
            Console.WriteLine($"Jogador {jogadoratual} venceu!");
            isGameOver = true;
        }

        if (board[0, 2] == jogadoratual && board[1, 1] == jogadoratual && board[2, 0] == jogadoratual)
        {
            Console.WriteLine($"Jogador {jogadoratual} venceu!");
            isGameOver = true;
        }

        if (!board.OfType<char>().Any(cell => cell == ' '))
        {
            Console.WriteLine("Empate! O jogo terminou empatado.");
            isGameOver = true;
        }
    }

    static void troca()
    {
        jogadoratual = (jogadoratual == 'X') ? 'O' : 'X';
    }
}
