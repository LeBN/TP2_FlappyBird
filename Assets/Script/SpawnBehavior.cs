using UnityEngine;

public class SpawnBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject pillarPrefab;
    [SerializeField]
    private PlayerBehavior playerBehavior;

    [SerializeField]
    private float rate = 2f;
    private float checkTime = 0f;

    private void Start()
    {
        // Instanciation des pilliers
        float rand = Random.Range(-3f, 3f);
        GameObject pillar1 = Instantiate(pillarPrefab, new Vector3(transform.position.x, transform.position.y - 6f + rand, 0f), Quaternion.identity);
        GameObject pillar2 = Instantiate(pillarPrefab, new Vector3(transform.position.x, transform.position.y + 6f + rand, 0f), Quaternion.Euler(0f, 180f, 180f));
        pillar1.AddComponent<DestroyMe>().LifeTime = 5f;
        pillar1.AddComponent<PillarBehavior>();
        pillar2.AddComponent<DestroyMe>().LifeTime = 5f;
        pillar2.AddComponent<PillarBehavior>();
        checkTime += rate;
    }

    private void Update()
    {
        if (playerBehavior.gameOver || !playerBehavior.isGameStarted)
        {
            return;
        }
        if (Time.time >= checkTime)
        {
            float rand = Random.Range(-3f, 3f);
            GameObject pillar1 = Instantiate(pillarPrefab, new Vector3(transform.position.x, transform.position.y - 6f + rand, 0f), Quaternion.identity);
            GameObject pillar2 = Instantiate(pillarPrefab, new Vector3(transform.position.x, transform.position.y + 6f + rand, 0f), Quaternion.Euler(0f, 180f, 180f));
            pillar1.AddComponent<DestroyMe>().LifeTime = 5f;
            pillar1.AddComponent<PillarBehavior>();
            pillar2.AddComponent<DestroyMe>().LifeTime = 5f;
            pillar2.AddComponent<PillarBehavior>();
            checkTime += rate;
        }
    }
}
