using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoSpawnerScript : MonoBehaviour
{
  public GameObject echo;
  public float spawnRate = 2;
  public int amountToSpawn = 0;
  private int amountSpawned = 0;
  private float spawnTimer = 0;

  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (amountToSpawn != 0 && amountSpawned > amountToSpawn)
    {
      Destroy(gameObject);
    }
    if (spawnTimer < spawnRate)
    {
      spawnTimer += Time.deltaTime;
    }
    else
    {
      GameObject echoInstance = Instantiate(echo, transform.position, transform.rotation);
      EchoScript echoScript = echoInstance.GetComponent<EchoScript>();
      echoScript.direction = (new Vector2(transform.position.x, transform.position.y)).normalized;

      amountSpawned += 1;
      spawnTimer = 0;
    }
  }
}
