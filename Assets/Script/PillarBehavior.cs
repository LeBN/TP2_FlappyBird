using UnityEngine;

public class PillarBehavior : MonoBehaviour
{
    [SerializeField]
    public float speed = 4.5f;

    float size;

    [SerializeField]
    PlayerBehavior playerBehavior;
    DestroyMe destroyMe;
    
    private void Start()
    {
        size = GetComponent<Renderer>().bounds.size.x;
        playerBehavior = Object.FindFirstObjectByType<PlayerBehavior>();
    }

    private void Update()
    {
        if (!playerBehavior.gameOver)
            transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
