using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;


public class IputFiledActivate2 : MonoBehaviour
{
    // Start is called before the first frame update
    
    [Header("CheckPasswordMember box")]
 
    public InputField inputField;
    public InputField inputField2;
    public InputField inputField3;
    public InputField inputField4;

    public InputField cpfiled1;
   public InputField cpfiled2;
   public InputField cpfiled3;
   public InputField cpfiled4;

    public string s4;
    public string s5;
    public string s6;
    void Start()
    {
        inputField.ActivateInputField();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
        public void CheckPasswordMemberbox()
    {
              
    }

       public void Filed4(){
        s4 = cpfiled1.text;
        if(s4.Length==1)
        {
                inputField2.ActivateInputField();
                //s1=""; 
                
              
        }
       
    }
     public void Filed5(){
        s5 = cpfiled2.text;
        if(s5.Length==1)
        {
                inputField3.ActivateInputField();
                //s2=""; 
                
              
        }
       
    }
     public void Filed6(){
        s6 = cpfiled3.text;
        if(s6.Length==1)
        {
                inputField4.ActivateInputField();
               // s3=""; 
                
              
        }
       
    }
}
