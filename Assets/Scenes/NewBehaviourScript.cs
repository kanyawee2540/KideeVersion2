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


public class NewBehaviourScript : MonoBehaviour
{ 
    public string databaseURL = "https://project-75a5c-default-rtdb.firebaseio.com/"; 
    private DatabaseReference reference;
     public static int countHis;
          public static int history,testHis;
     public static int fullScore,score,his;
     public static double realScore;
     public static string s,memberurl,fullScoreInHis,correctInHis,currentScore;
     public static int getControlHis;
     public static string member,inToHis,inToHis2;
     public static string day,time;
    
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject nostar1;
    public GameObject nostar2;
    public GameObject nostar3;
    public Text m_score,m_fullScore,m_realScore,m_history;

    // Start is called before the first frame update
    void Start()
    {
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        nostar1.SetActive(false);
        nostar2.SetActive(false);
        nostar3.SetActive(false);

        memberurl = AddmemberManager.memberURL1;
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseApp.GetInstance("https://project-75a5c-default-rtdb.firebaseio.com/");
        
        FirebaseDatabase.DefaultInstance.GetReference(LoginManager.localId).GetValueAsync().ContinueWith(task => 
    {  
        DataSnapshot snapshot = task.Result;
        currentScore = snapshot.Child(memberurl).Child("KeepInorder").Child("CurrentScore").Value.ToString();
        history = Int32.Parse(s);

    });
    }
    

    // Update is called once per frame
    void Update()
    {
    
    }
    public void showStar(){
        print("current score "+currentScore);
        if(realScore>60){
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }else if(realScore<=60 && realScore>40){
            star1.SetActive(true);
            star2.SetActive(true);
            nostar3.SetActive(true);
        }else if(realScore<=40 && realScore>=1){
            star1.SetActive(true);
            nostar2.SetActive(true);
            nostar3.SetActive(true);
        }else{
            nostar1.SetActive(true);
            nostar2.SetActive(true);
            nostar3.SetActive(true);
        }
        


    }
}
