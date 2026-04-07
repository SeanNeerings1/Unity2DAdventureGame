using UnityEngine;
using UnityEngine.SceneManagement;

public class playerRespawner : MonoBehaviour
{
    [SerializeField] private bool sceneRespawn;
    [SerializeField] private int currentScene;
    [SerializeField] private int respawnPoint;
    [SerializeField] private Transform[] respawnPoints;
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {

    }
        private void OnTriggerEnter2D(Collider2D other)
    {
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
