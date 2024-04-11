using UnityEngine;

public class GameReset : MonoBehaviour
{
    public GameObject bird; // Reference to the bird GameObject.
    private PlayerController playerController; // Reference to the PlayerController script.

    void Start()
    {
        playerController = bird.GetComponent<PlayerController>();
    }

    // Method to reset game parameters.
    public void ResetGame()
    {
        ResetBirdSpeed();
        ResetBirdGravity();
    }

    // Method to reset bird speed.
    private void ResetBirdSpeed()
    {
        playerController.forwardSpeed = 2f; // Adjust to the initial speed.
    }

    // Method to reset bird gravity.
    private void ResetBirdGravity()
    {
        playerController.gravityScale = 1f; // Adjust to the initial gravity.
    }
}
