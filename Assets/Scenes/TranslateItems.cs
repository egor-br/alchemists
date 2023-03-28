using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Structs;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TranslateItems : MonoBehaviour
{
    public RectTransform item;
    public RectTransform canvas;

    static public RectTransform _canvas;
    static public Vector3 startPos;
    static private float progress;
    static public Vector3 endPos;
    public float step;

    // Start is called before the first frame update
    void Start()
    {
        _canvas = canvas;
        progress = 1;
        step = 0.01f;
        transform.position = startPos;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(progress > 1)
        {
            Color newColor = item.GetChild(0).GetComponent<Image>().color;
            newColor.a = 0;
            item.GetChild(0).GetComponent<Image>().color = newColor;
            item.GetChild(0).GetComponent<Image>().enabled = false;
            item.transform.localPosition = startPos;
        } else
        {
            item.transform.localPosition = Vector3.Lerp(startPos, endPos, progress);
            item.transform.localScale = new Vector3(1.5f - progress, 1.5f - progress, 1.5f - progress);

            progress += step;
        }
    }

    static public void reset(int category)
    {
        startPos = new Vector3(0,0,0);
        progress = 0;
        if(_canvas.GetChild(category).GetComponent<RectTransform>().anchoredPosition3D.x < 0)
        {
            endPos = new Vector3(_canvas.GetChild(category).GetComponent<RectTransform>().anchoredPosition3D.x - 30,
            _canvas.GetChild(category).GetComponent<RectTransform>().anchoredPosition3D.y + 10,
            _canvas.GetChild(category).GetComponent<RectTransform>().anchoredPosition3D.z);
        }else
        {
            endPos = new Vector3(_canvas.GetChild(category).GetComponent<RectTransform>().anchoredPosition3D.x,
            _canvas.GetChild(category).GetComponent<RectTransform>().anchoredPosition3D.y + 10,
            _canvas.GetChild(category).GetComponent<RectTransform>().anchoredPosition3D.z);
        }

    }
}
