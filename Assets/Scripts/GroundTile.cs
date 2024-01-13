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
        if (groundSpawner.tilesSpawned > 6)
        {   
            if(groundSpawner.tilesSpawned % 2 == 0) {
                SpawnObstacle();
            }
            //Debug.Log(groundSpawner.tilesSpawned);
        }
  
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("helou");
        if(other.CompareTag("spwn"))
        {
            groundSpawner.SpawnTile();
            Destroy(gameObject, 2);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    
    public GameObject light;
    public GameObject scaffolding;
    public GameObject billboard;
    public void SpawnObstacle () {
        int obstacleIndex = Random.Range(2, 11);
        Transform spawnPoint = null;
        Quaternion targetRotation = Quaternion.identity;

        if (obstacleIndex >= 2 && obstacleIndex <= 4) { //light
            targetRotation = Quaternion.Euler(0, 90, 0);
            spawnPoint = transform.GetChild(obstacleIndex).transform;
            Instantiate(light, spawnPoint.position, targetRotation, transform);

        } else if (obstacleIndex >= 5 && obstacleIndex <= 7) { //scaff
            spawnPoint = transform.GetChild(obstacleIndex).transform;
            Instantiate(scaffolding, spawnPoint.position, targetRotation, transform);

        } else if  (obstacleIndex >= 8 && obstacleIndex <= 10) { //billboard
            //targetRotation = Quaternion.Euler(0, 90, 90);
            spawnPoint = transform.GetChild(obstacleIndex).transform;
            Instantiate(billboard, spawnPoint.position, targetRotation, transform);
        }
    }

    public GameObject childPrefab;
    public GameObject policePrefab;
    public GameObject manPrefab;
    public void SpawnPerson () {

        int personIndex = Random.Range(11, 20);
        Transform spawnPoint = null;
        Quaternion targetRotation = Quaternion.Euler(0, 90, 0);

        if (personIndex >= 11 && personIndex <= 13) { //child
            spawnPoint = transform.GetChild(personIndex).transform;
            Instantiate(childPrefab, spawnPoint.position, targetRotation, transform);

        } else if (personIndex >= 14 && personIndex <= 16) { //policajka
            spawnPoint = transform.GetChild(personIndex).transform;
            Instantiate(policePrefab, spawnPoint.position, targetRotation, transform);

        } else if  (personIndex >= 17 && personIndex <= 19) { //man
            spawnPoint = transform.GetChild(personIndex).transform;
            Instantiate(manPrefab, spawnPoint.position, targetRotation, transform);
        }

    }
}
