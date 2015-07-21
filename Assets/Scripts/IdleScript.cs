using UnityEngine;
using System.Collections;

public class IdleScript : MonoBehaviour {

    Animator anim;
    
    public int IdleNum;

    void Awake()
    {
        anim = GetComponent<Animator>();

    }

    void OnEnable()
    {
        
        if (Application.loadedLevel == 0)
        {
            anim.SetInteger("idle", IdleNum);
        }
        
    }


	
}
