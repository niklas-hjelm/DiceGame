Random rnd = new Random();
string[] players = new string[4];
int[] playerPoints = new int[4];

StartGame();

void StartGame()
{
    AddPlayers();
    for (int i = 0; i < 6; i++)
    {
        Console.Clear();
        Console.WriteLine($"Round {i + 1}");
        PlayRound();
        if ( i < 5)
        {
            Console.WriteLine("\nPress any key to start the next round . . .");
        }
        else
        {
            Console.WriteLine("\nPress any key to go to the score screen . . .");
        }
        Console.ReadKey();
    }
    Console.Clear();
    PrintResult();
    Console.ReadKey();
}

void AddPlayers()
{
    for (int i = 0; i < players.Length; i++)
    {
        Console.Clear();
        Console.WriteLine($"Player{i + 1} enter name:");
        players[i] = Console.ReadLine();
    }
}
void PlayRound()
{
    Console.ForegroundColor = ConsoleColor.Green;
    int[] rolls = new int[4];
    for (int i = 0; i < players.Length; i++)
    {
        Console.WriteLine($"{players[i]}, press any key to roll.");
        Console.ReadKey();
        rolls[i] = rnd.Next(1, 7);
        Console.WriteLine($"{players[i]} rolls {rolls[i]}");
    }
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine();
    DistributePoints(rolls);
}
void DistributePoints(int[] rolls)
{
    int points = 5;
    List<string> winners = new List<string>();
    int highestRoll = rolls.Max();
    int compareRoll = rolls.Max();
    bool foundScore = false;
    for (int p = 0; p < rolls.Length; p++)
    {
        if (rolls[p] == highestRoll)
        {
            winners.Add(players[p]);
        }
    }
    for (int j = 0; j < 6; j++)
    {
        for (int i = 0; i < rolls.Count(); i++)
        {
            if (rolls[i] == compareRoll)
            {
                playerPoints[i] += points;
                Console.WriteLine($"{players[i]} gets {points} points");
                foundScore = true;
            }
        }
        if (foundScore)
        {
            if (points > 1)
            {
                points -= 2;
            }
            else
            {
                points--;
            }
        }
        foundScore = false;
        compareRoll--;
    }
    Console.WriteLine("Round winner(s): ");
    foreach (string win in winners)
    {
        Console.WriteLine($"{win} ");
    }   
}
void PrintResult()
{

    int winnerScore = playerPoints.Max();
    Console.WriteLine("Scoreboard: ");
    for (int i = 0; i < players.Length; i++)
    {
        Console.WriteLine($"{players[i]}: {playerPoints[i]} points");
    }
    for (int i = 0; i < players.Length; i++)
    {
        if (playerPoints[i] == winnerScore)
        {
            Console.WriteLine($"{players[i]} won!");
        }
    }
}
