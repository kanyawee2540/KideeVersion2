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

    public Text starSpeaking;
    public Text starQueue;
    public Text starHelpOther;
    public Text starKeepInOrder;
  
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
    public Text scoreSpeakingBefore;
    public Text scoreSpeakingAfter;
    public Text scoreQueueBefore;
    public Text scoreQueueAfter;
    
    public Text scoreHelpOtherBefore;
    public Text scoreHelpOtherAfter;
    
    public Text scoreKeepInOrderBefore;
    public Text scoreKeepInOrderAfter;
    


    [Header("ObservationUI2")]
    public GameObject ImagesObservation2;
    public Text nameTextObservation2;

    
    public static int c;
    public int c2;
    public static int sumSpeaking=0;
    public static int sumQueue=0;
    public static int sumKeepInOrder=0;
    public static int sumHelpOther=0;

    public static string s;
    public static string inToHis;
    public static string Before;
    public static string After;
    public static string Before2;
    public static string After2;
    public static string Before3;
    public static string After3;
    public static string Before4;
    public static string After4;




    //กัน//
    public static int score,scoreIncorrect,fullScore;
     public double realScore;
     public static int history;
     public static string inHis,inToHiss,correctInHis,fullScoreInHis;

    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseApp.GetInstance("https://project-75a5c-default-rtdb.firebaseio.com/");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Showscore()
    {       
            sumSpeaking=0;
            sumQueue=0; 
            sumHelpOther=0; 
            sumKeepInOrder=0; 
            // print("reference :"+RemoveMember.keyList[buttonStarCount]);
            // print("LoginManager.localId :"+LoginManager.localId);
            s= ""+RemoveMember.keyList[buttonStarCount];
            
            //reference.Child(LoginManager.localId).Child(s).Child("ObservationScore").SetValueAsync(c);
           // Invoke("Data",2);
           
        FirebaseDatabase.DefaultInstance.GetReference(LoginManager.localId).GetValueAsync().ContinueWith(task => 
    {  
        DataSnapshot snapshot = task.Result;
        string No = snapshot.Child(s).Child("ObservationHistory").Value.ToString();
        print("No:"+No);
         history = Int32.Parse(No);
        history +=1;
        // inToHis = "History"+history;
        // print("inToHis:"+inToHis);
        Before = snapshot.Child(s).Child("ObservationScore").Child("History1").Child("Speaking").Value.ToString();
        Before2 = snapshot.Child(s).Child("ObservationScore").Child("History1").Child("Queue").Value.ToString();
        Before3 = snapshot.Child(s).Child("ObservationScore").Child("History1").Child("HelpOther").Value.ToString();
        Before4 = snapshot.Child(s).Child("ObservationScore").Child("History1").Child("KeepInOrder").Value.ToString();
        // print("Before play:"+Before);
        // scoreSpeakingBefore.text = Before;

        
        After = snapshot.Child(s).Child("ObservationScore").Child("History"+No).Child("Speaking").Value.ToString();
        After2 = snapshot.Child(s).Child("ObservationScore").Child("History"+No).Child("Queue").Value.ToString();
        After3 = snapshot.Child(s).Child("ObservationScore").Child("History"+No).Child("HelpOther").Value.ToString();
        After4 = snapshot.Child(s).Child("ObservationScore").Child("History"+No).Child("KeepInOrder").Value.ToString();
        
        // print("After play:"+After);
        // scoreSpeakingAfter.text = After;

        // fullScoreInHis = snapshot.Child(s).Child("keepInorderFullScore").Value.ToString();
        // fullScore = Int32.Parse(fullScoreInHis);
        // print("fullScore:"+fullScore);

        // //ก้อน score //
        // correctInHis = snapshot.Child(s).Child("KeepInorder").Child("History"+history).Child("Correct").Value.ToString();
        // score = Int32.Parse(correctInHis);
        // print("score:"+score);

        


        
    });

    }
    // public void ObservationText()
    // { 
    //     scoreSpeakingBefore.text = Before;
    //     scoreSpeakingAfter.text = After;

    public void ObservationScore()
    {       sumSpeaking=0;
            sumQueue=0; 
            sumHelpOther=0; 
            sumKeepInOrder=0;  
            sumSpeaking=Speakingtoggle1.countScore1+Speakingtoggle2.countScore2+Speakingtoggle3.countScore3+Speakingtoggle4.countScore;
            sumQueue=Queuetoggle1.countScore1+Queuetoggle2.countScore1;
            sumHelpOther=HelpOthertoggle1.countScore1+HelpOthertoggle2.countScore1;
            sumKeepInOrder=KeepInOrdertoggle1.countScore1+KeepInOrdertoggle2.countScore1; 
            
            // print("reference :"+RemoveMember.keyList[buttonStarCount]);
            // print("LoginManager.localId :"+LoginManager.localId);
            s= ""+RemoveMember.keyList[buttonStarCount];
            
            //reference.Child(LoginManager.localId).Child(s).Child("ObservationScore").SetValueAsync(c);
           // Invoke("Data",2);
           
        FirebaseDatabase.DefaultInstance.GetReference(LoginManager.localId).GetValueAsync().ContinueWith(task => 
    {  
        DataSnapshot snapshot = task.Result;
        string No = snapshot.Child(s).Child("ObservationHistory").Value.ToString();
        print("No:"+No);
        history = Int32.Parse(No);
        history +=1;
        inToHis = "History"+history;
        print("inToHis:"+inToHis);

        // if(history>=1)
        // {
            // Before = snapshot.Child(s).Child("ObservationScore").Child("History1").Child("Speaking").Value.ToString();
            // print("Before play:"+Before);
            // scoreSpeakingBefore.text = Before;

        // }

        reference.Child(LoginManager.localId).Child(s).Child("ObservationScore").Child(inToHis).Child("Speaking").SetValueAsync(sumSpeaking);
        reference.Child(LoginManager.localId).Child(s).Child("ObservationScore").Child(inToHis).Child("Queue").SetValueAsync(sumQueue);
        reference.Child(LoginManager.localId).Child(s).Child("ObservationScore").Child(inToHis).Child("HelpOther").SetValueAsync(sumHelpOther);
        reference.Child(LoginManager.localId).Child(s).Child("ObservationScore").Child(inToHis).Child("KeepInOrder").SetValueAsync(sumKeepInOrder);
        reference.Child(LoginManager.localId).Child(s).Child("ObservationHistory").SetValueAsync(history);


        // After = snapshot.Child(s).Child("ObservationScore").Child("inToHis").Child("Speaking").Value.ToString();
        // print("After play:"+After);
        // scoreSpeakingAfter.text = After;

        /*incorrectInHis = snapshot.Child(AddmemberManager.buttonKey).Child("Queue").Child(inToHis).Child("Incorrect").Value.ToString();*/

    });
    }





  
 public void OnClickedStar(Button button) //ดูว่ากดปุ่มดาวคนไหน 
    {
            string name = button.name;
            int i= Int32.Parse(name);
            buttonStarName=""+AddmemberManager.nameOnTable[i];
            buttonStarCount=i;
            print("buttonStarName "+buttonStarName);
            nameText.text="น้อง"+AddmemberManager.nameOnTable[i];
            nameTextQueue.text="น้อง"+AddmemberManager.nameOnTable[i];
            nameTextSpeaking.text="น้อง"+AddmemberManager.nameOnTable[i];
            nameTextHelpOther.text="น้อง"+AddmemberManager.nameOnTable[i];
            nameTextKeepInOrder.text="น้อง"+AddmemberManager.nameOnTable[i];

            
            



        // if(button.name=="StarBTN0"){
        //     buttonStarName=""+AddmemberManager.nameOnTable[0];
        //     buttonStarCount=0;
        //     print("buttonStarName "+buttonStarName);
        //     nameText.text="น้อง"+AddmemberManager.nameOnTable[0];
        //     nameTextQueue.text="น้อง"+AddmemberManager.nameOnTable[0];
        //     nameTextSpeaking.text="น้อง"+AddmemberManager.nameOnTable[0];
        //     nameTextHelpOther.text="น้อง"+AddmemberManager.nameOnTable[0];
        //     nameTextKeepInOrder.text="น้อง"+AddmemberManager.nameOnTable[0];
            


           
        // }
        // else if(button.name=="StarBTN1"){
        //     buttonStarName=""+AddmemberManager.nameOnTable[1];
        //     buttonStarCount=1;
        //     print("buttonStarName "+buttonStarName);
        //     nameText.text="น้อง"+AddmemberManager.nameOnTable[1];
        //     nameTextQueue.text="น้อง"+AddmemberManager.nameOnTable[1];
        //     nameTextSpeaking.text="น้อง"+AddmemberManager.nameOnTable[1];
        //     nameTextHelpOther.text="น้อง"+AddmemberManager.nameOnTable[1];
        //     nameTextKeepInOrder.text="น้อง"+AddmemberManager.nameOnTable[1];
           
           

        // }
        // else if(button.name=="StarBTN2"){
        //     buttonStarName=""+AddmemberManager.nameOnTable[2];
        //     buttonStarCount=2;
        //     print("buttonStarName "+buttonStarName);
        //     nameText.text="น้อง"+AddmemberManager.nameOnTable[2];
        //     nameTextQueue.text="น้อง"+AddmemberManager.nameOnTable[2];
        //     nameTextSpeaking.text="น้อง"+AddmemberManager.nameOnTable[2];
        //     nameTextHelpOther.text="น้อง"+AddmemberManager.nameOnTable[2];
        //     nameTextKeepInOrder.text="น้อง"+AddmemberManager.nameOnTable[2];
            
        // }
        // else if(button.name=="StarBTN3"){
        //     buttonStarName=""+AddmemberManager.nameOnTable[3];
        //     buttonStarCount=3;
        //     print("buttonStarName "+buttonStarName);
        //     nameText.text="น้อง"+AddmemberManager.nameOnTable[3];
        //     nameTextQueue.text="น้อง"+AddmemberManager.nameOnTable[3];
        //     nameTextSpeaking.text="น้อง"+AddmemberManager.nameOnTable[3];
        //     nameTextHelpOther.text="น้อง"+AddmemberManager.nameOnTable[3];
        //     nameTextKeepInOrder.text="น้อง"+AddmemberManager.nameOnTable[3];
            
           
        
        // }else if(button.name=="StarBTN4"){
        //     buttonStarName=""+AddmemberManager.nameOnTable[4];
        //     buttonStarCount=4;
        //     print("buttonStarName "+buttonStarName);
        //     nameText.text="น้อง"+AddmemberManager.nameOnTable[4];
        //     nameTextQueue.text="น้อง"+AddmemberManager.nameOnTable[4];
        //     nameTextSpeaking.text="น้อง"+AddmemberManager.nameOnTable[4];
        //     nameTextHelpOther.text="น้อง"+AddmemberManager.nameOnTable[4];
        //     nameTextKeepInOrder.text="น้อง"+AddmemberManager.nameOnTable[4];
            
        // }
        // else if(button.name=="StarBTN5"){
        //     buttonStarName=""+AddmemberManager.nameOnTable[5];
        //     buttonStarCount=5;
        //     print("buttonStarName "+buttonStarName);
        //     nameText.text="น้อง"+AddmemberManager.nameOnTable[5];
        //     nameTextQueue.text="น้อง"+AddmemberManager.nameOnTable[5];
        //     nameTextSpeaking.text="น้อง"+AddmemberManager.nameOnTable[5];
        //     nameTextHelpOther.text="น้อง"+AddmemberManager.nameOnTable[5];
        //     nameTextKeepInOrder.text="น้อง"+AddmemberManager.nameOnTable[5];
            
        
        // }
        // else if(button.name=="StarBTN6"){
        //     buttonStarName=""+AddmemberManager.nameOnTable[6];
        //     buttonStarCount=6;
        //     print("buttonStarName "+buttonStarName);
        //     nameText.text="น้อง"+AddmemberManager.nameOnTable[6];
        //     nameTextQueue.text="น้อง"+AddmemberManager.nameOnTable[6];
        //     nameTextSpeaking.text="น้อง"+AddmemberManager.nameOnTable[6];
        //     nameTextHelpOther.text="น้อง"+AddmemberManager.nameOnTable[6];
        //     nameTextKeepInOrder.text="น้อง"+AddmemberManager.nameOnTable[6];
           
        // }
        // else if(button.name=="StarBTN7"){
        //     buttonStarName=""+AddmemberManager.nameOnTable[7];
        //     buttonStarCount=7;
        //     print("buttonStarName "+buttonStarName);
        //     nameText.text="น้อง"+AddmemberManager.nameOnTable[7];
        //     nameTextQueue.text="น้อง"+AddmemberManager.nameOnTable[7];
        //     nameTextSpeaking.text="น้อง"+AddmemberManager.nameOnTable[7];
        //     nameTextHelpOther.text="น้อง"+AddmemberManager.nameOnTable[7];
        //     nameTextKeepInOrder.text="น้อง"+AddmemberManager.nameOnTable[7];
            
        // }
        // else if(button.name=="StarBTN8"){
        //     buttonStarName=""+AddmemberManager.nameOnTable[8];
        //     buttonStarCount=8;
        //     print("buttonStarName "+buttonStarName);
        //     nameText.text="น้อง"+AddmemberManager.nameOnTable[8];
        //     nameTextQueue.text="น้อง"+AddmemberManager.nameOnTable[8];
        //     nameTextSpeaking.text="น้อง"+AddmemberManager.nameOnTable[8];
        //     nameTextHelpOther.text="น้อง"+AddmemberManager.nameOnTable[8];
        //     nameTextKeepInOrder.text="น้อง"+AddmemberManager.nameOnTable[8];
            
        // }
        // else if(button.name=="StarBTN9"){
        //     buttonStarName=""+AddmemberManager.nameOnTable[9];
        //     buttonStarCount=9;
        //     print("buttonStarName "+buttonStarName);
        //     nameText.text="น้อง"+AddmemberManager.nameOnTable[9];
        //     nameTextQueue.text="น้อง"+AddmemberManager.nameOnTable[9];
        //     nameTextSpeaking.text="น้อง"+AddmemberManager.nameOnTable[9];
        //     nameTextHelpOther.text="น้อง"+AddmemberManager.nameOnTable[9];
        //     nameTextKeepInOrder.text="น้อง"+AddmemberManager.nameOnTable[9];
           
        // }

       Invoke("CheckImage",1);
   
    }

    public void OnClickedreport(Button button) //ดูว่ากดปุ่มดาวคนไหน 
    {
            string name = button.name;
            int i= Int32.Parse(name); 
            buttonStarName=""+AddmemberManager.nameOnTable[i];
            buttonStarCount=i;
            print("buttonStarName "+buttonStarName);
            nameTextObservation1.text="น้อง"+AddmemberManager.nameOnTable[i];
            nameTextObservation2.text="น้อง"+AddmemberManager.nameOnTable[i];

        
        // if(button.name=="reportBTN0"){
        //     buttonStarName=""+AddmemberManager.nameOnTable[0];
        //     buttonStarCount=0;
        //     print("buttonStarName "+buttonStarName);
        //     nameTextObservation1.text="น้อง"+AddmemberManager.nameOnTable[0];
        //     nameTextObservation2.text="น้อง"+AddmemberManager.nameOnTable[0];


           
        // }
        // else if(button.name=="reportBTN1"){
        //     buttonStarName=""+AddmemberManager.nameOnTable[1];
        //     buttonStarCount=1;
        //     print("buttonStarName "+buttonStarName);
        //     nameTextObservation1.text="น้อง"+AddmemberManager.nameOnTable[1];
        //     nameTextObservation2.text="น้อง"+AddmemberManager.nameOnTable[1];
           

        // }
        // else if(button.name=="reportBTN2"){
        //     buttonStarName=""+AddmemberManager.nameOnTable[2];
        //     buttonStarCount=2;
        //     print("buttonStarName "+buttonStarName);
        //     nameTextObservation1.text="น้อง"+AddmemberManager.nameOnTable[2];
        //     nameTextObservation2.text="น้อง"+AddmemberManager.nameOnTable[2];

        // }
        // else if(button.name=="reportBTN3"){
        //     buttonStarName=""+AddmemberManager.nameOnTable[3];
        //     buttonStarCount=3;
        //     print("buttonStarName "+buttonStarName);
        //     nameTextObservation1.text="น้อง"+AddmemberManager.nameOnTable[3];
        //     nameTextObservation2.text="น้อง"+AddmemberManager.nameOnTable[3];
           
        
        // }else if(button.name=="reportBTN4"){
        //     buttonStarName=""+AddmemberManager.nameOnTable[4];
        //     buttonStarCount=4;
        //     print("buttonStarName "+buttonStarName);
        //     nameTextObservation1.text="น้อง"+AddmemberManager.nameOnTable[4];
        //     nameTextObservation2.text="น้อง"+AddmemberManager.nameOnTable[4];

        // }
        // else if(button.name=="reportBTN5"){
        //     buttonStarName=""+AddmemberManager.nameOnTable[5];
        //     buttonStarCount=5;
        //     print("buttonStarName "+buttonStarName);
        //     nameTextObservation1.text="น้อง"+AddmemberManager.nameOnTable[5];
        //     nameTextObservation2.text="น้อง"+AddmemberManager.nameOnTable[5];
        
        // }
        // else if(button.name=="reportBTN6"){
        //     buttonStarName=""+AddmemberManager.nameOnTable[6];
        //     buttonStarCount=6;
        //     print("buttonStarName "+buttonStarName);
        //     nameTextObservation1.text="น้อง"+AddmemberManager.nameOnTable[6];
        //     nameTextObservation2.text="น้อง"+AddmemberManager.nameOnTable[6];
        // }
        // else if(button.name=="reportBTN7"){
        //     buttonStarName=""+AddmemberManager.nameOnTable[7];
        //     buttonStarCount=7;
        //     print("buttonStarName "+buttonStarName);
        //     nameTextObservation1.text="น้อง"+AddmemberManager.nameOnTable[7];
        //     nameTextObservation2.text="น้อง"+AddmemberManager.nameOnTable[7];
        // }
        // else if(button.name=="reportBTN8"){
        //     buttonStarName=""+AddmemberManager.nameOnTable[8];
        //     buttonStarCount=8;
        //     print("buttonStarName "+buttonStarName);
        //     nameTextObservation1.text="น้อง"+AddmemberManager.nameOnTable[8];
        //     nameTextObservation2.text="น้อง"+AddmemberManager.nameOnTable[8];
            
        // }
        // else if(button.name=="reportBTN9"){
        //     buttonStarName=""+AddmemberManager.nameOnTable[9];
        //     buttonStarCount=9;
        //     print("buttonStarName "+buttonStarName);
        //     nameTextObservation1.text="น้อง"+AddmemberManager.nameOnTable[9];
        //     nameTextObservation2.text="น้อง"+AddmemberManager.nameOnTable[9];
        // }

       Invoke("CheckImage",1);
   
    }

     public void CheckImage() 
    {
        
        c=Int32.Parse(""+AddmemberManager.picList[buttonStarCount]);
        for(int i=0;i<AddmemberManager.picList.Count;i++){
        print("picList "+i+" "+AddmemberManager.picList[i]);
        
        }
        print("c:"+c);
        // print("Before play:"+Before);
        scoreSpeakingBefore.text = Before;
        scoreQueueBefore.text = Before2;
        scoreHelpOtherBefore.text = Before3;
        scoreKeepInOrderBefore.text = Before4;
        // print("After play:"+After);
        scoreSpeakingAfter.text = After;
        scoreQueueAfter.text = After2;
        scoreHelpOtherAfter.text = After3;
        scoreKeepInOrderAfter.text = After4;
        print("After:"+After +" "+After2 +" "+After3 +" "+After4);

        if(history-1==0)
        {
            scoreSpeakingBefore.text = "";
            scoreQueueBefore.text = "";
            scoreHelpOtherBefore.text="";
            scoreKeepInOrderBefore.text="";
            scoreSpeakingAfter.text = "";
            scoreQueueAfter.text = "";
            scoreHelpOtherAfter.text = "";
            scoreKeepInOrderAfter.text = "";
            
        }
        if(history-1==1)
        {
            scoreSpeakingAfter.text = "";
            scoreQueueAfter.text = "";
            scoreHelpOtherAfter.text = "";
            scoreKeepInOrderAfter.text = "";
        }

        // Star
        starSpeaking.text=""+GetMax.maxStarSpeaking;
        starHelpOther.text=""+GetMax.maxStarHelpOther;
        starKeepInOrder.text=""+GetMax.maxStarkeepInorder;
        starQueue.text=""+GetMax.maxStarQueue;
        //print("maxStarSpeaking "+GetMax.maxStarSpeaking);

        if(c==1)

        {
            Images.GetComponent<Image>().sprite=sprite1;
            ImagesSpeaking.GetComponent<Image>().sprite=sprite1;
            ImagesQueue.GetComponent<Image>().sprite=sprite1;
            ImagesHelpOther.GetComponent<Image>().sprite=sprite1;
            ImagesKeepInOrder.GetComponent<Image>().sprite=sprite1;
            ImagesObservation1.GetComponent<Image>().sprite=sprite1;
            ImagesObservation2.GetComponent<Image>().sprite=sprite1;

           // print("CheckPasswordImage "+c);
        }
        else  if(c==2)
        {
            Images.GetComponent<Image>().sprite=sprite2;
            ImagesSpeaking.GetComponent<Image>().sprite=sprite2;
            ImagesQueue.GetComponent<Image>().sprite=sprite2;
            ImagesHelpOther.GetComponent<Image>().sprite=sprite2;
            ImagesKeepInOrder.GetComponent<Image>().sprite=sprite2;
            ImagesObservation1.GetComponent<Image>().sprite=sprite2;
            ImagesObservation2.GetComponent<Image>().sprite=sprite2;

            //("CheckPasswordImage "+c);
        }
        else  if(c==3)
        {
            Images.GetComponent<Image>().sprite=sprite3;
            ImagesSpeaking.GetComponent<Image>().sprite=sprite3;
            ImagesQueue.GetComponent<Image>().sprite=sprite3;
            ImagesHelpOther.GetComponent<Image>().sprite=sprite3;
            ImagesKeepInOrder.GetComponent<Image>().sprite=sprite3;
            ImagesObservation1.GetComponent<Image>().sprite=sprite3;
            ImagesObservation2.GetComponent<Image>().sprite=sprite3;

            //print("CheckPasswordImage "+c);
        }
         else  if(c==4)
        {
            Images.GetComponent<Image>().sprite=sprite4;
            ImagesSpeaking.GetComponent<Image>().sprite=sprite4;
            ImagesQueue.GetComponent<Image>().sprite=sprite4;
            ImagesHelpOther.GetComponent<Image>().sprite=sprite4;
            ImagesKeepInOrder.GetComponent<Image>().sprite=sprite4;
            ImagesObservation1.GetComponent<Image>().sprite=sprite4;
            ImagesObservation2.GetComponent<Image>().sprite=sprite4;

        }  
        else  if(c==5)
        {
            Images.GetComponent<Image>().sprite=sprite5;
            ImagesSpeaking.GetComponent<Image>().sprite=sprite5;
            ImagesQueue.GetComponent<Image>().sprite=sprite5;
            ImagesHelpOther.GetComponent<Image>().sprite=sprite5;
            ImagesKeepInOrder.GetComponent<Image>().sprite=sprite5;
            ImagesObservation1.GetComponent<Image>().sprite=sprite5;
            ImagesObservation2.GetComponent<Image>().sprite=sprite5;


        }
        else  if(c==6)
        {
            Images.GetComponent<Image>().sprite=sprite6;
            ImagesSpeaking.GetComponent<Image>().sprite=sprite6;
            ImagesQueue.GetComponent<Image>().sprite=sprite6;
            ImagesHelpOther.GetComponent<Image>().sprite=sprite6;
            ImagesKeepInOrder.GetComponent<Image>().sprite=sprite6;
            ImagesObservation1.GetComponent<Image>().sprite=sprite6;
            ImagesObservation2.GetComponent<Image>().sprite=sprite6;

        }
        else  if(c==7)
        {
            Images.GetComponent<Image>().sprite=sprite7;
            ImagesSpeaking.GetComponent<Image>().sprite=sprite7;
            ImagesQueue.GetComponent<Image>().sprite=sprite7;
            ImagesHelpOther.GetComponent<Image>().sprite=sprite7;
            ImagesKeepInOrder.GetComponent<Image>().sprite=sprite7;
            ImagesObservation1.GetComponent<Image>().sprite=sprite7;
            ImagesObservation2.GetComponent<Image>().sprite=sprite7;

        }
        else  if(c==8)
        {
            Images.GetComponent<Image>().sprite=sprite8;
            ImagesSpeaking.GetComponent<Image>().sprite=sprite8;
            ImagesQueue.GetComponent<Image>().sprite=sprite8;
            ImagesHelpOther.GetComponent<Image>().sprite=sprite8;
            ImagesKeepInOrder.GetComponent<Image>().sprite=sprite8;
            ImagesObservation1.GetComponent<Image>().sprite=sprite8;
            ImagesObservation2.GetComponent<Image>().sprite=sprite8;

        }
        else  if(c==9)
        {
            Images.GetComponent<Image>().sprite=sprite9;
            ImagesSpeaking.GetComponent<Image>().sprite=sprite9;
            ImagesQueue.GetComponent<Image>().sprite=sprite9;
            ImagesHelpOther.GetComponent<Image>().sprite=sprite9;
            ImagesKeepInOrder.GetComponent<Image>().sprite=sprite9;
            ImagesObservation1.GetComponent<Image>().sprite=sprite9;
            ImagesObservation2.GetComponent<Image>().sprite=sprite9;

        }
        
     
    }
    



   
}
