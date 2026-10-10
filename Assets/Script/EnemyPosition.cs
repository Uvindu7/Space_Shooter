
using UnityEngine;

public class EnemyPosition : MonoBehaviour
{
    public GameObject[] EnemyLocation;
    public GameObject Enemy;
    
    // Variables for difficulty increase
    public float spawnDelay = 150f;
    public float minSpawnDelay = 40f;
    public float spawnDelayDecreaseRate = 2f;
    
    public float enemySpeed = 1f;
    public float enemySpeedIncreaseRate = 0.05f;
    public float doubleSpawnProbability = 0.2f;

    int startTime = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        startTime += 1;

        if(startTime > spawnDelay)
        {
            int currentScore = PlayerPrefs.GetInt("Score", 0);
            bool shouldSpawnTwo = currentScore >= 30 && Random.value < doubleSpawnProbability;

            int randNumber1 = Random.Range(0, EnemyLocation.Length);
            SpawnEnemy(randNumber1);

            if (shouldSpawnTwo && EnemyLocation.Length > 1)
            {
                int randNumber2 = Random.Range(0, EnemyLocation.Length);
                // Ensure the second enemy spawns in a different lane
                while (randNumber2 == randNumber1)
                {
                    randNumber2 = Random.Range(0, EnemyLocation.Length);
                }
                SpawnEnemy(randNumber2);
            }

            startTime = 0;
            
            // Increase difficulty
            if (spawnDelay > minSpawnDelay)
            {
                spawnDelay -= spawnDelayDecreaseRate;
            }
            enemySpeed += enemySpeedIncreaseRate;
        }
    }

    void SpawnEnemy(int index)
    {
        GameObject newEnemy = Instantiate(Enemy, EnemyLocation[index].transform.position, Quaternion.identity);
        
        Enemy enemyScript = newEnemy.GetComponent<Enemy>();
        if (enemyScript != null)
        {
            enemyScript.fallSpeed = enemySpeed;
        }
    }
}

