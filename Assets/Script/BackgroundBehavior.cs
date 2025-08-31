using UnityEngine;

public class BackgroundBehaviour : MonoBehaviour
{
    [SerializeField]
    public float speed = .2f;

    float size;

    [SerializeField]
    PlayerBehavior playerBehavior;

    private Renderer rend;
    private float offset = 0f;

    void Start()
    {
        size = GetComponent<Renderer>().bounds.size.x;
        playerBehavior = Object.FindFirstObjectByType<PlayerBehavior>();
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if (!playerBehavior.gameOver)
        {
            offset += speed / size * Time.deltaTime;
            rend.material.mainTextureOffset = new Vector2(offset, 0);
        }
    }
}
