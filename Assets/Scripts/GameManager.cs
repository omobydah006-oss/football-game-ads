using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Client;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int playerScore = 0;
    [SerializeField] private int enemyScore = 0;
    [SerializeField] private bool isGameOver = false;
    private UIManager uiManager;
    private AdsManager adsManager;

    private void Start()
    {
        uiManager = GetComponent<UIManager>();
        adsManager = GetComponent<AdsManager>();
        Time.timeScale = 1f;
    }

    public void AddScore(bool isPlayer)
    {
        if (isPlayer)
            playerScore++;
        else
            enemyScore++;

        uiManager.UpdateScore(playerScore, enemyScore);
        CheckGameState();
    }

    private void CheckGameState()
    {
        if (playerScore >= 5 || enemyScore >= 5)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        isGameOver = true;
        Time.timeScale = 0f;

        if (playerScore < enemyScore)
        {
            // اللاعب خسر - عرض إعلان
            adsManager.ShowRewardedAd(() => {
                uiManager.ShowGameOverScreen(playerScore > enemyScore);
            });
        }
        else
        {
            uiManager.ShowGameOverScreen(playerScore > enemyScore);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public bool IsGameOver => isGameOver;
    public int PlayerScore => playerScore;
    public int EnemyScore => enemyScore;
}