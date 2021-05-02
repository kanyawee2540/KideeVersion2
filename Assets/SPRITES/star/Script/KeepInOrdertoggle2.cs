using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class KeepInOrdertoggle2 : MonoBehaviour
{
    // Start is called before the first frame update 
    ToggleGroup KeepInOrderGroup;
    public static int countScore1=0;

    void Start()
    {
        KeepInOrderGroup = GetComponent<ToggleGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Submit()
    {
        countScore1=0;
        Toggle keepInOrdertoggle1 =KeepInOrderGroup.ActiveToggles().FirstOrDefault();
        Debug.Log(keepInOrdertoggle1.name);
        string keepInOrdername1=""+keepInOrdertoggle1.name;
        if(keepInOrdername1.Equals("1"))
        {
           // Debug.Log("Score :11111");
            countScore1=countScore1+1;
        }
        else if(keepInOrdername1.Equals("2"))
        {
            //Debug.Log("Score :2");
            countScore1=countScore1+2;

        }
        else if(keepInOrdername1.Equals("3"))
        {
           // Debug.Log("Score :3");
            countScore1=countScore1+3;
        }
        else if(keepInOrdername1.Equals("4"))
        {
            //Debug.Log("Score :4");
            countScore1=countScore1+4;
        }
        else if(keepInOrdername1.Equals("5"))
        {
            //Debug.Log("Score :5");
            countScore1=countScore1+5;
        }
        
    }
}
