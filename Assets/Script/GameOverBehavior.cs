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
        Debug.Log("Retry cliqué, nombre de piliers avant reload = "
          + FindObjectsByType<PillarBehavior>(FindObjectsSortMode.None).Length);

        foreach (var go in GameObject.FindGameObjectsWithTag("Clone"))
            Object.Destroy(go);

        var pillars = Object.FindObjectsByType<PillarBehavior>(FindObjectsSortMode.None);
        foreach (var p in pillars) if (p) Destroy(p.gameObject);

        // (optionnel) coupe le spawner avant le reload, au cas où
        foreach (var s in Object.FindObjectsByType<SpawnBehavior>(FindObjectsSortMode.None))
            s.enabled = false;

        Debug.Log("Retry cliqué, nombre de piliers avant reload 2 = "
          + FindObjectsByType<PillarBehavior>(FindObjectsSortMode.None).Length);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
