using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BearShoot : MonoBehaviour
{
    public Rigidbody bullet;

    Transform turret;
    float time = .3f;
    float bulletSpeed = 5f;
    float shootDelay = .25f;

    void Start()
    {
        turret = GameObject.Find("Turret").transform;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.P)) ShootBullet();
    }

    // function to shoot bullets at the turret
    void ShootBullet()
    {
        time += Time.deltaTime;

        Rigidbody bulletClone;

        if (time > shootDelay)
        {
            bulletClone = (Rigidbody)Instantiate(bullet, transform.position, Quaternion.identity);
            bulletClone.gameObject.GetComponent<BulletAI>().turret = turret.gameObject;
            bulletClone.rotation = transform.rotation;
            bulletClone.AddForce((turret.position - transform.position) * bulletSpeed, ForceMode.Force);

            time = 0.0f;
        }
    }
}