using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sapwner : MonoBehaviour
{
    public GameObject _EnemyPrefab;
    public float _spowmingTime = 10;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, _spowmingTime);
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy()
    {
        Vector3 randomPoint = new Vector3(Random.Range(-15.5f, 16.5f),5, Random.Range(-15.5f, 16.5f));

        Instantiate(_EnemyPrefab, randomPoint, Quaternion.identity);

    }
}
