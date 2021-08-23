using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : Singleton<ObjectPoolManager>
{
    public List<ObjectPoolItem> itemsToPool;
    [SerializeField]
    private List<GameObject> pooledObjects;

    public void PrintConsole()
    {
        Debug.Log("I AM THE OBJECT POOL MANAGER");
    }

    private void Start()
    {
        pooledObjects = new List<GameObject>();
        //Traverse through each objectpoolitem in the list
        foreach (ObjectPoolItem item in itemsToPool)
        {
            //instantiate the object's prefab based on the inital amounttopool
            for (int i = 0; i < item.amountToPool; i++)
            {
                //Instantiate the prefab
                GameObject obj = Instantiate(item.objectToPool, item.parent);
                obj.AddComponent<PooledObjectItem>();
                obj.GetComponent<PooledObjectItem>().ID = item.id;
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
    }

    public GameObject GetPooledObject(string id)
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            //we need to make sure that the object is not active
            //and that the object has the same id
            if (!pooledObjects[i].activeInHierarchy &&
                pooledObjects[i].GetComponent<PooledObjectItem>().ID == id)
            {
                return pooledObjects[i];
            }
        }

        //if all objects are currently in use
        //check if the object can expand and then instantiate a new object and add it to the pool
        foreach (ObjectPoolItem item in itemsToPool)
        {
            if (item.id == id)
            {
                if (item.shouldExpand)
                {
                    GameObject obj = Instantiate(item.objectToPool, item.parent);
                    obj.AddComponent<PooledObjectItem>();
                    obj.GetComponent<PooledObjectItem>().ID = item.id;
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    return obj;
                }
            }
        }

        return null;
    }
}
