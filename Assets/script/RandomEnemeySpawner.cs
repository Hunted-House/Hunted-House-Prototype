using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemySpawner : MonoBehaviour
{
    public GameObject EnemySpiderPrefab;
    public Collider2D[] spiderColliders;

    // Start is called before the first frame update
    void Start()
    {
        // spawn 10 enemies at random positions but check if the position is not in any spider enemy's collider
        for (int i = 0; i < 5; i++)
        {
            Vector3 randomPosition = GetRandomPosition();
            if (!IsPositionInCollider(randomPosition))
            {
                Instantiate(EnemySpiderPrefab, randomPosition, Quaternion.identity, transform);
            }
        }
    }

    // Generate a random position within the desired range
    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(-8f, 8f);
        float y = Random.Range(-4f, 4f);
        return new Vector3(x, y, 0);
    }

    // Check if a position is within any spider enemy's collider
    private bool IsPositionInCollider(Vector3 position)
    {
        foreach (Collider2D spiderCollider in spiderColliders)
        {
            if (spiderCollider.OverlapPoint(position))
            {
                return true;
            }
        }
        return false;
    }

    // Check if all enemies are dead
    void Update()
    {
        if (transform.childCount == 0)
        {
            Debug.Log("All enemies are dead");
        }
    }
}
