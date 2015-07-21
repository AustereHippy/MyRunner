using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {

    Transform myTransform;

    public float rotationSpeed = 5f;

    void Awake()
    {
        myTransform = transform;
    }

    void Update()
    {
        myTransform.Rotate(0f, 0f, rotationSpeed);
    }
}
