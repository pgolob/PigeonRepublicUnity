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
        SpawnPerson();
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

    public GameObject childPrefab;
    public GameObject policePrefab;
    public GameObject manPrefab;
    public void SpawnPerson () {

        int personIndex = Random.Range(5, 14);
        Transform spawnPoint = null;
        Quaternion targetRotation = Quaternion.Euler(0, 90, 0);

        if (personIndex >= 5 && personIndex <= 7) { //child
            spawnPoint = transform.GetChild(personIndex).transform;
            Instantiate(childPrefab, spawnPoint.position, targetRotation, transform);

        } else if (personIndex >= 8 && personIndex <= 10) { //policajka
            spawnPoint = transform.GetChild(personIndex).transform;
            Instantiate(policePrefab, spawnPoint.position, targetRotation, transform);

        } else if  (personIndex >= 11 && personIndex <= 13) { //man
            spawnPoint = transform.GetChild(personIndex).transform;
            Instantiate(manPrefab, spawnPoint.position, targetRotation, transform);
        }

    }
}
