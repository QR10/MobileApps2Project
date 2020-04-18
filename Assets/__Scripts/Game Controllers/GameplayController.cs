using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    // Variables
    private int score;

    [SerializeField] private GameObject pausePanel;

    [SerializeField] private Button restartGameButton;

    [SerializeField] private Text scoreText, pauseText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "" + score + " Points";
        StartCoroutine(CountScore());
    }

    // Keep track of the score
    IEnumerator CountScore()
    {
        yield return new WaitForSeconds(0.6f);
        score++;
        scoreText.text = score + " Points";
        StartCoroutine(CountScore());
    }

    // Handle endGame delegated previously
    private void OnEnable()
    {
        PlayerDied.endGame += PlayerDiedEndTheGame;
    }

    // Handle endGame delegated previously
    private void OnDisable()
    {
        PlayerDied.endGame -= PlayerDiedEndTheGame;
    }

    // Display panel when player dies
    void PlayerDiedEndTheGame()
    {
        // Create score if not present
        if(!PlayerPrefs.HasKey("Score"))
        {
            PlayerPrefs.SetInt("Score", 0);
        }
        // If it is, check for highscore and display gameover panel
        else
        {
            int highscore = PlayerPrefs.GetInt("Score");

            // New highscore
            if(highscore < score)
            {
                PlayerPrefs.SetInt("Score", score);
            }

            // Set game over message and activate panel
            pauseText.text = "Game over";
            pausePanel.SetActive(true);
            // Listen to restar game button clicks
            restartGameButton.onClick.RemoveAllListeners();
            restartGameButton.onClick.AddListener(() => RestartGame());
            Time.timeScale = 0f;
        }
    }

    // Pause Gameplay and display panel
    public void PauseButton()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        restartGameButton.onClick.RemoveAllListeners();
        restartGameButton.onClick.AddListener(() => ResumeGame());
    }

    // Load Main menu scene
    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    // Resume the game and desactivate pause panel
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    // Reload Gameplay Scene
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GamePlay");
    }
}
