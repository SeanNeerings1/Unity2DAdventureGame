using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class playerRespawner : MonoBehaviour
{
    [SerializeField] private bool sceneRespawn;
    [SerializeField] private int currentScene;
    [SerializeField] private int respawnPoint;
    [SerializeField] private Transform[] respawnPoints;
    [SerializeField] private static int respawnCount = 0;
    [SerializeField] private TextMeshProUGUI respawnText;
    private bool isRespawning = false;

    public static void ResetRespawnCount()
    {
        respawnCount = 0;
    }
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        respawnText.text = "Deaths: " + respawnCount;
    }

    void Update()
    {

    }
        private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Respawn") && !isRespawning)
        {
            isRespawning = true;

            respawnCount++;
        }
            if (other.gameObject.tag == "Respawn" && sceneRespawn == true)
        {
            SceneManager.LoadScene(currentScene);
        }
        if (other.gameObject.tag == "Respawn" && sceneRespawn == false)
        {
            gameObject.transform.position = respawnPoints[respawnPoint].position;
        }
    }
}
