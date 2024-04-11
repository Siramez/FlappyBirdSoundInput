using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject player;
    public GameOverManager gameOverManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // The player (bird) has collided with the obstacle.
            // Trigger game over by calling the method from the GameOverManager.
            gameOverManager.TriggerGameOver();
        }
    }
}
