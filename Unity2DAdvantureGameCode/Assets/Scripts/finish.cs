using UnityEngine;
using UnityEngine.SceneManagement;

public class finish : MonoBehaviour
{
    private bool isFinished = false;

    void Update()
    {
        if (isFinished && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isFinished = true;
        }
    }
}