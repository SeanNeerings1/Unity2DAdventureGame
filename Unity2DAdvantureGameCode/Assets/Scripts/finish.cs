using UnityEngine;
using UnityEngine.SceneManagement;

public class finish : MonoBehaviour
{
    // Keeps track of whether the player has reached the finish trigger
    private bool isFinished = false;

    void Update()
    {
        // Check if the player is in the finish area AND presses the "E" key
        if (isFinished && Input.GetKeyDown(KeyCode.E))
        {
            // Load the next scene based on the current scene's build index
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    // This function is called when the player collides with a collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that entered has the tag "Player"
        if (other.CompareTag("Player"))
        {
            // Mark that the player has reached the finish area
            isFinished = true;
        }
    }
}