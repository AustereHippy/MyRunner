using UnityEngine;
using System.Collections;

public class ParallaxGroundScript : MonoBehaviour {

    Renderer rend;
    public float scrollSpeed = 1;
    public bool reverse = false;
    

    void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = scrollSpeed*Time.time;
        if (reverse)
        {
            rend.material.mainTextureOffset = new Vector2(-offset, 0);
        }
        rend.material.mainTextureOffset = new Vector2(0, offset);
    }

}
