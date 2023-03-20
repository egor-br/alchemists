using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Structs;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class MovingItems : MonoBehaviour
{
    public RectTransform leftItem;
    public RectTransform rightItem;

    private string leftItemName;
    private string rightItemName;
    
    private string leftItemId;
    private string rightItemId;
    
    public void resetItem(RectTransform rect)
    {
        Color newColor = rect.GetChild(0).GetComponent<Image>().color;
        newColor.a = 0;
        rect.GetChild(0).GetComponent<Image>().color = newColor;
        rect.GetChild(0).GetComponent<Image>().enabled = false;

        leftItemName = "";
        rightItemName = "";
        leftItemId = "";
        rightItemId = "";
    }

    public void move(RectTransform rect)
    {
         if(leftItem.GetChild(0).GetComponent<Image>().enabled  == true && 
        rightItem.GetChild(0).GetComponent<Image>().enabled  == true )
        {
            Color newColor = leftItem.GetChild(0).GetComponent<Image>().color;
            newColor.a = 0;
            leftItem.GetChild(0).GetComponent<Image>().color = newColor;
            leftItem.GetChild(0).GetComponent<Image>().enabled = false;
            
            newColor = rightItem.GetChild(0).GetComponent<Image>().color;
            newColor.a = 0;
            rightItem.GetChild(0).GetComponent<Image>().color = newColor;
            rightItem.GetChild(0).GetComponent<Image>().enabled = false;

            leftItemName = "";
            rightItemName = "";
            leftItemId = "";
            rightItemId = "";
        }

        if(leftItem.GetChild(0).GetComponent<Image>().enabled  == false)
        {
            leftItem.GetChild(0).GetComponent<Image>().sprite = rect.GetChild(0).GetComponent<Image>().sprite;
            
            Color newColor = leftItem.GetChild(0).GetComponent<Image>().color;
            newColor.a = 1;
            leftItem.GetChild(0).GetComponent<Image>().color = newColor;
            leftItem.GetChild(0).GetComponent<Image>().enabled = true;

            leftItemName = rect.GetChild(1).GetComponent<Text>().text;
        }
        else if(rightItem.GetChild(0).GetComponent<Image>().enabled  == false)
        {
            rightItem.GetChild(0).GetComponent<Image>().sprite = rect.GetChild(0).GetComponent<Image>().sprite;
            
            Color newColor = rightItem.GetChild(0).GetComponent<Image>().color;
            newColor.a = 1;
            rightItem.GetChild(0).GetComponent<Image>().color = newColor;
            rightItem.GetChild(0).GetComponent<Image>().enabled = true;
            
            rightItemName = rect.GetChild(1).GetComponent<Text>().text;
        }
    }

    
    void Start()
    {
        leftItem.GetChild(0).GetComponent<Image>().enabled = false;
        rightItem.GetChild(0).GetComponent<Image>().enabled = false;
    }

    void Update()
    {
        if(leftItem.GetChild(0).GetComponent<Image>().enabled  == true && 
        rightItem.GetChild(0).GetComponent<Image>().enabled  == true )
        {
            for (int i = 0; i < DataCore.statItems.Length; i++)
            {
                if(DataCore.statItems[i].name == leftItemName)
                {
                    leftItemId = DataCore.statItems[i].id.ToString();
                }

                if(DataCore.statItems[i].name == rightItemName)
                {
                    rightItemId = DataCore.statItems[i].id.ToString();
                }
            }
            
            for (int i = 0; i < DataCore.statItems.Length; i++)
            {
                if((DataCore.statItems[i].firstCraftElementId == leftItemId && DataCore.statItems[i].secondCraftElementId == rightItemId) ||
                 (DataCore.statItems[i].firstCraftElementId == rightItemId && DataCore.statItems[i].secondCraftElementId == leftItemId))
                {
                    DataCore.statItems[i].opened = true;
                }

            }
        }
    }
}
