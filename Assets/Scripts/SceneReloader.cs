using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour
{
    public static SceneReloader instance;

    public GameObject scenefinalizer;

    public bool gameover;

    void Awake()
    {
        instance = this;

    }

    void Update()
    {
        if (gameover) StartCoroutine(GameOver());
    }


    IEnumerator GameOver()
    {
        scenefinalizer.SetActive(true);
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene("Ai");
    }

}
