using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour
    where T : MonoBehaviour
{
    public static T instance;

    public static T Instance
    {
        get
        {
            //if there is no instance yet,
            if (!instance)
            {
                //find an existing gameobject in the scene that has the generic component
                instance = (T)FindObjectOfType(typeof(T));
            }
            //if after checking the scene, we still don't have an instance..
            if (!instance)
            {
                //load a gameobject from the resources folder that has the generic component
                //check if the system folder in the resources has the name of the generic component
                if (Resources.Load<T>("System/" + (typeof(T)).Name) != null)
                {
                    //if there is a prefab in the system folder,
                    //instantiate that object and set it as the instance
                    T instance = Resources.Load<T>("System/" + (typeof(T)).Name);
                    T go = (T)Instantiate(instance);
                    instance = go;
                }
                else
                {
                    instance = null;
                }
            }
            return instance;
        }
    }

    [SerializeField]
    private bool isPersist = false;

    protected virtual void Awake()
    {
        //if there is no instance, set self as the instance
        if (instance == null)
            instance = this as T;

        //if there is already an existing instance
        if (instance != null)
        {
            //check if self is not the actual instance
            if (instance != this as T)
            {
                //Destroy self because there can only be one instance
                Destroy(this.gameObject);
            }
        }

        if (isPersist)
            DontDestroyOnLoad(this.gameObject);
    }
}
