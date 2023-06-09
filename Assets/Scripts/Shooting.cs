using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Shooting : Singleton<Shooting>
{
    public AudioSource bulletVFX;
    public GameObject bulletPrefab;
    public Transform shootingPoint;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bulletVFX.Play();
            var bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.Euler(0, 0 - transform.localEulerAngles.y, 0));
            bullet.GetComponent<Rigidbody>().AddForce(shootingPoint.transform.forward * 5000);
        }
    }
}