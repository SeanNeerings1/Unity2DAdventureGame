using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script controls the main/start menu buttons
public class StartMenuController : MonoBehaviour
{
    // Called when the "Start" button is clicked
    private void onStartClick()
    {
        // Load the first level scene
        SceneManager.LoadScene("lvl1");
    }

    // Called when the "Exit" button is clicked
    private void onExitClick()
    {
        // If running inside the Unity Editor, stop play mode
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

        // If running as a built game, quit the application
        Application.Quit();
    }

    // Called when the "Restart" button is clicked
    private void onRestartClick()
    {
        // Reset the death/respawn counter before restarting
        playerRespawner.ResetRespawnCount();

        // Load the start menu scene
        SceneManager.LoadScene("startScene");
    }
}