using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Slime slime;

    private float spawnDelay = 0.5f;
    private float spawnElapsedTime = 0;

    private void Update()
    {
        if (Time.timeScale > 0)
        {
            if (spawnElapsedTime > spawnDelay)
            {
                Slime slimeInstantiated = Instantiate(slime);
                slimeInstantiated.transform.position = new Vector2(Random.Range(-48, 45f), Random.Range(44, -40));

                spawnElapsedTime = 0;
            }

            spawnElapsedTime += Time.deltaTime;
        }
    }
}
