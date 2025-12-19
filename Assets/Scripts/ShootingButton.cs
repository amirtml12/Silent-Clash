using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingButton : MonoBehaviour
{
    public static ShootingButton instance;
    
    public bool ShootingPressed = false;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void  Start()
    {
        gameObject.SetActive(false);
    }


    public void Shooting()
    {
        ShootingPressed = true;
    }

    public void ShootingReleased()
    {
        ShootingPressed = false;
    }
}


    
