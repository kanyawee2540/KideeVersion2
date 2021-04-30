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


    public string databaseURL = "https://project-75a5c-default-rtdb.firebaseio.com/"; 
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

    [Header("HelpOtherStarUI")]
    public GameObject ImagesHelpOther;
    public Text nameTextHelpOther;

    [Header("KeepInOrderStarUI")]
    public GameObject ImagesKeepInOrder;
    public Text nameTextKeepInOrder;

    [Header("ObservationUI1")]
    public GameObject ImagesObservation1;
    public Text nameTextObservation1;

    [Header("ObservationUI2")]
    public GameObject ImagesObservation2;
    public Text nameTextObservation2;

    
    // Start is called before the first frame update
    public int c;
    public int c2;
    public static int sumObservationScore=0;
    string s;

    void Start()
    {
          reference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseApp.GetInstance("https://project-75a5c-default-rtdb.firebaseio.com/");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ObservationScore()
    {     // sumObservationScore=0; 
           sumObservationScore=Speakingtoggle1.countScore1+Speakingtoggle2.countScore2+Speakingtoggle3.countScore3+Speakingtoggle4.countScore
                                +Queuetoggle1.countScore1+Queuetoggle2.countScore1+HelpOthertoggle1.countScore1+HelpOthertoggle2.countScore1
                                +KeepInOrdertoggle1.countScore1+KeepInOrdertoggle2.countScore1; 
            print("Sum Score :"+sumObservationScore);
            c2 =sumObservationScore;
            print("reference :"+RemoveMember.keyList[buttonStarCount]);
             print("LoginManager.localId :"+LoginManager.localId);
            s= ""+RemoveMember.keyList[buttonStarCount];
            //reference.Child(LoginManager.localId).Child(s).Child("ObservationScore").SetValueAsync(c);
           // Invoke("Data",2);
           

    }

     public void Data()
    {
            reference.Child(LoginManager.localId).Child(s).Child("ObservationScore").SetValueAsync(c2);

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
            nameTextHelpOther.text="น้อง"+AddmemberManager.nameOnTable[0];
            nameTextKeepInOrder.text="น้อง"+AddmemberManager.nameOnTable[0];

           
        }
        else if(button.name=="StarBTN1"){
            buttonStarName=""+AddmemberManager.nameOnTable[1];
            buttonStarCount=1;
            print("buttonStarName "+buttonStarName);
            nameText.text="น้อง"+AddmemberManager.nameOnTable[1];
            nameTextQueue.text="น้อง"+AddmemberManager.nameOnTable[1];
            nameTextSpeaking.text="น้อง"+AddmemberManager.nameOnTable[1];
            nameTextHelpOther.text="น้อง"+AddmemberManager.nameOnTable[1];
            nameTextKeepInOrder.text="น้อง"+AddmemberManager.nameOnTable[1];
           

        }
        else if(button.name=="StarBTN2"){
            buttonStarName=""+AddmemberManager.nameOnTable[2];
            buttonStarCount=2;
            print("buttonStarName "+buttonStarName);
            nameText.text="น้อง"+AddmemberManager.nameOnTable[2];
            nameTextQueue.text="น้อง"+AddmemberManager.nameOnTable[2];
            nameTextSpeaking.text="น้อง"+AddmemberManager.nameOnTable[2];
            nameTextHelpOther.text="น้อง"+AddmemberManager.nameOnTable[2];
            nameTextKeepInOrder.text="น้อง"+AddmemberManager.nameOnTable[2];

        }
        else if(button.name=="StarBTN3"){
            buttonStarName=""+AddmemberManager.nameOnTable[3];
            buttonStarCount=3;
            print("buttonStarName "+buttonStarName);
            nameText.text="น้อง"+AddmemberManager.nameOnTable[3];
            nameTextQueue.text="น้อง"+AddmemberManager.nameOnTable[3];
            nameTextSpeaking.text="น้อง"+AddmemberManager.nameOnTable[3];
            nameTextHelpOther.text="น้อง"+AddmemberManager.nameOnTable[3];
            nameTextKeepInOrder.text="น้อง"+AddmemberManager.nameOnTable[3];
           
        
        }else if(button.name=="StarBTN4"){
            buttonStarName=""+AddmemberManager.nameOnTable[4];
            buttonStarCount=4;
            print("buttonStarName "+buttonStarName);
            nameText.text="น้อง"+AddmemberManager.nameOnTable[4];
            nameTextQueue.text="น้อง"+AddmemberManager.nameOnTable[4];
            nameTextSpeaking.text="น้อง"+AddmemberManager.nameOnTable[4];
            nameTextHelpOther.text="น้อง"+AddmemberManager.nameOnTable[4];
            nameTextKeepInOrder.text="น้อง"+AddmemberManager.nameOnTable[4];

        }
        else if(button.name=="StarBTN5"){
            buttonStarName=""+AddmemberManager.nameOnTable[5];
            buttonStarCount=5;
            print("buttonStarName "+buttonStarName);
            nameText.text="น้อง"+AddmemberManager.nameOnTable[5];
            nameTextQueue.text="น้อง"+AddmemberManager.nameOnTable[5];
            nameTextSpeaking.text="น้อง"+AddmemberManager.nameOnTable[5];
            nameTextHelpOther.text="น้อง"+AddmemberManager.nameOnTable[5];
            nameTextKeepInOrder.text="น้อง"+AddmemberManager.nameOnTable[5];
        
        }
        else if(button.name=="StarBTN6"){
            buttonStarName=""+AddmemberManager.nameOnTable[6];
            buttonStarCount=6;
            print("buttonStarName "+buttonStarName);
            nameText.text="น้อง"+AddmemberManager.nameOnTable[6];
            nameTextQueue.text="น้อง"+AddmemberManager.nameOnTable[6];
            nameTextSpeaking.text="น้อง"+AddmemberManager.nameOnTable[6];
            nameTextHelpOther.text="น้อง"+AddmemberManager.nameOnTable[6];
            nameTextKeepInOrder.text="น้อง"+AddmemberManager.nameOnTable[6];
        }
        else if(button.name=="StarBTN7"){
            buttonStarName=""+AddmemberManager.nameOnTable[7];
            buttonStarCount=7;
            print("buttonStarName "+buttonStarName);
            nameText.text="น้อง"+AddmemberManager.nameOnTable[7];
            nameTextQueue.text="น้อง"+AddmemberManager.nameOnTable[7];
            nameTextSpeaking.text="น้อง"+AddmemberManager.nameOnTable[7];
            nameTextHelpOther.text="น้อง"+AddmemberManager.nameOnTable[7];
            nameTextKeepInOrder.text="น้อง"+AddmemberManager.nameOnTable[7];
        }
        else if(button.name=="StarBTN8"){
            buttonStarName=""+AddmemberManager.nameOnTable[8];
            buttonStarCount=8;
            print("buttonStarName "+buttonStarName);
            nameText.text="น้อง"+AddmemberManager.nameOnTable[8];
            nameTextQueue.text="น้อง"+AddmemberManager.nameOnTable[8];
            nameTextSpeaking.text="น้อง"+AddmemberManager.nameOnTable[8];
            nameTextHelpOther.text="น้อง"+AddmemberManager.nameOnTable[8];
            nameTextKeepInOrder.text="น้อง"+AddmemberManager.nameOnTable[8];
        }
        else if(button.name=="StarBTN9"){
            buttonStarName=""+AddmemberManager.nameOnTable[9];
            buttonStarCount=9;
            print("buttonStarName "+buttonStarName);
            nameText.text="น้อง"+AddmemberManager.nameOnTable[9];
            nameTextQueue.text="น้อง"+AddmemberManager.nameOnTable[9];
            nameTextSpeaking.text="น้อง"+AddmemberManager.nameOnTable[9];
            nameTextHelpOther.text="น้อง"+AddmemberManager.nameOnTable[9];
            nameTextKeepInOrder.text="น้อง"+AddmemberManager.nameOnTable[9];
        }

       Invoke("CheckImage",1);
   
    }

     public void CheckImage() 
    {
        
        c=Int32.Parse(""+AddmemberManager.picList[buttonStarCount]);
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

    public void OnClickedS(Button button) //ดูว่ากดปุ่มดาวคนไหน 
    {
         if(button.name=="reportBTN0"){
            buttonStarName=""+AddmemberManager.nameOnTable[0];
            buttonStarCount=0;
            print("buttonStarName "+buttonStarName);
            // nameText.text="น้อง"+AddmemberManager.nameOnTable[0];
            // nameTextQueue.text="น้อง"+AddmemberManager.nameOnTable[0];
            // nameTextSpeaking.text="น้อง"+AddmemberManager.nameOnTable[0];
            // nameTextHelpOther.text="น้อง"+AddmemberManager.nameOnTable[0];
            // nameTextKeepInOrder.text="น้อง"+AddmemberManager.nameOnTable[0];

           
        }
    }

    

   
}
