using UnityEngine;
using System.Collections;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

// Quits the player when the user hits escape

public class ClosGame : MonoBehaviour
{
    public void Close()
    {
        Application.Quit();
        /* if (Input.GetKey("escape"))  
         {
             Application.Quit();   
         }*/
    }
}