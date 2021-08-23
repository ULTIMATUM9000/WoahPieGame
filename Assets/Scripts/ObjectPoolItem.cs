using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPoolItem
{
    //unique identifier
    public string id;
    //prefab
    public GameObject objectToPool;
    //parent transform to attach the object once instantiated
    public Transform parent;
    //how many objects will be instantiated at the beginning
    public int amountToPool;
    //if we reached the maximum amount to pool, instantiate a new prefab instance
    public bool shouldExpand;
}

