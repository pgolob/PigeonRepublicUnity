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
        spawnObstacle();
  
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

    [SerializeField] GameObject obstaclePrefab;
    public void spawnObstacle(){
        int numObstacles = 10;
        for (int i = 0; i < numObstacles; i++) {
            GameObject prefabToSpawn = PrefabManager.Instance.obstaclePrefab;
            if (prefabToSpawn != null) {
                GameObject temp = Instantiate(prefabToSpawn, transform);
                temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
                Debug.Log(temp.transform.position);
            } else {
                Debug.LogError("Obstacle Prefab is not assigned in PrefabManager");
            }
        }
    }
    Vector3 GetRandomPointInCollider (Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if (point != collider.ClosestPoint(point)) {
            point = GetRandomPointInCollider(collider);
        }

        point.y = -60;
        return point;
    }
}
