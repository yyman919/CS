using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    public Text roundText; // Reference to the RoundCounter UI Text
    public GameManager gameManager; // Reference to GameManager for restart actions

    private int currentRound = 1;
    private int maxRounds = 4; // Maximum round limit
    private bool gameOver = false;

    void Start()
    {
        UpdateRoundText(); // Show the initial round
    }

    void Update()
    {
        // Temporary test: Advance the round by pressing the spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextRound(); // Manually test round advancement
        }
    }

    // Call this method to advance to the next round
    public void NextRound()
{
    if (currentRound < maxRounds)
    {
        currentRound++;
        Debug.Log("Next Round:" + currentRound); // Debugging statement
        UpdateRoundText(); // Update the displayed round number
    }
    else
    {
        GameOver(); // Call GameOver if maxRounds is reached
    }
}

    void UpdateRoundText()
    {
        if (!gameOver)
        {
            roundText.text = "Round:" + currentRound;
        }
    }

    void GameOver()
{
    gameOver = true;
    Debug.Log("Game Over"); // Debugging statement
    roundText.text = "Game Over"; // Display game over message
    gameManager.ShowRestartButton(); // Notify GameManager to show restart button
}
}
