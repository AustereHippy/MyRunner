using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour
{


    public float spawnTime;
    public float spawnRepeat;
    int rand;
    int delayForSpawn;
    Vector3 fwd;
    bool spawn = true;
    int layerMaskBarrier;
    Transform myTransform;
    Quaternion myQuat;


    void Awake()
    {
        myTransform = transform;
        Vector3 fwd = myTransform.TransformDirection(Vector3.forward);
    }
    

    void Start()
    {
        fwd = transform.TransformDirection(Vector3.forward);
        

        if (gameObject.tag == "BarrierSpawn")
        {
            InvokeRepeating("BarrierSpawn", spawnTime, spawnRepeat);
        }
        layerMaskBarrier = LayerMask.GetMask("Barrier");

        if (gameObject.tag == "BackgroundSpawn")
        {
            if (gameObject.name == "BackWorldSpawner2")
            {
                myQuat = new Quaternion(0, 180, 0, 0);
            }
            else myQuat = new Quaternion(0, 0, 0, 0);
            InvokeRepeating("BackgroundSpawn", spawnTime, spawnRepeat);
        }
        
    }


    void Update()
    {
        if (spawn && gameObject.tag == "CoinSpawn")
        {
            InvokeRepeating("CoinSpawn", spawnTime, spawnRepeat);
            spawn = false;
            StartCoroutine(DelaySpawn());
        }
    }

    IEnumerator DelaySpawn()
    {
        delayForSpawn = Random.Range(4, 15);
        yield return new WaitForSeconds(delayForSpawn);
        CancelInvoke("CoinSpawn");
        delayForSpawn = Random.Range(4, 10);
        yield return new WaitForSeconds(delayForSpawn);
        spawn = true;
    }

    void CoinSpawn()
    {
        
        if (!Physics.Raycast(myTransform.position, fwd, 3, layerMaskBarrier) && !Physics.Raycast(myTransform.position, -fwd, 3, layerMaskBarrier))
        {
            ObjectPoolScript.num = 0;
            rand = 1;
            TakeFromPool();
        }
    }


    void BarrierSpawn()
    {
        ObjectPoolScript.num = Random.Range(1, 4);
        rand = Random.Range(-3, 4) * 2;
        TakeFromPool();
    }

    void BackgroundSpawn()
    {
        ObjectPoolScript.num = 4;
        rand = 1;
        TakeFromPool();
    }

    void TakeFromPool()
    {
        GameObject obj = ObjectPoolScript.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = new Vector3(myTransform.position.x, obj.transform.position.y, myTransform.position.z + rand);
        if (obj.tag == "BackWorld")
        {
            obj.transform.rotation = myQuat;
        }
        obj.SetActive(true);
    }


}
