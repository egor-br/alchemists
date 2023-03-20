using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeLayout : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] obj = new GameObject[14];

    public void ChangeLay(int idButton)
    {
        DataCore.currentCategory = idButton.ToString();

        obj[idButton].GetComponent<Canvas>().sortingOrder = 10000;
        for (int i = 0; i < 14; i++)
        {
            if (i!=idButton)
                obj[i].GetComponent<Canvas>().sortingOrder = 3;
        }
    }

    void Start()
    {
        DataCore.currentCategory = "0";
        
        obj[0].GetComponent<Canvas>().sortingOrder = 10000;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
