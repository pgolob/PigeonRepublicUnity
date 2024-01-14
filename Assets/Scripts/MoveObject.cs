using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveObject : MonoBehaviour
{
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(0,0,Vector3.forward * speed * Time.deltaTime);
        float hits = PoopSpawn.poopHitCount;
        if(speed != 0) {
            transform.Translate(-Time.deltaTime*speed - hits * (float)0.02, 0, 0);
        } else {
            transform.Translate(-Time.deltaTime*speed, 0, 0);
        }

    }
}
