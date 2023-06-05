using System;
using UnityEngine;

public class Shooting : Singleton<Shooting>
{
    private PoolingManager _poolingManager;

    public Transform shootingPoint;

    private void Awake()
    {
        _poolingManager = PoolingManager.Instance;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _poolingManager.UseBullet(shootingPoint);
        }
    }
}