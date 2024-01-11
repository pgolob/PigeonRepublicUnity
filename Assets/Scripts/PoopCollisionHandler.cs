using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopCollisionHandler : MonoBehaviour
{
    public GameObject poopMarkPrefab;  // Reference to the poop mark prefab
    public float poopMarkDuration = 5f;

    void OnCollisionEnter(Collision collision)
    {
        // Instantiate poop mark at the collision point
        GameObject poopMark = Instantiate(poopMarkPrefab, collision.contacts[0].point, Quaternion.identity);

        Destroy(poopMark, poopMarkDuration);

        // Destroy the poop
        Destroy(gameObject);
    }
}


