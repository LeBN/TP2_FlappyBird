using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2D;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float force = 10f;

    private bool jumpPressed = false;

    public bool gameOver = false;
    public bool isGameStarted = false;

    private int score = 0;

    public void AddScore()
    {
        score++;
    }

    private void Start()
    {
        rb2D.gravityScale = 1f;
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (!isGameStarted)
            {
                rb2D.gravityScale = 1f;
                isGameStarted = true;
            }
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
    }

    public void RestartGame()
    {

    }
}
