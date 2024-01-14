using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour {

    MoveObject moveObject;
    GameOver gameOver;
	private void Start () {
        moveObject = GameObject.FindObjectOfType<MoveObject>();
        gameOver = GameObject.FindObjectOfType<GameOver>();
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
            Invoke("dead", 1);
        }
    }

    private void dead() {
        SceneManager.LoadScene(2);
        PoopSpawn.poopHitCount = 0;
    }

    private void Update () {
	
	}
}
