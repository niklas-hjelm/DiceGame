int[] totalScore = { 0, 0, 0, 0 };
int[] resultat = { 0, 0, 0, 0 };
int rounds = 6;
const int players = 4;
Random rnd = new Random();

for (int i = 0; i < rounds; i++)
{
    resultat = calculatingResults(rollingDice(rnd, i));
    for (int j = 0; j < players; j++)
    {
        totalScore[j] += resultat[j];
    }
}

for (int i = 0; i < players; i++)
{
    Console.WriteLine("Spelare " + (i + 1) + " fick totalpoängen: " + totalScore[i]);
}

Console.WriteLine();
findingWinner(totalScore);

void findingWinner(int[] finalScore)
{
    int winner = 0;
    int winnerIndex = 0;
    int amountOfWinners = 0;
    bool[] listOfWinners = { false, false, false, false };
    for (int i = 0; i < finalScore.Length; i++)
    {
        if (finalScore[i] >= winner)
        {
            winnerIndex = i;
            winner = finalScore[i];
        }
    }

    for (int i = 0; i < finalScore.Length; i++)
    {
        if (finalScore[i] == winner)
        {
            listOfWinners[i] = true;
            amountOfWinners++;
        }
    }

    switch (amountOfWinners)
    {
        case 1:
            Console.WriteLine("Vinnare var spelare: " + (winnerIndex + 1) + " med poängen: " + winner);
            break;
        case 2:
            Console.WriteLine("Oj! Vi fick 2 vinnare!");
            for (int i = 0; i < listOfWinners.Length; i++)
            {
                if (listOfWinners[i] == true)
                {
                    Console.WriteLine("En av de vinnande spelarna var: " + "spelare " + (i + 1) + " med poängen: " + winner);
                }
            }
            break;
        case 3:
            Console.WriteLine("Oj! Vi fick 3 vinnare!");
            for (int i = 0; i < listOfWinners.Length; i++)
            {
                if (listOfWinners[i] == true)
                {
                    Console.WriteLine("En av de vinnande spelarna var: " + "spelare " + (i + 1) + " med poängen: " + winner);
                }
            }
            break;
        case 4:
            Console.WriteLine("Oj! Vi fick bara förlorare :( !");
            for (int i = 0; i < listOfWinners.Length; i++)
            {
                if (listOfWinners[i] == true)
                {
                    Console.WriteLine("En av de vinnande spelarna var: " + (listOfWinners[i + 1]) + " med poängen: " + winner);
                }
            }
            break;
        default:
            break;
    }

}
int[] calculatingResults(int[] results)
{
    int[] points = { 5, 3, 1, 0 };
    int[] score = { 0, 0, 0, 0 };
    int counter = 0;
    int counter2 = 0;

    for (int i = 6; i >= 0; i--)
    {
        for (int j = 0; j < results.Length; j++)
        {
            if (i == results[j])
            {
                score[j] = points[counter];
                counter2++;
            }
        }
        counter += counter2;
        counter2 = 0;
    }

    return score;
}
int[] rollingDice(Random rnd, int round)
{
    int[] diceResults = new int[4];

    Console.WriteLine("Runda " + (round + 1) + "!");
    for (int i = 0; i < diceResults.Length; i++)
    {
        diceResults[i] = rnd.Next(1, 7);
        Console.WriteLine("Spelare " + (i + 1) + " fick tärningsresultatet: " + diceResults[i]);
    }
    Console.WriteLine("--------------------------------------");
    return diceResults;
}