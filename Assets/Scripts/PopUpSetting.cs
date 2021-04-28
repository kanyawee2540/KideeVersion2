using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpSetting : MonoBehaviour
{

    public GameObject Popup;
     public GameObject User;
 
    public bool pop;
   
void OnMouseDown(){
        Popup.SetActive(pop);

        }
        
   
}
 
   

