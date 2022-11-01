using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject square;
    public int spawnTimer;
    // Update is called once per frame
    private void Start()
    {
        spawnTimer = 300;
    }
    private void SpawnEnemy(GameObject g)
    {
        GameObject a = Instantiate(g);
        a.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
    }
    void Update()
    {
        if (!GameObject.FindWithTag("Enemy"))
        {
            spawnTimer -= 1;
        }
        if (spawnTimer <= 0)
        {
            SpawnEnemy(square);
            spawnTimer = 300;
        }
    }
}
