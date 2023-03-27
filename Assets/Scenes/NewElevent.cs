using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Structs;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class NewElevent : MonoBehaviour
{
    public RectTransform leftItem;
    public RectTransform rightItem;
    public RectTransform centerItem;
    private string leftItemId;
    private string rightItemId;
    private string leftItemName;
    private string rightItemName;

    public void ElNull()
    {
        leftItem.GetChild(0).GetComponent<Image>().enabled = false;
        rightItem.GetChild(0).GetComponent<Image>().enabled = false;
    }

    public void UpdateEl()
    {
        for (int i = 0; i < DataCore.statItems.Length; i++)
        {
            if (DataCore.statItems[i].name == leftItemName)
            {
                leftItemId = DataCore.statItems[i].id.ToString();
            }

            if (DataCore.statItems[i].name == rightItemName)
            {
                rightItemId = DataCore.statItems[i].id.ToString();
            }
        }
        for (int i = 0; i < DataCore.statItems.Length; i++)
        {
            if ((DataCore.statItems[i].firstCraftElementId == leftItemId && DataCore.statItems[i].secondCraftElementId == rightItemId) ||
             (DataCore.statItems[i].firstCraftElementId == rightItemId && DataCore.statItems[i].secondCraftElementId == leftItemId))
            {

                //aim.Play("NewAnimationEl");
                //aim.SetTrigger("fade");

                DataCore.statItems[i].opened = true;
                centerItem.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(DataCore.statItems[i].id.ToString());
                Color newColor = centerItem.GetChild(0).GetComponent<Image>().color;

                newColor.a = 1;
                centerItem.GetChild(0).GetComponent<Image>().color = newColor;
                centerItem.GetChild(0).GetComponent<Image>().enabled = true;
            }

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
