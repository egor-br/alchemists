using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;

public class LavakCharge : MonoBehaviour
{
    private Animator aim;
    public int levelToload;


    void Start()
    {
        aim = GetComponent<Animator>();

    }

    public void FadeToLovel()
    {
        aim = GetComponent<Animator>();

        aim.SetTrigger("fade");

    }
    public void OnFadeToLovel(int scene_id)
    {
       
        SceneManager.LoadScene(1);

    }
}
