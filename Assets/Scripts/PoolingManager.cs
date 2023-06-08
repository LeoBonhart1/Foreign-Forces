using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolingManager : Singleton<PoolingManager>
{
    [SerializeField] private int poolingSize;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private List<GameObject> bulletPool;

    private void Awake()
    {
        PoolInit();
    }

    private void PoolInit()
    {
        for (var i = 0; i < poolingSize; i++)
        {
            var gO = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity, transform);
            bulletPool.Add(gO);
            gO.SetActive(false);
        }
    }

    private GameObject GetAvailableBullet()
    {
        return bulletPool.FirstOrDefault(go => !go.activeSelf);
    }

    public void UseBullet(Transform tr)
    {
        var bullet = GetAvailableBullet();
        var bulletRb = bullet.GetComponent<Rigidbody>();

        bullet.transform.localPosition = tr.position;
        bullet.transform.localEulerAngles = tr.localEulerAngles;
        bullet.SetActive(true);
        bulletRb.AddForce(tr.forward * 10000);
    }

    public void BulletReturn(GameObject go)
    {
        go.SetActive(false);
        go.transform.localPosition = Vector3.zero;
    }
}