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
using UnityEngine.EventSystems;
public class showStarInChooseMenu : MonoBehaviour
{public string databaseURL = "https://project-75a5c-default-rtdb.firebaseio.com/"; 
    private DatabaseReference reference;
    // public static int countHis;
    //  public int score,scoreIncorrect,fullScore;
    public double keepInorderRealScore;
    public double SpeakingRealScore;
    //  public static int history;
    //  public static string s,inToHis,correctInHis,fullScoreInHis;
      public int c,sum,showHelpOther,showkeepInorder,showQueue,showSpeaking;
      public static string memberurl,speak,queue,help,keep;
      public static int HelpOther,keepInorder,Queue,Speaking;
      public int starS,starQ,starH,starK;



    public GameObject starSpeaking1;
    public GameObject starSpeaking2;
    public GameObject starSpeaking3;
    public GameObject starQueue1;
    public GameObject starQueue2;
    public GameObject starQueue3;
     public GameObject starHelpOther1;
    public GameObject starHelpOther2;
    public GameObject starHelpOther3;
     public GameObject starKeepInOrder1;
    public GameObject starKeepInOrder2;
    public GameObject starKeepInOrder3;
    public Text sumStar;
    void Start()
    {
            
        starSpeaking1.SetActive(false);
        starSpeaking2.SetActive(false);
        starSpeaking3.SetActive(false);
        starQueue1.SetActive(false);
        starQueue2.SetActive(false);
        starQueue3.SetActive(false);
        starHelpOther1.SetActive(false);
        starHelpOther2.SetActive(false);
        starHelpOther3.SetActive(false);
        starKeepInOrder1.SetActive(false);
        starKeepInOrder2.SetActive(false);
        starKeepInOrder3.SetActive(false);
  
           /*         print("speak "+showSpeaking);
        print("queue "+showQueue);
        print("help "+showHelpOther);
        print("keep "+showkeepInorder);*/
        getStar();
    }
    void Update()
    {
       // 
       //Star();
    }

    public void getStar(){
                memberurl = AddmemberManager.memberURL1;

                reference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseApp.GetInstance("https://project-75a5c-default-rtdb.firebaseio.com/");
        
        FirebaseDatabase.DefaultInstance.GetReference(LoginManager.localId).GetValueAsync().ContinueWith(task => 
    {  
        DataSnapshot snapshot = task.Result;
        speak = snapshot.Child(memberurl).Child("starSpeaking").Value.ToString();
        queue = snapshot.Child(memberurl).Child("starQueue").Value.ToString();
        help = snapshot.Child(memberurl).Child("starHelpOther").Value.ToString();
        keep = snapshot.Child(memberurl).Child("starKeepInorder").Value.ToString();
        keepInorder =  Int32.Parse(keep);
        showkeepInorder = keepInorder;
        Speaking = Int32.Parse(speak);
        showSpeaking = Speaking;
        HelpOther = Int32.Parse(help);
        showHelpOther = HelpOther;
        Queue= Int32.Parse(queue);
       showQueue = Queue;
        print("In get-----------");
        print("speak "+showSpeaking);
        print("queue "+showQueue);
        print("help "+showHelpOther);
        print("keep "+showkeepInorder);
        applyToStar();
        showStar();
    

    });
    }
    public void applyToStar(){
        print("in cal ----------- ");
        print("show speak "+Speaking);
        if(Speaking==3){
            starS = 3;
        }
    }

