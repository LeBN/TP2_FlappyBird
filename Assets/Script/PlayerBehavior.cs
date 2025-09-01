using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2D;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float force = 10f;
    [SerializeField] 
    private TextMeshProUGUI scoreLabel;

    private bool jumpPressed = false;

    public bool gameOver = false;
    public bool isGameStarted = false;

    private int score = 0;

    public void AddScore()
    {
        score++;
        scoreLabel.text = score.ToString();
    }

    private void Start()
    {
        rb2D.gravityScale = 0f;
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (!isGameStarted)
            {
                rb2D.gravityScale = 1f;
                isGameStarted = true;
                animator.SetTrigger("Start");
            }
            else
                jumpPressed = true;
        }
    }

    private void FixedUpdate()
    {
        if (jumpPressed && !gameOver)
        {
            rb2D.linearVelocity = Vector2.zero;
            rb2D.AddForce(Vector2.up * force);
            jumpPressed = false;
            animator.SetTrigger("Jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameOver = true;
        rb2D.simulated = false;
        if (score > PlayerPrefs.GetInt("BestScore", 0))
        {
            PlayerPrefs.SetInt("BestScore", score);
            PlayerPrefs.Save();
        }
    }

    public void RestartGame()
    {

    }
}
