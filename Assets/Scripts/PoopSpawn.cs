using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PoopSpawn : MonoBehaviour
{
    public GameObject poopPrefab;  // The poop prefab (sphere in this case)
    public GameObject poopMarkPrefab;
    public Transform poopSpawnPoint;  // The spawn point for the poop
    public float poopForce = 5f;  // The force with which poop is thrown
    public float poopForwardForce = 2f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnPoop();
        }
    }

    void SpawnPoop()
    {
        Vector3 spawnPosition = poopSpawnPoint.position;
        // Instantiate poop at the spawn point
        GameObject poop = Instantiate(poopPrefab, spawnPosition, Quaternion.identity);

        Vector3 poopForceDirection = transform.forward * poopForwardForce + Vector3.down;

        // Apply force to the poop
        Rigidbody poopRb = poop.GetComponent<Rigidbody>();
        if (poopRb != null)
        {
            poopRb.AddForce(poopForceDirection * poopForce, ForceMode.Impulse);
        }

        // Destroy poop after some time (adjust as needed)
        //Destroy(poop, 5f);
        PoopCollisionHandler poopCollisionHandler = poop.AddComponent<PoopCollisionHandler>();
        poopCollisionHandler.poopMarkPrefab = poopMarkPrefab;
    }

    /*void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }*/
}
