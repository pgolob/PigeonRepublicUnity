using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoopCollisionHandler : MonoBehaviour
{
    public GameObject poopMarkPrefab;  // Reference to the poop mark prefab
    public float poopMarkDuration = 5f;


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ppl"))
        {
            // Increment the hit count
            PoopSpawn.poopHitCount++;
            Debug.Log("poopcounter: " + PoopSpawn.poopHitCount);
            
            Animator animator = collision.gameObject.GetComponent<Animator>();
            if (animator != null)
            {
                Debug.Log("stop");
                animator.SetTrigger("hit");
            }
            // You may want to play a sound, spawn a particle effect, etc.

            // Destroy the poop
            Destroy(gameObject);
        }else{
            // Instantiate poop mark at the collision point
            GameObject poopMark = Instantiate(poopMarkPrefab, collision.contacts[0].point, Quaternion.identity);

            Destroy(poopMark, poopMarkDuration);
            // Destroy the poop
            Destroy(gameObject);
        }
    }
}