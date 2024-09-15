using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void StartGame()
    {
        // Load the game scene, assuming your game scene is named "_Scene_0"
        SceneManager.LoadScene("_Scene_0");
    }
}
