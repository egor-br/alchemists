using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Element : MonoBehaviour
{


    public GameObject[] objCategory_0;
    public GameObject[] objCategory_1;
    public GameObject[] objCategory_2;
    public GameObject[] objCategory_3;
    public GameObject[] objCategory_4;
    public GameObject[] objCategory_5;
    public GameObject[] objCategory_6;
    public GameObject[] objCategory_7;
    public GameObject[] objCategory_8;
    public GameObject[] objCategory_9;
    public GameObject[] objCategory_10;
    public GameObject[] objCategory_11;
    public GameObject[] objCategory_12;
    public GameObject[] objCategory_13;
    // Start is called before the first frame update
    void Start()
    {
        objCategory_0[0] = new GameObject("name", typeof(Button), typeof(GraphicRaycaster));
        objCategory_0[0].GetComponent<Canvas>().sortingOrder = 100;
        objCategory_0[0].GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
        objCategory_0[0].GetComponent<Canvas>().worldCamera = Camera.main;
        objCategory_0[0].GetComponent<Button>().enabled = true;
        
        objCategory_0[0].GetComponent<Transform>().position = new Vector2(-600, 100);
        objCategory_0[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
