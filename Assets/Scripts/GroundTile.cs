using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;

    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        if (groundSpawner.tilesSpawned > 5)
        {
            SpawnObstacle();
            //Debug.Log(groundSpawner.tilesSpawned);
        }
  
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("helou");

        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    
    public GameObject obstaclePrefab;
    public void SpawnObstacle () {
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // Spawn the obstace at the position
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }
}
