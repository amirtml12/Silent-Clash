using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    Joystick joystick;
    public GameObject Bullet;
    public Transform BulletPosition;
    public float bulletSpeed = 50f;
    public GameObject player; 
    float GunDirectionX;
    float GunDirectionY;

    float fireRate;          
    float nextFireTime = 0f; 

    void Start()
    {
        player = GetComponent<PlayerController>().gameObject;
        SetFireRate();   
    }

    void Update()
    {
        joystick = FindObjectOfType<Joystick>();
        GunDirectionX = joystick.Horizontal;
        GunDirectionY = joystick.Vertical;

        
        if ((GunDirectionX != 0 || GunDirectionY != 0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;  
        }
    }

   
    void SetFireRate()
    {
        string gun = gameObject.transform.parent.name;

        if (gun == "HandColt")
            fireRate = 0.5f;         

        else if (gun == "HandShotGun")
            fireRate = 0.5f;         

        else if (gun == "HandUzi")
            fireRate = 0.1f;        
    }


    public void Shoot()
    {
        GameObject bullet = Instantiate(Bullet, BulletPosition.position, BulletPosition.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        float playerDirection = player.transform.localScale.x;
        Vector2 direction = playerDirection > 0 ? BulletPosition.right : -BulletPosition.right;
        rb.velocity = direction * bulletSpeed;

        Destroy(bullet, 2f);
    }
}
