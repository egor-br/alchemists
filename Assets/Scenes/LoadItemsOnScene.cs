using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Structs;
using System;
using System.IO;

public class LoadItemsOnScene : MonoBehaviour
{
    public DataCore dataCore; 
    public void Load() {
        Debug.Log(DataCore.statItems.Length);
    }
}