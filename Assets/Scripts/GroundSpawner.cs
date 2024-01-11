using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    Vector3 nextSpawnPoint;

    public void SpawnTile()
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        BoxCollider collider = temp.AddComponent<BoxCollider>();
        collider.isTrigger = false;
        collider.size = new Vector3(150, 1, 10);
        collider.center = new Vector3(40, -60, 4);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 5; i++){
            SpawnTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
