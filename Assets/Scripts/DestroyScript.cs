using UnityEngine;
using System.Collections;

public class DestroyScript : MonoBehaviour {

    public int destroyTime = 10;

    void OnEnable()
    {
        Invoke("Destroy", destroyTime);
    }

    void Destroy()
    {
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        CancelInvoke();
    }


}
