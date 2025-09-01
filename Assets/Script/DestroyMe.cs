using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    [SerializeField]
    public float LifeTime = 5f;

    private void Start()
    {

    }

    private void Update()
    {
        if (gameObject.scene.IsValid() && (gameObject.transform.position.x < -10f))
        {
            Destroy(gameObject);
        }
    }
}
