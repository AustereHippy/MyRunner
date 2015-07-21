using UnityEngine;
using System.Collections;

public class MovingScript : MonoBehaviour {

    public float speed=80;
    Transform myTransform;
    

    void Awake()
    {
        myTransform = transform;
    }



    void Update()
    {
        myTransform.Translate(0f, 0f, -speed*Time.deltaTime, Space.World);
    }
}
