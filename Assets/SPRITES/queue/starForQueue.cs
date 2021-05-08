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

public class starForQueue : MonoBehaviour
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
     public static int fullScore=0,starInHis;
     public static double realScore;
     public static string memberurl,fullScoreInHis,correctInHis,No,starInHistory;
    public Text score_text,star_text,fullScore_text,scoreInHis_text,realScore_text,starr_text,His_text,starinShowStar,starInShowScore;

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
        history +=1;

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
        /*reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("Queue").Child(His).Child("Correct").SetValueAsync(score);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("Queue").Child(His).Child("Incorrect").SetValueAsync(scoreIncorrect);*/
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("Queue").Child(His).Child("Star").SetValueAsync(star);
        goToMenu();
    }
    public void goToMenu(){
        SceneManager.LoadScene("ChooseManu");
    }
        public void saveinTheEnd(){
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
    
    }
    public void ExitHaveScore(){     //ออกโดยยังไม่ได้เล่น
        Showscore();
    
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

        starInHistory = snapshot.Child(memberurl).Child("starQueue").Value.ToString();
        starInHis = Int32.Parse(starInHistory);
        print("star in his "+starInHis);
        
        print("----------in showStar---------");
        print("in His "+No);
        print("----------------Score in queue is "+scoreInHis);
        print("full score in helpOther is "+fullScore);
        realScore = Math.Round(((double)scoreInHis/(double)fullScore)*100, 2);
        print("real score is "+realScore);

            if(realScore>60){
            star=3;
            print("Star 3");
            
        }else if(realScore<=60 && realScore>40){
            star=2;
            print("Star 2");
            
        }else if(realScore<=40 && realScore>=1){
            star=1;
            print("Star 1");
            
        }else{
            star=0;
            print("Star 0");
           
        }
        His_text.text = "in history "+No;
        scoreInHis_text.text = "score is "+scoreInHis;
        fullScore_text.text = "full score is "+fullScore;
        realScore_text.text = "real score is "+realScore;
        starInShowScore.text = "star is "+star;        
        if(star>starInHis){
            reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("starQueue").SetValueAsync(star);
        }
                if(star==3){
            print("incase >60");
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
            star_text.text = "3 ดาว";
        }else if(star==2){
            print("incase <=60");
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(false);
            star_text.text = "2 ดาว";
        }else if(star==1){
            print("incase <=40");
            star1.SetActive(true);
            star2.SetActive(false);
            star3.SetActive(false);
            star_text.text = "1 ดาว";
        }else{
            print("incase other (mean 0)");
            star1.SetActive(false);
            star2.SetActive(false);
            star3.SetActive(false);
            star_text.text = "0 ดาว";
        }

    });
    }
    


}
