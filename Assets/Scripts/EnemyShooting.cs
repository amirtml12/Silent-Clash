using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public static EnemyShooting instance;

    public GameObject Bullet;
    public Transform BulletPosition;
    public float bulletSpeed = 50f;
    public GameObject Enemy;

    float nextFireTime = 0f;
    public float fireRate;

    float x, y;
    public string gun;

    void Awake()
    {
        instance = this;
    }




    void Start()
    {
        Enemy = GetComponent<EnemyController>().gameObject;


    }

    public void Shooting()
    {

        
        if ( Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }


   


    public void Shoot()
    {
        GameObject bullet = Instantiate(Bullet, BulletPosition.position, BulletPosition.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        float dir = Enemy.transform.localScale.x;
        Vector2 shootDir = dir > 0 ? BulletPosition.right : -BulletPosition.right;

        rb.velocity = shootDir * bulletSpeed;

        Destroy(bullet, 2f);
    }
}