    public void showStar(){
        /*        int showkeepInorder = keepInorder;
        int showSpeaking = Speaking;
        int showHelpOther = HelpOther;
        int showQueue= Queue;*/
                print("In show-----------");
                print("star s "+starS);
        /*print("speak "+showSpeaking);
        print("queue "+showQueue);
        print("help "+showHelpOther);
        print("keep "+showkeepInorder);*/
        if(starS==3){
            print("star3");                //star Speaking
            starSpeaking1.SetActive(true);
            starSpeaking2.SetActive(true);
            starSpeaking3.SetActive(true);
        }




         /*   if(showSpeaking==3){  

            print("star3");                //star Speaking
            starSpeaking1.SetActive(true);
            starSpeaking2.SetActive(true);
            starSpeaking3.SetActive(true);

        }/*else if(showSpeaking==2){
            starSpeaking1.SetActive(true);
            starSpeaking2.SetActive(true);
            starSpeaking3.SetActive(false);
             print("star2");
            //nostar3.SetActive(true);
        }else if(showSpeaking==1){
            starSpeaking1.SetActive(true);
            starSpeaking2.SetActive(false);
            starSpeaking3.SetActive(false);
             print("star1");
            //nostar2.SetActive(true);
            //nostar3.SetActive(true);
        }else{
            starSpeaking1.SetActive(false);
            starSpeaking2.SetActive(false);
            starSpeaking3.SetActive(false);
             print("star0");
            //nostar1.SetActive(true);
            //nostar2.SetActive(true);
            //nostar3.SetActive(true);
        }

        if(showkeepInorder==3){                      //star KeepInOrder
            starKeepInOrder1.SetActive(true);
            starKeepInOrder2.SetActive(true);
            starKeepInOrder3.SetActive(true);
            print("star3");
        }else if(showkeepInorder==2){
            starKeepInOrder1.SetActive(true);
            starKeepInOrder2.SetActive(true);
            starKeepInOrder3.SetActive(false);
             print("star2");
            //nostar3.SetActive(true);
        }else if(showkeepInorder==1){
            starKeepInOrder1.SetActive(true);
            starKeepInOrder2.SetActive(false);
            starKeepInOrder3.SetActive(false);
             print("star1");
            //nostar2.SetActive(true);
            //nostar3.SetActive(true);
        }else{
            starKeepInOrder1.SetActive(false);
            starKeepInOrder2.SetActive(false);
            starKeepInOrder3.SetActive(false);
             print("star0");
            //nostar1.SetActive(true);
            //nostar2.SetActive(true);
            //nostar3.SetActive(true);
        }

        if(showHelpOther==3){                      //star HelpOther
            starHelpOther1.SetActive(true);
            starHelpOther2.SetActive(true);
            starHelpOther3.SetActive(true);
            print("star3");
        }else if(showHelpOther==2){
            starHelpOther1.SetActive(true);
            starHelpOther2.SetActive(true);
            starHelpOther3.SetActive(false);
             print("star2");
            //nostar3.SetActive(true);
        }else if(showHelpOther==1){
            starHelpOther1.SetActive(true);
            starHelpOther2.SetActive(false);
            starHelpOther3.SetActive(false);
             print("star1");
            //nostar2.SetActive(true);
            //nostar3.SetActive(true);
        }else{
            starHelpOther1.SetActive(false);
            starHelpOther2.SetActive(false);
            starHelpOther3.SetActive(false);
             print("star0");
            //nostar1.SetActive(true);
            //nostar2.SetActive(true);
            //nostar3.SetActive(true);
        }

        if(showQueue==3){                     //star Queue
            starQueue1.SetActive(true);
            starQueue2.SetActive(true);
            starQueue3.SetActive(true);
            print("star3");
        }else if(showQueue==2){
            starQueue1.SetActive(true);
            starQueue2.SetActive(true);
            starQueue3.SetActive(false);
             print("star2");
            //nostar3.SetActive(true);
        }else if(showQueue==1){
            starQueue1.SetActive(true);
            starQueue2.SetActive(false);
            starQueue3.SetActive(false);
             print("star1");
            //nostar2.SetActive(true);
            //nostar3.SetActive(true);
        }else{
            starQueue1.SetActive(false);
            starQueue2.SetActive(false);
            starQueue3.SetActive(false);
             print("star0");
            //nostar1.SetActive(true);
            //nostar2.SetActive(true);
            //nostar3.SetActive(true);
        }*/
        sum = showSpeaking+showQueue+showHelpOther+showkeepInorder;
        print("Sum is "+sum);
        sumStar.text = " "+sum;
    }
}
