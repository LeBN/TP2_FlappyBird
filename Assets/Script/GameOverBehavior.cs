using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverBehavior : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] PlayerBehavior playerBehavior;
    private Button retryButton;

    void Awake()
    {
        retryButton = gameOverPanel.transform.Find("retryButton").GetComponentInChildren<Button>();
    }

    void Start()
    {
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        if (retryButton != null)
        {
            retryButton.onClick.AddListener(OnRetryButtonPressed);
        }
    }

    void Update()
    {
        if (playerBehavior.gameOver)
        {
            gameOverPanel.SetActive(true);
        }
    }

    void OnRetryButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
