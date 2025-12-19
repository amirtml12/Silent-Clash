using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject PlayerController;




   void OnCollisionEnter2D(Collision2D other)
{
    if (other.gameObject.CompareTag("Player"))
    {
        PlayerController2.instance.TakeDamage(1);
    }
    else if (other.gameObject.CompareTag("Enemy"))
    {
        EnemyController enemy = other.gameObject.GetComponent<EnemyController>();

        if (enemy != null)
        {
            enemy.TakeDamage(2);
        }
    }

    Destroy(gameObject);
}


}
