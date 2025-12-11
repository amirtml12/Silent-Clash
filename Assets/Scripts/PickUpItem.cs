using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{


    void OnMouseDown()
    {
        if (transform.parent.gameObject.name == "Colt")
        {
            ShootingButton.instance.gameObject.SetActive(true);
            PlayerCustomize.instance.hasColt = true;
            PlayerCustomize.instance.hasUzi = false;
            PlayerCustomize.instance.hasShotgun = false;
        }
        else if (transform.parent.gameObject.name == "Uzi")
        {
            ShootingButton.instance.gameObject.SetActive(true);
            PlayerCustomize.instance.hasUzi = true;
            PlayerCustomize.instance.hasColt = false;
            PlayerCustomize.instance.hasShotgun = false;
        }
        else if (transform.parent.gameObject.name == "Shotgun")
        {
            ShootingButton.instance.gameObject.SetActive(true);
            PlayerCustomize.instance.hasShotgun = true;
            PlayerCustomize.instance.hasColt = false;
            PlayerCustomize.instance.hasUzi = false;
        }
        else
        {
            ShootingButton.instance.gameObject.SetActive(false);
        }

        Destroy(transform.parent.gameObject);
    }
}
