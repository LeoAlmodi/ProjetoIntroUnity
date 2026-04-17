using UnityEngine;

public static class GameController
{
    private static int collectableCount;
    private static float timeLimit = 10f;
    private static float timeRemaining;
    private static bool running;
    private static bool lost;
    public static bool gameOver
    {
        get { return collectableCount <= 0 || timeRemaining <= 0 || lost; }
    }

    public static bool playerWon
    {
        get { return collectableCount <= 0; }
    }

    public static float TimeRemaining
    {
        get { return timeRemaining; }
    }

    public static void Init()
    {
        collectableCount = 4;
        timeRemaining = timeLimit;
        running = true;
        lost = false;
        Time.timeScale = 1f;
    }
    
    public static void LoseGame()
    {
        lost = true;
        running = false;
    }

    public static void Collect()
    {
        collectableCount--;
        if (collectableCount <= 0) running = false;
    }

    public static void Tick()
    {
        if (running && timeRemaining > 0)
            timeRemaining -= Time.deltaTime;
    }
    
    public static int Collected
    {
        get { return 4 - collectableCount; }
    }
}