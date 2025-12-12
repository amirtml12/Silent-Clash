using UnityEngine;
using UnityEngine.UI;


public class Shooting : MonoBehaviour
{
    
    public GameObject Bullet;
    public Transform BulletPosition;
    public float bulletSpeed = 50f;
    public GameObject player;

    float nextFireTime = 0f;
    public float fireRate;

    float x, y;
    public string gun;

    void Start()
    {
        player = GetComponent<PlayerController>().gameObject;


    }

    void Update()
    {
        
        
        SetFireRate();
        if ( ShootingButton.instance.ShootingPressed && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    
    void SetFireRate()
    {
        gun = transform.parent.name;

        if (gun == "ForhandColt")
            fireRate = 1f;

        else if (gun == "ForhandShotGun")
            fireRate = 1f;

        else if (gun == "ForhandUzi")
            fireRate = 0.5f;
    }

    
    public void Shoot()
    {
        GameObject bullet = Instantiate(Bullet, BulletPosition.position, BulletPosition.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        float dir = player.transform.localScale.x;
        Vector2 shootDir = dir > 0 ? BulletPosition.right : -BulletPosition.right;

        rb.velocity = shootDir * bulletSpeed;

        Destroy(bullet, 2f);
    }
}
