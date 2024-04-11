using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject player;

    // Reference to the GameReset script.
    private GameReset gameReset;

    // Function to trigger game over.
    public void TriggerGameOver()
    {
        // Display a game over screen or perform other game over actions.
        ShowGameOverScreen();
        StopGame();
    }

    void ShowGameOverScreen()
    {
        // Display your game over screen UI element.
        gameOverScreen.SetActive(true);
    }

    void StopGame()
    {
        // Add logic to stop the game, pause time, or perform any other necessary actions.
        Time.timeScale = 0; // Pause the game by setting time scale to zero.
    }

    public void RestartGame()
    {
        // Reset the game state.
        Time.timeScale = 1; // Reset time scale to resume the game.

        // Hide the game over screen.
        gameOverScreen.SetActive(false);

        // Reset the player's position to the starting point.
        player.transform.position = new Vector3(-8, 0, 0); // Adjust the position as needed.

        // Reset game parameters using the GameReset script.
        gameReset.ResetGame();
    }
}
