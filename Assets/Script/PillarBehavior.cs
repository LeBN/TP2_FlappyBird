using UnityEngine;

public class PillarBehavior : MonoBehaviour
{
    [SerializeField]
    public float speed = 4.5f;

    float size;

    [SerializeField]
    PlayerBehavior playerBehavior;
    DestroyMe destroyMe;
    public bool isPassed = false;
    
    private void Start()
    {
        size = GetComponent<Renderer>().bounds.size.x;
        playerBehavior = Object.FindFirstObjectByType<PlayerBehavior>();
    }

    private void Update()
    {
        if (!isPassed && gameObject.transform.position.x < 0)
        {
            isPassed = true;
            playerBehavior.AddScore();
        }
        if (!playerBehavior.gameOver)
            transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
