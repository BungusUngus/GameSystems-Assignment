using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float currentRound;
    public float EnemyAmount;

    public Transform PointA;
    public Transform PointB;


    public List<GameObject> enemies = new List<GameObject>();
    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies();
    }

    public void SpawnEnemies()
    {
        //clears lists
        enemies.Clear();

        //current round
        currentRound += 1;

        //starts spawning at zero until enemy amount is reached 
        for (int i = 0; i < EnemyAmount; i++)
        {
            Vector3 pos = new Vector3(Random.Range(40, -40), 5, Random.Range(-40, 50));
            //Vector3 pos = Vector3.Lerp(PointA.position, PointB.position, Random.Range(0f, 1f));
            var currentEnemy = Instantiate(enemyPrefab, pos, Quaternion.identity);
            enemies.Add(currentEnemy);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //goes through enemy list
        foreach (var enemy in enemies)
        {
            //if any enemy still exists
            if (enemy != null)
            {
                //NOMORE
                return;
            }
        }
        //spawn new enemies here
    }
}
