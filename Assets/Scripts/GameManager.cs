using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject restartButton; // Reference to the Restart Button (which is in Canvas)

    void Start()
    {
        restartButton.SetActive(false); // Initially hide the restart button
    }

    public void ShowRestartButton()
    {
        restartButton.SetActive(true); // Show the restart button when the game ends
    }

    public void RestartGame()
    {
        // Reload the current scene "_Scene_0"
        SceneManager.LoadScene("_Scene_0"); // Ensure this matches the exact name of your scene
    }
}
