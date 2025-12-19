using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwitchGun : MonoBehaviour
{

    public GameObject Uzi;
    public GameObject ShotGun;
    public GameObject Colt;
    public int CurrentState = 0;


    public void Switch()
    {
        CurrentState += 1;

        if (CurrentState > 3) CurrentState = 1;

        if (CurrentState == 1)
        {

            PlayerCustomize.instance.hasColt = true;
            PlayerCustomize.instance.hasUzi = false;
            PlayerCustomize.instance.hasShotgun = false;
        }


        if (CurrentState == 2)
        {


            PlayerCustomize.instance.hasUzi = true;
            PlayerCustomize.instance.hasColt = false;
            PlayerCustomize.instance.hasShotgun = false;

        }

        if (CurrentState == 3)
        {
            PlayerCustomize.instance.hasShotgun = true;
            PlayerCustomize.instance.hasColt = false;
            PlayerCustomize.instance.hasUzi = false;
        }
    }






}
