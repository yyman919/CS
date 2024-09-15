using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Add this to manage the UI Text

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBaskets = 4;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    // Add UI Text to display the round number
    public Text roundText; // Drag your RoundCounter UI Text here

    private int currentRound = 1;
    private int maxRounds = 4; // Set the number of rounds for your game

    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }

        UpdateRoundText(); // Display the initial round
    }

    public void AppleDestroyed()
    {
        // Destroy all of the falling Apples
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }

        // Destroy one of the Baskets
        if (basketList.Count > 0)
        {
            int basketIndex = basketList.Count - 1;
            GameObject tBasketGO = basketList[basketIndex];
            basketList.RemoveAt(basketIndex);
            Destroy(tBasketGO);
        }

        // If all baskets are destroyed, trigger next round or end the game
        if (basketList.Count == 0)
        {
            NextRound(); // Handle round updates internally
        }
    }

    // Method to advance to the next round or restart the game
    void NextRound()
    {
        if (currentRound < maxRounds)
        {
            currentRound++;
            Debug.Log("Next Round:" + currentRound);
            UpdateRoundText();
            ResetBaskets(); // Re-create baskets for the new round
        }
        else
        {
            GameOver(); // End the game when max rounds are reached
        }
    }

    // Method to update the round text UI
    void UpdateRoundText()
    {
        if (roundText != null)
        {
            roundText.text = "Round:" + currentRound;
        }
    }

    // Reset the baskets for the next round
    void ResetBaskets()
    {
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    // Game Over method to handle end of game logic
   public void GameOver()
{
    Debug.Log("Game Over!");

    if (roundText != null)
    {
        roundText.text = "Game Over";
    }

    // Disable gameplay-related components or objects, like apple spawning
    DisableGameplay();

    // Show the Restart Button
    GameObject gameManagerGO = GameObject.Find("GameManager");
    if (gameManagerGO != null)
    {
        GameManager gameManager = gameManagerGO.GetComponent<GameManager>();
        gameManager.ShowRestartButton();
    }
}

// Method to disable game-related components but keep UI and restart button active
void DisableGameplay()
{
    // Example: Disable the AppleTree script that spawns apples
    AppleTree appleTree = FindObjectOfType<AppleTree>();
    if (appleTree != null)
    {
        appleTree.enabled = false; // Stop apple spawning
    }

    // Disable other gameplay mechanics if necessary, such as player control or basket interaction
    Basket basket = FindObjectOfType<Basket>();
    if (basket != null)
    {
        basket.enabled = false; // Stop basket from moving
    }
}



}
