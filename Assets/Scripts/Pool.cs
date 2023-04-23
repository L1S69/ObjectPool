using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class Pool<T> where T: MonoBehaviour
{
    public T prefab { get;  } // prefab reference
    public bool autoExtend { get; set; } // should the pool be extandable
    public Transform container { get;  }

    private List<T> poolList;

    public Pool(T prefab)
    {
        this.prefab = prefab;
    }

   
    
    public Pool(T prefab, int size, Transform container)
    {
        this.prefab = prefab;
        this.container = container;
        CreatePool(size);
    }

   
    
    private void CreatePool(int size)
    { 
        poolList = new List<T>();
        for (var i = 0; i < size; i++)
        {
            CreateObject();
        }
    }

  
    
    private T CreateObject(bool isActiveByDefault = false)
    {
        var createdObject = Object.Instantiate(prefab, container); // instantiate the prefab
        createdObject.gameObject.SetActive(isActiveByDefault); // make it active or not depending on the input parameters
        poolList.Add(createdObject); // add it to the pool
        return createdObject; // return it
    }

    public bool HasFreeElement(out T element)
    {
        foreach (var mono in poolList)
        {
            if (mono.gameObject.activeInHierarchy) continue;
            element = mono;
            mono.gameObject.SetActive(true);
            return true;
        }
        element = null;
        return false;
    }

    public T GetFreeElement()
    {
        if (this.HasFreeElement(out var element)) return element; // if pool has a free element return it
        if (this.autoExtend) return this.CreateObject(true); // if it hasn't any but is extandable, extend it
        throw new Exception($"can't add an element of type {typeof(T)}"); // otherwise throw exception
    }
    
}
