using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settingScript : MonoBehaviour
{
    private int[,] resolution;
    private int resolution_size;
    private int current_resolution;

    public Text text;

    public void save()
    {
        Screen.SetResolution(resolution[current_resolution, 0], resolution[current_resolution, 1], false);
    }

    public void next()
    {
        if(current_resolution < resolution_size)
        {
            current_resolution++;
        }
        text.text = resolution[current_resolution, 0] + "X" + resolution[current_resolution, 1];
    }

    public void previous()
    {
        if (current_resolution > 0)
        {
            current_resolution--;
        }
        text.text = resolution[current_resolution, 0] + "X" + resolution[current_resolution, 1];
    }

    void Start()
    {
        resolution_size = 2;
        current_resolution = 0;
        resolution = new int[,] {
            { 1920,1080},
        { 1280,920},
        { 920,640}
        };
    }
}
