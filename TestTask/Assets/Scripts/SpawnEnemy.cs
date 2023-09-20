using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] GameObject[] enemyes;
    private bool shouldCreateEnemy = true;

    private void Update()
    {
        if (shouldCreateEnemy)
        {
            shouldCreateEnemy = false;

            int randomPoint = UnityEngine.Random.Range(0, points.Length);
            int randomEnemy = UnityEngine.Random.Range(0, enemyes.Length);

            GameObject enemy = Instantiate(enemyes[randomEnemy]);
            enemy.transform.position = points[randomPoint].position;

            Invoke("ResetCreateEnemy", 2);
        }
    }

    private void ResetCreateEnemy()
    {
        shouldCreateEnemy = true;
    }
}
