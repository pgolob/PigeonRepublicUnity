using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    MoveObject moveObject;
    EndGame endGame;

	private void Start () {
        moveObject = GameObject.FindObjectOfType<MoveObject>();
        endGame = GameObject.FindObjectOfType<EndGame>();
	}

    private void OnCollisionEnter (Collision collision)
    {
        
        if (collision.gameObject.name == "Eagle_Normal") {
            Debug.Log("Collision with Eagle_Normal");
            moveObject.speed = 0;
            Animator animator = collision.gameObject.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetTrigger("Collided");
            }
            endGame.die();
        }
    }

    private void Update () {
	
	}
}
