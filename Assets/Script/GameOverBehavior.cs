using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverBehavior : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] PlayerBehavior playerBehavior;
    private Button retryButton;
    [SerializeField] private AudioSource gameOverAudioSource;
    [SerializeField] private AudioClip gameOverAudioClip;

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
            gameOverAudioSource.PlayOneShot(gameOverAudioClip);
            gameOverPanel.SetActive(true);
        }
    }

    void OnRetryButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
