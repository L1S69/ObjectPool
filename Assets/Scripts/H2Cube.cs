using System;
using System.Collections;
using UnityEngine;

public class H2Cube : MonoBehaviour
{
    [SerializeField] private float lifetime = 2f;

    private void OnEnable()
    {
        StartCoroutine("ShowCube");
    }
    
    private void OnDisable()
    {
        StopCoroutine("ShowCube");
    }
    
    
    private IEnumerator ShowCube()
    {
        yield return new WaitForSeconds(lifetime);
        gameObject.SetActive(false);
    }
    
}
