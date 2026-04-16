using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

// This script handles player respawning and tracking death count
public class playerRespawner : MonoBehaviour
{
    // If true, reload the entire scene on death
    [SerializeField] private bool sceneRespawn;
    // Stores the current scene index
    [SerializeField] private int currentScene;
    // Index of the respawn point to use
    [SerializeField] private int respawnPoint;
    // Array of possible respawn locations
    [SerializeField] private Transform[] respawnPoints;
    // Tracks total number of deaths
    [SerializeField] private static int respawnCount = 0;
    // UI text element to display death count
    [SerializeField] private TextMeshProUGUI respawnText;
    // Prevents multiple respawns from triggering at the same time
    private bool isRespawning = false;

    // Static method to reset death count
    public static void ResetRespawnCount()
    {
        respawnCount = 0;
    }

    void Start()
    {
        // Get the current scene index when the game starts
        currentScene = SceneManager.GetActiveScene().buildIndex;

        // Update the UI text with the current death count
        respawnText.text = "Deaths: " + respawnCount;
    }

    // Called when this object enters a trigger collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object collided with has the "Respawn" tag
        // and make sure we are not already respawning
        if (other.gameObject.CompareTag("Respawn") && !isRespawning)
        {
            isRespawning = true;
            // Increase the death counter
            respawnCount++;
        }

        // If sceneRespawn is true, reload the entire scene
        if (other.gameObject.tag == "Respawn" && sceneRespawn == true)
        {
            SceneManager.LoadScene(currentScene);
        }

        // If sceneRespawn is false, move player to a specific respawn point
        if (other.gameObject.tag == "Respawn" && sceneRespawn == false)
        {
            gameObject.transform.position = respawnPoints[respawnPoint].position;
        }
    }
}