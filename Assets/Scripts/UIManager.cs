using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button mainMenuButton;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GetComponent<GameManager>();
        gameOverPanel.SetActive(false);
        restartButton.onClick.AddListener(OnRestartClicked);
        mainMenuButton.onClick.AddListener(OnMainMenuClicked);
    }

    public void UpdateScore(int playerScore, int enemyScore)
    {
        scoreText.text = $"{playerScore} - {enemyScore}";
    }

    public void ShowGameOverScreen(bool playerWon)
    {
        gameOverPanel.SetActive(true);
        resultText.text = playerWon ? "🎉 أنت ربحت!" : "😢 خسرت هذه المرة";
        resultText.color = playerWon ? Color.green : Color.red;
    }

    private void OnRestartClicked()
    {
        gameManager.RestartGame();
    }

    private void OnMainMenuClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}