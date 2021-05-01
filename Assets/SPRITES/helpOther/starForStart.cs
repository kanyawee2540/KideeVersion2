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

public class starForStart : MonoBehaviour
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
        //สิ่งที่ยังไม่ได้ทำคือการนำคะแนน realscore ไปใส่ใน firebase และอัพเดททุกครั้งเมื่อมีคะแนนที่มากกว่า เพื่อเอาไปใส่สมุดสะสมดาว(ที่เด็กดู)
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
        s = snapshot.Child(AddmemberManager.buttonKey).Child("helpOtherHistory").Value.ToString();
        history = Int32.Parse(s);
        history +=1;
        inToHis = "History"+history;
        correctInHis = snapshot.Child(AddmemberManager.buttonKey).Child("HelpOther").Child(inToHis).Child("Correct").Value.ToString();
        fullScoreInHis = snapshot.Child(AddmemberManager.buttonKey).Child("helpOtherFullScore").Value.ToString();
        /*incorrectInHis = snapshot.Child(AddmemberManager.buttonKey).Child("Queue").Child(inToHis).Child("Incorrect").Value.ToString();*/
        score = Int32.Parse(correctInHis);
        fullScore = Int32.Parse(fullScoreInHis);
        /*scoreIncorrect = Int32.Parse(incorrectInHis);*/
        
        
        /*m_MyText2.text = "scoreincorrect is "+scoreIncorrect;
        m_MyText3.text = "inhistory "+history;*/

    });  
    }
    public void showStar(){
        print("score "+score);
        print("full "+fullScore);
        realScore = ((double)score/(double)fullScore)*100;
        print("real "+realScore);
        
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
        

        m_score.text = "score is "+score;
        m_fullScore.text = "full score is "+fullScore;
        m_realScore.text = "realScore score is "+realScore;
        m_history.text = "in history "+history;
    }
        public void goToMenu(){
        SceneManager.LoadScene("ChooseManu");
    }
    
    /*
    public string databaseURL = "https://project-75a5c-default-rtdb.firebaseio.com/"; 
    private DatabaseReference reference;
     public static int countHis;
     public int score,scoreIncorrect;
     public static int history;
     public static string s,inToHis,correctInHis,incorrectInHis;
     public static string member;
     public static string day,time;
    public GameObject questionUIQ1;
    public GameObject correctUIQ1;
    
    
    public Text m_MyText;
    public Text m_MyText2;
        public Text m_MyText3;
    //public GameObject inCorrectUI;
    // Start is called before the first frame update
    void Start()
    {
        questionUIQ1.SetActive(true);
        correctUIQ1.SetActive(false);
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseApp.GetInstance("https://project-75a5c-default-rtdb.firebaseio.com/");
        
        FirebaseDatabase.DefaultInstance.GetReference(LoginManager.localId).GetValueAsync().ContinueWith(task => 
    {  
        DataSnapshot snapshot = task.Result;
        s = snapshot.Child(AddmemberManager.buttonKey).Child("queueHistory").Value.ToString();
        inToHis = "History"+s;
        correctInHis = snapshot.Child(AddmemberManager.buttonKey).Child("Queue").Child(inToHis).Child("Correct").Value.ToString();
        incorrectInHis = snapshot.Child(AddmemberManager.buttonKey).Child("Queue").Child(inToHis).Child("Incorrect").Value.ToString();
        score = Int32.Parse(correctInHis);
        scoreIncorrect = Int32.Parse(incorrectInHis);
        history = Int32.Parse(s);
        m_MyText.text = "score is "+score;
        m_MyText2.text = "scoreincorrect is "+scoreIncorrect;
        m_MyText3.text = "inhistory "+history;

    });  
    }

    // Update is called once per frame
    void Update()
    {
        if (Q3DragS3.locked)
        {
            questionUIQ1.SetActive(false);
            correctUIQ1.SetActive(true);
            Q3DragS3.locked = false;
            score += 1;
            saveinTheEnd();
        }
        if (Q3DragS1.locked || Q3DragS2.locked || Q3DragS4.locked)
        {
            /*correctUIQ1.SetActive(false);
            incorrectUIQ1.SetActive(true);
            Q3DragS1.locked = false;
            Q3DragS2.locked = false;
            Q3DragS4.locked = false;
            scoreIncorrect += 1;
            saveinTheEnd();
            GotoinCorrectUI();
            /*GotoinCorrectUI();
            

        }

    }
    public void goToQ4()
    {
        SceneManager.LoadScene("Q4");
    }
    public void tryQ3Again()
    {
        SceneManager.LoadScene("Q3");
        m_MyText.text = "scoreincorrect1 is "+scoreIncorrect;
    }
    public void GotoinCorrectUI()
    {
        SceneManager.LoadScene("Q3Incorrect"); 
    }
    public void correct(){
        score += 1;
        print("score is "+score);
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
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("queueHistory").SetValueAsync(history);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("Queue").Child(His).Child("Date").SetValueAsync(day);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("Queue").Child(His).Child("Time").SetValueAsync(time);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("Queue").Child(His).Child("Correct").SetValueAsync(score);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("Queue").Child(His).Child("Incorrect").SetValueAsync(scoreIncorrect);
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
    }*/
}
