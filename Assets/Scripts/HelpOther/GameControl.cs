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


public class GameControl : MonoBehaviour
{ 
    /*กันลอง*/
    public string databaseURL = "https://project-75a5c-default-rtdb.firebaseio.com/"; 
    private DatabaseReference reference;
     public static int countHis;
     public int score,scoreIncorrect;
     public int showscore;
     public static int history;
     public static string s;
     public static string member;
     public static string day,time;
     public Text m_MyText;
    
    [SerializeField]
    public GameObject winText1;
    public GameObject winText2;
    public GameObject winText3;


    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    
     public static int scoreInHis;
     public static int fullScore=0;
     public static double realScore;
     public static string memberurl,fullScoreInHis,correctInHis,No;
    public Text m_score;

    public int SaveStar;
    public int star;


    // Start is called before the first frame update
    void Start()
    {
         winText1.SetActive(false);
         winText2.SetActive(false);
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);

        reference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseApp.GetInstance("https://project-75a5c-default-rtdb.firebaseio.com/");
        
        FirebaseDatabase.DefaultInstance.GetReference(LoginManager.localId).GetValueAsync().ContinueWith(task => 
    {  
        DataSnapshot snapshot = task.Result;
        s = snapshot.Child(AddmemberManager.buttonKey).Child("helpOtherHistory").Value.ToString();
        history = Int32.Parse(s);
        history +=1;

    });  
    }
    

    // Update is called once per frame
    void Update()
    {
        if(DragCarrot1.locked&&DragCarrot2.locked && DragCarrot3.locked && DragCarrot4.locked && DragCarrot5.locked){
            /*ถ้าไม่ทำการจับมา false เลขคะแนนจะรันไปเรื่อยๆ*/
            DragCarrot1.locked = false;
            DragCarrot2.locked = false;
            DragCarrot3.locked = false;
            DragCarrot4.locked = false;
            DragCarrot5.locked = false;
            correct();
            saveinEnd();
            winText2.SetActive(true);

        }
        if(hamburger.locked && watermalon.locked && unicon.locked && tomato.locked){
            hamburger.locked = false;
            watermalon.locked = false;
            unicon.locked = false;
            tomato.locked = false;
            winText1.SetActive(true);
            correct();
            saveinEnd();

        }
        if(trash.locked && trash2.locked && trash3.locked && trash4.locked && trash5.locked&& trash6.locked){
            trash.locked = false;
            trash2.locked = false;
            trash3.locked = false;
            trash4.locked = false;
            trash5.locked = false;
            trash6.locked = false;
            winText3.SetActive(true);
            correct();
            saveinEnd();
        }
        
    }
    public void correct(){
        print("-------------in correct------------");
        score += 1;
        print("score is "+score);

        //print("fullscore is "+fullscore);
        double scoreStar= ((double)score/(double)6)*100;
        print("scoreStar is "+scoreStar);
        
        if(scoreStar>60){
            star=3;
            print("Star 3");
            
        }else if(scoreStar<=60 && scoreStar>40){
            star=2;
            print("Star 2");
            
        }else if(scoreStar<=40 && scoreStar>=1){
            star=1;
            print("Star 1");
            
        }else{
            star=0;
            print("Star 0");
           
        }

        //Check star in Max
          if(star>GetMax.maxStarHelpOther){
            SaveStar=star;
            print("SaveStar"+SaveStar+" GetStarForMember.maxStarHelpOther "+GetStarForMember.maxStarHelpOther);
            
        }else if(star<=GetMax.maxStarHelpOther){
            SaveStar=GetMax.maxStarHelpOther;
             print("SaveStar"+SaveStar+" GetStarForMember.maxStarHelpOther "+GetStarForMember.maxStarHelpOther);
            
        }


    }
    public void incorrect(){
        scoreIncorrect += 1;
        print("scoreIncorrect is "+scoreIncorrect);
    }
    public void save(){
        day = System.DateTime.Now.ToString("yyyy/MM/dd"); 
        DateTime now = DateTime.Now;
        string time = now.ToString("T");
        string His = "History"+history;
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("helpOtherHistory").SetValueAsync(history);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("HelpOther").Child(His).Child("Date").SetValueAsync(day);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("HelpOther").Child(His).Child("Time").SetValueAsync(time);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("HelpOther").Child(His).Child("Correct").SetValueAsync(score);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("HelpOther").Child(His).Child("Incorrect").SetValueAsync(scoreIncorrect);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("HelpOther").Child(His).Child("Star").SetValueAsync(star);
        goToMenu();
    }
        public void saveinEnd(){
        day = System.DateTime.Now.ToString("yyyy/MM/dd"); 
        DateTime now = DateTime.Now;
        string time = now.ToString("T");
        string His = "History"+history;
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("helpOtherHistory").SetValueAsync(history);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("HelpOther").Child(His).Child("Date").SetValueAsync(day);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("HelpOther").Child(His).Child("Time").SetValueAsync(time);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("HelpOther").Child(His).Child("Correct").SetValueAsync(score);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("HelpOther").Child(His).Child("Incorrect").SetValueAsync(scoreIncorrect);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("HelpOther").Child(His).Child("Star").SetValueAsync(star);
            //push star in Max
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("starHelpOther").SetValueAsync(SaveStar);
    Showscore();
    showStar();
    }
    public void goToMenu(){
        SceneManager.LoadScene("ChooseManu");
    }
    public void Exit(){     //ออกโดยยังไม่ได้เล่น
    
        day = System.DateTime.Now.ToString("yyyy/MM/dd"); 
        DateTime now = DateTime.Now;
        string time = now.ToString("T");
        string His = "History"+history;
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("helpOtherHistory").SetValueAsync(history);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("HelpOther").Child(His).Child("Date").SetValueAsync(day);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("HelpOther").Child(His).Child("Time").SetValueAsync(time);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("HelpOther").Child(His).Child("Correct").SetValueAsync(score);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("HelpOther").Child(His).Child("Incorrect").SetValueAsync(scoreIncorrect);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("HelpOther").Child(His).Child("Star").SetValueAsync(star);
        Showscore();
        showStar();
    
    }
        public void showStar(){
        print("----------in showStar---------");
        print("in His "+No);
        print("----------------Score in helpOther is "+scoreInHis);
        print("full score in helpOther is "+fullScore);
        realScore = Math.Round(((double)scoreInHis/(double)fullScore)*100, 2);
        print("real score is "+realScore);
        if(star==3){
            print("incase >60");
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
            m_score.text = "3 ดาว";
        }else if(star==2){
            print("incase <=60");
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(false);
            m_score.text = "2 ดาว";
        }else if(star==1){
            print("incase <=40");
            star1.SetActive(true);
            star2.SetActive(false);
            star3.SetActive(false);
            m_score.text = "1 ดาว";
        }else{
            print("incase other (mean 0)");
            star1.SetActive(false);
            star2.SetActive(false);
            star3.SetActive(false);
            m_score.text = "0 ดาว";
        }

}
      public void Showscore()
      
    {   
                print("----------in showscore---------");  
          memberurl = AddmemberManager.memberURL1;
           
        FirebaseDatabase.DefaultInstance.GetReference(LoginManager.localId).GetValueAsync().ContinueWith(task => 
    {  
        DataSnapshot snapshot = task.Result;
        No = snapshot.Child(memberurl).Child("helpOtherHistory").Value.ToString();
        print("No:"+No);
         history = Int32.Parse(No);

        fullScoreInHis = snapshot.Child(memberurl).Child("helpOtherFullScore").Value.ToString();
        fullScore = Int32.Parse(fullScoreInHis);
        print("fullScore:"+fullScore);

        //ก้อน score //
        correctInHis = snapshot.Child(memberurl).Child("HelpOther").Child("History"+No).Child("Correct").Value.ToString();
        scoreInHis = Int32.Parse(correctInHis);
        print("score:"+scoreInHis);
        


        
    });
    }
}
