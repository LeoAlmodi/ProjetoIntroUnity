using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject endGamePanel;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI endGameText;
    public TextMeshProUGUI scoreText;
    public AudioClip gameOverSound;
    public AudioClip victorySound;
    private AudioSource audioSource;
    private bool gameOverPlayed;

    void Start()
    {
        GameController.Init();
        endGamePanel.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        gameOverPlayed = false;
    }

    void FixedUpdate()
    {
        GameController.Tick();

        timerText.text = "Tempo: " + Mathf.CeilToInt(GameController.TimeRemaining) + "s";
        scoreText.text = "Coletáveis: " + GameController.Collected + "/4";

        if (GameController.gameOver)
        {
            if (!gameOverPlayed)
            {
                audioSource.Stop();
                if (GameController.playerWon)
                    audioSource.PlayOneShot(victorySound);
                else
                    audioSource.PlayOneShot(gameOverSound);
                gameOverPlayed = true;
            }

            Time.timeScale = 0f;
            endGamePanel.SetActive(true);
            timerText.gameObject.SetActive(false);
            scoreText.gameObject.SetActive(false);

            if (GameController.playerWon)
                endGameText.text = "Você venceu!";
            else
                endGameText.text = "Você perdeu!";
        }
    }
}