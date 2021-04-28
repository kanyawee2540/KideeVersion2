using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DropdownUser : MonoBehaviour
{
    public GameObject UserUI;
    public GameObject AddUI;
    // Start is called before the first frame update
    public void HandleInput(int val){
        if(val==0)
        {
        UserUI.SetActive(true);
        AddUI.SetActive(false);
        }
        if(val==1)
        {
            // SceneManager.LoadScene("Addmember");
        }
        if(val==2)
        {
        UserUI.SetActive(false);
        AddUI.SetActive(true);
        }


    }
    public void OnClickAddMember(){
     UserUI.SetActive(false);
        AddUI.SetActive(true);

    }
     public void OnClickLogOut(){
         SceneManager.LoadScene("Login");

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
