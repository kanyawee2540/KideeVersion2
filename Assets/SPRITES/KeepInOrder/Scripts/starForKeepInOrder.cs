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

public class starForKeepInOrder : MonoBehaviour
{
    public string databaseURL = "https://project-75a5c-default-rtdb.firebaseio.com/"; 
    private DatabaseReference reference;
    public static int countHis;
     public int score,scoreIncorrect,fullScore;
     public double realScore;
     public static int history;
     public static string s,inToHis,correctInHis,fullScoreInHis;



    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject nostar1;
    public GameObject nostar2;
    public GameObject nostar3;
    public Text m_score,m_fullScore,m_realScore,m_history;
    void Start()
    {
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        nostar1.SetActive(false);
        nostar2.SetActive(false);
        nostar3.SetActive(false);
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseApp.GetInstance("https://project-75a5c-default-rtdb.firebaseio.com/");
        
        FirebaseDatabase.DefaultInstance.GetReference(LoginManager.localId).GetValueAsync().ContinueWith(task => 
    {  
        DataSnapshot snapshot = task.Result;
        s = snapshot.Child(AddmemberManager.buttonKey).Child("keepInorderHistory").Value.ToString();
        history = Int32.Parse(s);
        history +=1;
        inToHis = "History"+history;
        
        //ก้อน full score//
        fullScoreInHis = snapshot.Child(AddmemberManager.buttonKey).Child("keepInorderFullScore").Value.ToString();
        fullScore = Int32.Parse(fullScoreInHis);

        //ก้อน score //
        correctInHis = snapshot.Child(AddmemberManager.buttonKey).Child("KeepInorder").Child(inToHis).Child("Correct").Value.ToString();
        score = Int32.Parse(correctInHis);


        

    });  
    }
    public void showStar(){
        print("score "+score);
        print("full "+fullScore);
        realScore = ((double)score/(double)fullScore)*100;
        print("real "+realScore);
        m_score.text = "score is "+score;
        m_fullScore.text = "full score is "+fullScore;
        m_realScore.text = "realScore score is "+realScore;
        m_history.text = "in history "+history;
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
        public void goToMenu(){
        SceneManager.LoadScene("ChooseManu");
    }
}