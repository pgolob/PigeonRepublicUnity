using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    MoveObject moveObject;

	private void Start () {
        moveObject = GameObject.FindObjectOfType<MoveObject>();
	}

    private void OnCollisionEnter (Collision collision)
    {
        Debug.Log("Collision with Eagle_Normal");
        moveObject.speed = 0;
        if (collision.gameObject.name == "Eagle_Normal") {
            Animator animator = collision.gameObject.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetTrigger("Collided");
            }
        }
    }

    private void Update () {
	
	}
}
