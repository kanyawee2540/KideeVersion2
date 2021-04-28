using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;


public class InputFiledActivate : MonoBehaviour
{
    // Start is called before the first frame update
    
    [Header("Add member box")]
    public InputField mainInputField;
    public InputField mainInputField2;
    public InputField mainInputField3;
    public InputField mainInputField4;
    // public InputField InputField;


   public InputField filed1;
   public InputField filed2;
   public InputField filed3;
   public InputField filed4;

    public string s1;
    public string s2;
    public string s3;


    // Activate the main input field when the Scene starts.
    void Start()
    {
        //mainInputField.ActivateInputField();
             

        
    }
     void Update () 
     {
     
       
       
    }
    // public void InputField1()
    // {
    // InputField.ActivateInputField();

    // }
    public void AddmemberBox()
    {
                mainInputField.ActivateInputField();

    }

  

    public void Filed1(){
        s1 = filed1.text;
        if(s1.Length==1)
        {
                mainInputField2.ActivateInputField();
                //s1=""; 
                
              
        }
       
    }
     public void Filed2(){
        s2 = filed2.text;
        if(s2.Length==1)
        {
                mainInputField3.ActivateInputField();
                //s2=""; 
                
              
        }
       
    }
     public void Filed3(){
        s3 = filed1.text;
        if(s3.Length==1)
        {
                mainInputField4.ActivateInputField();
               // s3=""; 
                
              
        }
       
    }

   
}