using UnityEngine;

public class HandAiming : MonoBehaviour
{
    [Header("References")]
    public Transform rightHand;
    public Transform leftHand;
    public Transform player;  
    public Joystick joystick;

    void Update()
    {
        joystick = FindObjectOfType<Joystick>();
        float x = joystick.Horizontal;
        float y = joystick.Vertical;


        if (x == 0 && y == 0) return;

 
        float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;

        float playerDir = player.transform.localScale.x; 
      
        if (playerDir > 0)
        {
            if (x > 0) 
            {
                rightHand.rotation = Quaternion.Euler(0, 0, angle);
                leftHand.rotation = Quaternion.Euler(0, 0, angle * 2f);
            }
        }
        
        else
        {
            if (x < 0) 
            {
                

                rightHand.rotation = Quaternion.Euler(0, 0, angle + 180f);
                leftHand.rotation = Quaternion.Euler(0, 0, (angle + 180f) * 2f);
            }
        }
    }
}
