using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;
using UnityEngine.SceneManagement;
using System;
using System.Linq;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using Object = UnityEngine.Object;

public class StarCollection : MonoBehaviour
{


    
    public static int count;
    public static string name;
    private DatabaseReference reference;
    public string buttonStarName;
    public static int buttonStarCount;

    [Header("UserData")]
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;
    public Sprite sprite6;
    public Sprite sprite7;
    public Sprite sprite8;
    public Sprite sprite9;
    [Header("StarUI")]
    public GameObject Images;
    
    public Text nameText;
  
    [Header("SpeakingStarUI")]
    public GameObject ImagesSpeaking;
    public Text nameTextSpeaking;
    [Header("QueueStarUI")]
    public GameObject ImagesQueue;
    public Text nameTextQueue;
    // Start is called before the first frame update
    void Start()
    {
       
         //passwordList2 =AddmemberManager.nameList3;
         
        //print(passwordList2[1]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Star()
    {        
    

    }
    
 public void OnClickedStar(Button button) //ดูว่ากดปุ่มดาวคนไหน 
    {
        
        if(button.name=="StarBTN0"){
            buttonStarName=""+AddmemberManager.nameOnTable[0];
            buttonStarCount=0;
            print("buttonStarName "+buttonStarName);
            nameText.text="น้อง"+AddmemberManager.nameOnTable[0];
            nameTextQueue.text="น้อง"+AddmemberManager.nameOnTable[0];
            nameTextSpeaking.text="น้อง"+AddmemberManager.nameOnTable[0];
           
        }else if(button.name=="StarBTN1"){
            buttonStarName=""+AddmemberManager.nameOnTable[1];
            buttonStarCount=1;
            print("buttonStarName "+buttonStarName);
            nameText.text="น้อง"+AddmemberManager.nameOnTable[1];
            nameTextQueue.text="น้อง"+AddmemberManager.nameOnTable[1];
            nameTextSpeaking.text="น้อง"+AddmemberManager.nameOnTable[1];
           

        }else if(button.name=="StarBTN2"){
              buttonStarName=""+AddmemberManager.nameOnTable[2];
                print("buttonStarName "+buttonStarName);

        }else if(button.name=="StarBTN3"){
              buttonStarName=""+AddmemberManager.nameOnTable[3];
           
        }else if(button.name=="StarBTN4"){
              buttonStarName=""+AddmemberManager.nameOnTable[4];
           
        }
       Invoke("CheckImage",1);
   
    }

     public void CheckImage() 
    {
        
         int c=Int32.Parse(""+AddmemberManager.picList[buttonStarCount]);
        print("c:"+c);
        if(c==1)

        {
            Images.GetComponent<Image>().sprite=sprite1;
            ImagesSpeaking.GetComponent<Image>().sprite=sprite1;
            ImagesQueue.GetComponent<Image>().sprite=sprite1;

           // print("CheckPasswordImage "+c);
        }
        else  if(c==2)
        {
            Images.GetComponent<Image>().sprite=sprite2;
            ImagesSpeaking.GetComponent<Image>().sprite=sprite2;
            ImagesQueue.GetComponent<Image>().sprite=sprite2;
            //("CheckPasswordImage "+c);
        }
        else  if(c==3)
        {
            Images.GetComponent<Image>().sprite=sprite3;
            ImagesSpeaking.GetComponent<Image>().sprite=sprite3;
            ImagesQueue.GetComponent<Image>().sprite=sprite3;
            //print("CheckPasswordImage "+c);
        }
         else  if(c==4)
        {
            Images.GetComponent<Image>().sprite=sprite4;
            ImagesSpeaking.GetComponent<Image>().sprite=sprite4;
            ImagesQueue.GetComponent<Image>().sprite=sprite4;
        }
        else  if(c==5)
        {
            Images.GetComponent<Image>().sprite=sprite5;
            ImagesSpeaking.GetComponent<Image>().sprite=sprite5;
            ImagesQueue.GetComponent<Image>().sprite=sprite5;
        }
        else  if(c==6)
        {
            Images.GetComponent<Image>().sprite=sprite6;
            ImagesSpeaking.GetComponent<Image>().sprite=sprite6;
            ImagesQueue.GetComponent<Image>().sprite=sprite6;
        }
        else  if(c==7)
        {
            Images.GetComponent<Image>().sprite=sprite7;
            ImagesSpeaking.GetComponent<Image>().sprite=sprite7;
            ImagesQueue.GetComponent<Image>().sprite=sprite7;
        }
        else  if(c==8)
        {
            Images.GetComponent<Image>().sprite=sprite8;
            ImagesSpeaking.GetComponent<Image>().sprite=sprite8;
            ImagesQueue.GetComponent<Image>().sprite=sprite8;
        }
        else  if(c==9)
        {
            Images.GetComponent<Image>().sprite=sprite9;
            ImagesSpeaking.GetComponent<Image>().sprite=sprite9;
            ImagesQueue.GetComponent<Image>().sprite=sprite9;
        }
        
     
    }

    

   
}
