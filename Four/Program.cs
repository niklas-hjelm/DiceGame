
Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("Welcome to the DICE GAME!!"); Console.ResetColor();
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("Start this game by pressing ENTER");
Console.ResetColor();
Console.ReadKey(true);

(string playerID, int gameScore, int diceScore)[] players =
    new (string playerID, int gameScore, int diceScore)[4]
        {
                        ("Ett", 0, 0),
                        ("Två", 0, 0),
                        ("Tre", 0, 0),
                        ("Fyra", 0, 0),
        };

for (int i = 0; i < 6; i++)
{
    PlayTurn(players);

}
DeclareWinner(players);

Console.ReadKey();

void PlayTurn((string pI, int gS, int dS)[] players)
{
    Random dice = new Random();

    for (int i = 0; i < players.Length; i++)
    {
        players[i].dS = dice.Next(1, 7);

    }
    CalculateScore(players);
}

void CalculateScore((string pI, int gS, int dS)[] players)
{
    for (int i = 0; i < players.Length - 1; i++)
    {
        for (int j = 0; j < players.Length - 1; j++)
        {
            if (players[j].dS > players[j + 1].dS)
            {
                (string, int, int) potentialWinner = players[j + 1];
                players[j + 1] = players[j];
                players[j] = potentialWinner;
            }
        }
    }

    Console.WriteLine($"{players[3].pI} won this round");

    int score = 5;

    for (int i = players.Length - 1; i > -1; i--)
    {
        if (i > 0)
        {
            if (players[i - 1].dS == players[i].dS)
            {
                players[i].gS += score;
                players[i - 1].gS += score;
                score -= 2;
                i--;
            }
            else
            {
                if (score <= 0)
                {
                    players[i].gS += 0;
                }
                else
                {
                    players[i].gS += score;
                    score -= 2;
                }
            }

        }
        else if (score <= 0)
        {
            players[i].gS += 0;
        }
        else
        {
            players[i].gS += score;
            score -= 2;
        }
    }
}

void DeclareWinner((string pI, int gS, int dS)[] players)
{
    for (int i = 0; i < players.Length - 1; i++)
    {
        for (int j = 0; j < players.Length - 1; j++)
        {
            if (players[j].gS > players[j + 1].gS)
            {
                (string, int, int) potentialWinner = players[j + 1];
                players[j + 1] = players[j];
                players[j] = potentialWinner;
            }
        }
    }

    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine("-----");
    Console.ResetColor();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Winner: {players[3].pI} with a score of {players[3].gS} points.");
    Console.ResetColor();
}

