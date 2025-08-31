using System.Drawing;
using UnityEngine;

public class GroundBehavior : MonoBehaviour
{
    [SerializeField]
    public float speed = .2f;

    float CanvasSize;
    float UvScale;

    [SerializeField]
    PlayerBehavior playerBehavior;

    private Renderer rend;
    private Material mat;
    private float offset = 0f;

    void Start()
    {
        playerBehavior = Object.FindFirstObjectByType<PlayerBehavior>();
        rend = GetComponent<Renderer>();
        mat = rend.material;
        CanvasSize = rend.bounds.size.x;
        UvScale = mat.mainTextureScale.x;
    }

    void Update()
    {
        if (!playerBehavior.gameOver)
        {
            offset += speed * Time.deltaTime * (UvScale/CanvasSize);
            rend.material.mainTextureOffset = new Vector2(offset, 0);
        }
    }
}
