using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPoolScript : MonoBehaviour {

    public static ObjectPoolScript current;
    public GameObject[] pooledObject;
    GameObject[][] pooledObjects = new GameObject[5][];
    int pooledAmount;
    public int pooledBarriers = 15;
    public int pooledBackWorlds = 15;
    public int pooledCoins = 50;
    public static int num;

    

    void Awake()
    {
        current = this;
    }


    void Start()
    {
        
        pooledObjects[0] = new GameObject[pooledCoins];
        pooledObjects[1] = new GameObject[pooledBarriers];
        pooledObjects[2] = new GameObject[pooledBarriers];
        pooledObjects[3] = new GameObject[pooledBarriers];
        pooledObjects[4] = new GameObject[pooledBackWorlds];
        

        

        for (int i = 0; i < pooledObjects.Length; i++)
        {
            if (i == 0)
            {
                pooledAmount = pooledCoins;
                
            }
            else if (i == 4)
            {
                pooledAmount = pooledBackWorlds;
            }
            else
            {
                pooledAmount = pooledBarriers;
                
            } 

            for (int j = 0; j < pooledAmount; j++)
            {
                pooledObjects[i][j] = (GameObject)Instantiate(pooledObject[i]);
                pooledObjects[i][j].SetActive(false);
            }
        }

            
    }

    public GameObject GetPooledObject()
    {
            for (int i = 0; i < pooledObjects[num].Length; i++)
            {
                if (!pooledObjects[num][i].activeInHierarchy)
                {
                    return pooledObjects[num][i];
                }
            }
        return null;
    }


}
