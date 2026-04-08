using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void onStartClick()
    {
        SceneManager.LoadScene("lvl1");
    }
    private void onExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    private void onRestartClick()
    {
        playerRespawner.ResetRespawnCount();
        SceneManager.LoadScene("startScene");
    }
}
