using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCustomize : MonoBehaviour
{
    public static PlayerCustomize instance;
    public GameObject HandColt;
    public GameObject HandUzi;
    public GameObject HandShotgun;
    public bool hasColt;
    public bool hasUzi;
    public bool hasShotgun;
    public Sprite PlayerWoGun;
    public Sprite PlayerWGun;
    public Animator animator;
    public RuntimeAnimatorController animatorWithGun;
    public RuntimeAnimatorController animatorWithoutGun;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hasColt)
        {
            GetComponent<SpriteRenderer>().sprite = PlayerWGun;
            animator.runtimeAnimatorController = animatorWithGun;

            HandColt.SetActive(true);
            HandUzi.SetActive(false);
            HandShotgun.SetActive(false);
        }

        else if (hasUzi)
        {
            GetComponent<SpriteRenderer>().sprite = PlayerWGun;
            animator.runtimeAnimatorController = animatorWithGun;
            HandUzi.SetActive(true);
            HandColt.SetActive(false);
            HandShotgun.SetActive(false);
        }


        else if (hasShotgun)
        {
            GetComponent<SpriteRenderer>().sprite = PlayerWGun;
            animator.runtimeAnimatorController = animatorWithGun;
            HandShotgun.SetActive(true);
            HandUzi.SetActive(false);
            HandColt.SetActive(false);
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = PlayerWoGun;
            animator.runtimeAnimatorController = animatorWithoutGun;
            HandShotgun.SetActive(false);
            HandUzi.SetActive(false);
            HandColt.SetActive(false);
        }



    }
}
