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
        PlayerController pc = other.gameObject.GetComponent<PlayerController>();
        
        if (pc != null)
        {
            pc.TakeDamage(1);
            EnemyController.instance.TakeDamage(2);
            
        

        }

        Destroy(gameObject);
    }
}

}
