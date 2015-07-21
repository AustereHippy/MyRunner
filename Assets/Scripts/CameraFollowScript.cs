using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {

    Transform playerTransform;
    public float followSpeed = 10f;
    

    Transform cameraTransform;
    

    void Start()
    {
        
        playerTransform = GameObject.FindWithTag("Player").transform;
        cameraTransform = transform;
        
    }
        
    void Update()
    {
        cameraTransform.position = new Vector3(Mathf.Lerp(cameraTransform.position.x, playerTransform.position.x, Time.deltaTime * followSpeed), cameraTransform.position.y, cameraTransform.position.z);
        
    }


}
