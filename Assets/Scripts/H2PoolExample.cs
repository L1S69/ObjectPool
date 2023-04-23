using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class H2PoolExample : MonoBehaviour
{
    [SerializeField] private int poolSize = 3; //default pool size
    [SerializeField] private bool autoExtend = false; //default возможность или невозможность to automatically extend the pool
    [SerializeField] private H2Cube h2CubePrefab; // prefab reference
    [SerializeField] private float horizontalConstraint; //horizontal constraint of a spawn zone
    [SerializeField] private float verticalConstraint; //vertical constraint of a spawn zone

    [SerializeField] private Pool<H2Cube> _pool1; //pool of H2Cubes

    private void Start()
    {
        _pool1 = new Pool<H2Cube>(h2CubePrefab, poolSize, transform);
        _pool1.autoExtend = autoExtend;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateCube();
        }
    }

    private void CreateCube()
    {
        var rx = Random.Range(-horizontalConstraint, horizontalConstraint);
        var rz = Random.Range(-verticalConstraint, verticalConstraint);
        var ry = 0;
        var pos = new Vector3(rx,ry,rz);
        var cube = _pool1.GetFreeElement();
        cube.transform.position = pos;

    }
    
}
