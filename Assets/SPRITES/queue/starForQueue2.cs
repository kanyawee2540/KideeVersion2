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

public class starForQueue2 : MonoBehaviour
{

    public string databaseURL = "https://project-75a5c-default-rtdb.firebaseio.com/"; 
    private DatabaseReference reference;
     public static int countHis;
     public int score,scoreIncorrect;
     public int showscore;
     public static int history;
     public static string s;
     public static string member;
     public static string day,time;
    
    [SerializeField]
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    
     public static int scoreInHis;
     public static int fullScore=0;
     public static double realScore;
     public static string memberurl,fullScoreInHis,correctInHis,No;
    public Text m_score,m_star;

    public int SaveStar;
    public int star;
    // Start is called before the first frame update
    void Start()
    {
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseApp.GetInstance("https://project-75a5c-default-rtdb.firebaseio.com/");
        
        FirebaseDatabase.DefaultInstance.GetReference(LoginManager.localId).GetValueAsync().ContinueWith(task => 
    {  
        DataSnapshot snapshot = task.Result;
        s = snapshot.Child(AddmemberManager.buttonKey).Child("queueHistory").Value.ToString();
        history = Int32.Parse(s);

    });  
    }

    // Update is called once per frame
    void Update()
    {

    }
        public void save(){
        day = System.DateTime.Now.ToString("yyyy/MM/dd"); 
        DateTime now = DateTime.Now;
        string time = now.ToString("T");
        string His = "History"+history;
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("queueHistory").SetValueAsync(history);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("Queue").Child(His).Child("Date").SetValueAsync(day);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("Queue").Child(His).Child("Time").SetValueAsync(time);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("Queue").Child(His).Child("Correct").SetValueAsync(score);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("Queue").Child(His).Child("Incorrect").SetValueAsync(scoreIncorrect);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("Queue").Child(His).Child("Star").SetValueAsync(star);
        goToMenu();
    }
        public void saveinEnd(){
        day = System.DateTime.Now.ToString("yyyy/MM/dd"); 
        DateTime now = DateTime.Now;
        string time = now.ToString("T");
        string His = "History"+history;
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("queueHistory").SetValueAsync(history);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("Queue").Child(His).Child("Date").SetValueAsync(day);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("Queue").Child(His).Child("Time").SetValueAsync(time);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("Queue").Child(His).Child("Correct").SetValueAsync(score);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("Queue").Child(His).Child("Incorrect").SetValueAsync(scoreIncorrect);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("Queue").Child(His).Child("Star").SetValueAsync(star);
            //push star in Max
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("starQueue").SetValueAsync(SaveStar);
    Showscore();
    /*showStar();*/
    }
    public void goToMenu(){
        SceneManager.LoadScene("ChooseManu");
    }
    public void Exit(){     //ออกโดยยังไม่ได้เล่น
    
        day = System.DateTime.Now.ToString("yyyy/MM/dd"); 
        DateTime now = DateTime.Now;
        string time = now.ToString("T");
        string His = "History"+history;
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("queueHistory").SetValueAsync(history);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("Queue").Child(His).Child("Date").SetValueAsync(day);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("Queue").Child(His).Child("Time").SetValueAsync(time);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("Queue").Child(His).Child("Correct").SetValueAsync(score);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("Queue").Child(His).Child("Incorrect").SetValueAsync(scoreIncorrect);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("Queue").Child(His).Child("Star").SetValueAsync(star);
        Showscore();
        showStar();
    
    }      
    public void Showscore()
      
    {   
                print("----------in showscore---------");  
          memberurl = AddmemberManager.memberURL1;
           
        FirebaseDatabase.DefaultInstance.GetReference(LoginManager.localId).GetValueAsync().ContinueWith(task => 
    {  
        DataSnapshot snapshot = task.Result;
        No = snapshot.Child(memberurl).Child("queueHistory").Value.ToString();
        print("No:"+No);
        history = Int32.Parse(No);

        fullScoreInHis = snapshot.Child(memberurl).Child("queueFullScore").Value.ToString();
        fullScore = Int32.Parse(fullScoreInHis);
        print("fullScore:"+fullScore);

        //ก้อน score //
        correctInHis = snapshot.Child(memberurl).Child("Queue").Child("History"+No).Child("Correct").Value.ToString();
        scoreInHis = Int32.Parse(correctInHis);
        print("score:"+scoreInHis);
        
        realScore = Math.Round(((double)scoreInHis/(double)fullScore)*100, 2);
        print("real score is "+realScore);
        if(realScore>60){
            print("incase >60");
            star =3;
        }else if(realScore<=60 && realScore>40){
            print("incase <=60");
            star =2;
        }else if(realScore<=40 && realScore >1){
            print("incase <=40");
            star =1;
        }else{
            print("incase other (mean 0)");
            star =0 ;
        }

        
    });
    
    }
    public void showStar(){
        print("star in queue this game is = "+star);
        if(star==3){
            print("incase >60");
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
            m_star.text = "3 ดาว";
            m_score.text = "คะแนนที่ได้คือ "+realScore+"/"+"100";
        }else if(star==2){
            print("incase <=60");
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(false);
            m_star.text = "2 ดาว";
            m_score.text = "คะแนนที่ได้คือ "+realScore+"/"+"100";
        }else if(star==1){
            print("incase <=40");
            star1.SetActive(true);
            star2.SetActive(false);
            star3.SetActive(false);
            m_star.text = "1 ดาว";
            m_score.text = "คะแนนที่ได้คือ "+realScore+"/"+"100";
        }else{
            print("incase other (mean 0)");
            star1.SetActive(false);
            star2.SetActive(false);
            star3.SetActive(false);
            m_star.text = "0 ดาว";
            m_score.text = "คะแนนที่ได้คือ "+realScore+"/"+"100";
        }

}


}
