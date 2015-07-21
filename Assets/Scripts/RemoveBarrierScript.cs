using UnityEngine;
using System.Collections;

public class RemoveBarrierScript : MonoBehaviour {
    
    GameObject barrier;
    Vector3 center;
    float radius = 6f;

    void Start()
    {
        barrier = gameObject;
        center = barrier.transform.position;
        Remove(center, radius);
    }

    void Remove(Vector3 center, float radius)
    {
        Collider[] barrierColliders = Physics.OverlapSphere(center, radius);
        for (int i = 1; i < barrierColliders.Length; i++)
        {
            if (barrierColliders[i].gameObject.name == "LongPipe(Clone)")
            {
                barrier.SetActive(false);
                return;
            }
        }

    }



}
