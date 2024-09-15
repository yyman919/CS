using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    // Method to restart the scene _Scene_0
    public void RestartScene_0()
    {
        // Load the scene named "_Scene_0"
        SceneManager.LoadScene("_Scene_0");
    }
}
