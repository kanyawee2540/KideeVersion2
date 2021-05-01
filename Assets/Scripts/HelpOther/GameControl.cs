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


    // Start is called before the first frame update
    void Start()
    {
         winText1.SetActive(false);
         winText2.SetActive(false);

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
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("helpOtherHistory").SetValueAsync(history);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("HelpOther").Child(His).Child("Date").SetValueAsync(day);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("HelpOther").Child(His).Child("Time").SetValueAsync(time);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("HelpOther").Child(His).Child("Correct").SetValueAsync(score);
        reference.Child(LoginManager.localId).Child(AddmemberManager.buttonKey).Child("HelpOther").Child(His).Child("Incorrect").SetValueAsync(scoreIncorrect);
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
    }
    public void goToMenu(){
        SceneManager.LoadScene("ChooseManu");
    }
}
