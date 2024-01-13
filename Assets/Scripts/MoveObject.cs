using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speed = 10f + (PoopSpawn.poopHitCount)*3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(0,0,Vector3.forward * speed * Time.deltaTime);
        transform.Translate(-Time.deltaTime*speed, 0, 0);
    }
}
