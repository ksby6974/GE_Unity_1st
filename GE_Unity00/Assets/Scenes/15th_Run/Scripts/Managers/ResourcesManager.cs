using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : Singleton<ResourcesManager>
{
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject prefab = Load<GameObject>(path);

        if (prefab == null)
        {
            Debug.Log($"Failed to Load Prefab : {prefab}");
        }

        GameObject clone = Object.Instantiate(prefab, parent);

        int index = prefab.name.IndexOf("(Clone)");

        if (index > 0)
        {
            clone.name = clone.name.Substring(0, index);
        }

        return clone;
    }

    public void Destory(GameObject prefab)
    {
        if (prefab == null)
        {
            return;
        }

        Object.Destroy(prefab.gameObject);
    }
}
