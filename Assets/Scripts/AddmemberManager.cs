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
using Firebase.Auth;


// using UnityEngine.object;
public class AddmemberManager : MonoBehaviour
{

      [Header("Remove Button")] //ลบเเล้วเอาปุ่มซ่อน
    public GameObject remove0;
     public GameObject remove1;  
     public GameObject remove2;
     public GameObject remove3;
     public GameObject remove4;  
     public GameObject remove5;
     public GameObject remove6;
     public GameObject remove7;  
     public GameObject remove8;
     public GameObject remove9;  
     public GameObject remove10;
     

    
    [Header("Box")] //เอาไว้ปิดกล่อง
    public GameObject passwordAddmemberbox;
    public GameObject passwordRemovememberbox;
    public GameObject passwordLogoutbox;
    public GameObject Addmemberbox;

    [Header("Addmember")]
    public InputField nameField;
    public InputField passwordField1;
    public InputField passwordField2;
    public InputField passwordField3;
    public InputField passwordField4;
    public Text test;
     [Header("check password member")]
    public InputField checkPasswordField1;
    public InputField checkPasswordField2;
    public InputField checkPasswordField3;
    public InputField checkPasswordField4;
    public string p;

    [Header("check password user")]
    public InputField passwordAddField;
    public InputField passwordRemoveField;
    public InputField passwordLogoutField;

    public static string nameMember;
    public static string passwordMember;
    
    public static ArrayList nameList = new ArrayList();
    public static ArrayList nameList2 = new ArrayList();
    public static ArrayList nameList3 = new ArrayList();
    //public static ArrayList nameIncheckList = new ArrayList();

    public static ArrayList passwordList = new ArrayList();
    public static ArrayList picList = new ArrayList();
    public static ArrayList picList2 = new ArrayList();
    public static ArrayList nameIncheckList = new ArrayList();
    public static ArrayList keykListEditUI = new ArrayList();
    
    public static ArrayList nameOnTable = new ArrayList();


    ArrayList keyList = new ArrayList();

    public static int count;
    public string passwordUser;
    public static string buttonKey;
    public int buttonName; //ดูว่ากดปุ๋มลบไหน
    public static int buttonNameMember; //ดูว่ากดปุ๋มไหน

    public static int gender;
    public static string name;


    [SerializeField]
    private Button[] buttons;
    private Button[] remove;
    private DatabaseReference reference;
    
    [Header("Profile pic")]
    public GameObject[] Images;
    
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;
    public Sprite sprite6;
    public Sprite sprite7;
    public Sprite sprite8;
     public Sprite sprite9;
    public GameObject checkPasswordImage; 
    public Text checkPasswordName;

    [Header("Add Remove Success")]
    public GameObject AddSuccessUI; 
    public GameObject RemoveSuccessUI; 
        public string databaseURL = "https://project-75a5c-default-rtdb.firebaseio.com/"; 
        public static string memberURL;
        public static string memberName;

        [Header("Star")]
        public Text nameText;
        private string display = "";
         [SerializeField]
        private Button[] reportBtn;
         [SerializeField]
        private Button[] starBtn;
        public string buttonStarName;

        public static string userEmail;
        private FirebaseAuth auth;
    private void Awake()
    {

    
    }
    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseApp.GetInstance("https://project-75a5c-default-rtdb.firebaseio.com/");
        
         FirebaseDatabase.DefaultInstance.GetReference(LoginManager.localId).GetValueAsync().ContinueWith(task => 
    {  
        DataSnapshot snapshot = task.Result;
        passwordUser = snapshot.Child("User").Child("password").Value.ToString();
        string s = snapshot.Child("User").Child("gender").Value.ToString();
        gender=Int32.Parse(s);
        string s2 = snapshot.Child("User").Child("userName").Value.ToString();
        userEmail = snapshot.Child("User").Child("userEmail").Value.ToString();
        name=s2;
    });  
        
        GetCount();
        //print(count+"Start");
        Invoke("AddButtons", 3); 
        nameList.Clear();
        picList.Clear();

         // AddButtons();
        FirebaseDatabase.DefaultInstance.GetReference(LoginManager.localId) 
       // หากข้อมูลมีการเปลี่ยนแหลงให้ทำการอ่านและแสดง
       .ValueChanged += HandleValueChanged;

         for(int i = 0 ; i < nameList.Count; i++){
         print("nameList "+i+" "+nameList[i]);

    }
    }
 void Update()
    {
        GetCount();
       // mainInputField2.Select();
    }
    

    public void LogoutUser()
    {
         SceneManager.LoadScene("Login");
    }
      public void StarCollections()
    {
         SceneManager.LoadScene("StarCollection");
    }

    public void SaveAndRetrieveData() //from the database (server)...
    {
    //store the data to the server...
    
    //Retrieve the data and convert it to string...
         FirebaseDatabase.DefaultInstance.GetReference(LoginManager.localId).GetValueAsync().ContinueWith(task => 
    {  
        DataSnapshot snapshot = task.Result;
        string ss = snapshot.Child("m_count").Value.ToString();
       // print(ss);
       // print(ss+"SaveAndRetrieveData");
        count=Int32.Parse(ss);
    });  
}
  public int GetCount() 
    {
    
         FirebaseDatabase.DefaultInstance.GetReference(LoginManager.localId).GetValueAsync().ContinueWith(task => 
    {  
        DataSnapshot snapshot = task.Result;
        string ss = snapshot.Child("m_count").Value.ToString();
       // print(ss);
        //print(ss+" GetCount");
        // string s = snapshot.Child("User").Child("gender").Value.ToString();
        // gender=Int32.Parse(s);
        // print("s "+s);
       
        count=Int32.Parse(ss);

    });  
    return count;
}
   
    public void OnSubmit()
    { 
    nameOnTable.Clear();
    nameMember = nameField.text;
    passwordMember = passwordField1.text+""+passwordField2.text+""+passwordField3.text+""+passwordField4.text;
    WriteAllData();
   // test.text = "Post Data ";
    count++;
    reference.Child(LoginManager.localId).Child("m_count").SetValueAsync(count);
    
      //StartCoroutine("Wait");
      //AddButtons2();
     Invoke("AddButtons2", 2); 
     //dddddd();
       //SaveAndRetrieveData() ;
    }


    public void AddButtons(){
        nameText.text ="";
    //     for(int i = 0 ; i < nameList.Count; i++){
    //      print("nameList "+i+" "+nameList[i]);

    // }
        //display="";
       
     //StartCoroutine("Wait");
       for(int i=0;i<count;i++){
        buttons[i].gameObject.SetActive(true); 
        buttons[i].GetComponentInChildren<Text>().text = ""+nameList[i]; //****** i member name ?
       
        
       display = display.ToString () + nameList[i].ToString() + "\n"; //table star
       nameText.text =display;
        reportBtn[i].gameObject.SetActive(true); 
        starBtn[i].gameObject.SetActive(true); 


        //print("pic list : "+picList[i]);
        int c=Int32.Parse(""+picList[i]);
        if(c==1)

        {
            Images[i].GetComponent<Image>().sprite=sprite1;
        }
        else  if(c==2)
        {
            Images[i].GetComponent<Image>().sprite=sprite2;
        }
        else  if(c==3)
        {
            Images[i].GetComponent<Image>().sprite=sprite3;
        }
         else  if(c==4)
        {
            Images[i].GetComponent<Image>().sprite=sprite4;
        }
        else  if(c==5)
        {
           Images[i].GetComponent<Image>().sprite=sprite5;
        }
        else  if(c==6)
        {
            Images[i].GetComponent<Image>().sprite=sprite6;
        }
        else  if(c==7)
        {
            Images[i].GetComponent<Image>().sprite=sprite7;
        }
        else  if(c==8)
        {
            Images[i].GetComponent<Image>().sprite=sprite8;
        }
        else  if(c==9)
        {
            Images[i].GetComponent<Image>().sprite=sprite9;
        }
        
       }
      
        
    }
   public void AddButtons2(){
       nameText.text ="";
       //nameOnTable.Add(nameList2[nameList2.Count-1]);
        for(int i=0;i<nameOnTable.Count;i++){
        print("nameOnTable AddButtons2  : "+i+nameOnTable[i]);
        reportBtn[i].gameObject.SetActive(true); 
        starBtn[i].gameObject.SetActive(true); 
        }
        //display="";
     //   StartCoroutine("Wait");
         // Wait();
        //print("AddButtons2 "+count);
        
        display = display.ToString () + nameList2[nameList2.Count-1].ToString() + "\n"; //table star
        nameText.text =display;
        
       for(int i=0;i<nameList2.Count;i++){
        
        buttons[count-1].gameObject.SetActive(true); 
        buttons[count-1].GetComponentInChildren<Text>().text = ""+nameList2[i]; //****** i member name ?


        int c=Int32.Parse(""+picList2[i]);
        if(c==1)

        {
            Images[count-1].GetComponent<Image>().sprite=sprite1;
        }
        else  if(c==2)
        {
            Images[count-1].GetComponent<Image>().sprite=sprite2;
        }
        else  if(c==3)
        {
            Images[count-1].GetComponent<Image>().sprite=sprite3;
        }
         else  if(c==4)
        {
            Images[count-1].GetComponent<Image>().sprite=sprite4;
        }
         else  if(c==5)
        {
          Images[count-1].GetComponent<Image>().sprite=sprite5;
        }
        else  if(c==6)
        {
            Images[count-1].GetComponent<Image>().sprite=sprite6;
        }
        else  if(c==7)
        {
            Images[count-1].GetComponent<Image>().sprite=sprite7;
        }
        else  if(c==8)
        {
            Images[count-1].GetComponent<Image>().sprite=sprite8;
        }
        else  if(c==9)
        {
            Images[count-1].GetComponent<Image>().sprite=sprite9;
        }
       }
    //    for(int i=0;i<picList.Count;i++){
    //      print("picList "+i+picList[i]);
    //     }

        // Display();
    }
 public void ChangeButtons(){
        display="";
        nameText.text ="";

    // StartCoroutine("Wait");
       
        for(int i=0;i<nameOnTable.Count;i++){
             print("nameOnTable ChangeButtons  : "+i+nameOnTable[i]);
        // reportBtn[i].gameObject.SetActive(true); 
        // starBtn[i].gameObject.SetActive(true); 

        display = display.ToString () + nameOnTable[i].ToString() + "\n"; //table star
        nameText.text =display;
 
        reportBtn[i].gameObject.SetActive(true); 
        starBtn[i].gameObject.SetActive(true); 
        //print("i "+i);
       
        }

         for(int i=0;i<GetCount();i++){
        buttons[i].gameObject.SetActive(true); 
        buttons[i].GetComponentInChildren<Text>().text = ""+nameList3[i]; //****** i member name ?
          
       int c=Int32.Parse(""+picList[i]);
        if(c==1)

        {
            Images[i].GetComponent<Image>().sprite=sprite1;
        }
        else  if(c==2)
        {
            Images[i].GetComponent<Image>().sprite=sprite2;
        }
        else  if(c==3)
        {
            Images[i].GetComponent<Image>().sprite=sprite3;
        }
         else  if(c==4)
        {
            Images[i].GetComponent<Image>().sprite=sprite4;
        }
        else  if(c==5)
        {
           Images[i].GetComponent<Image>().sprite=sprite5;
        }
        else  if(c==6)
        {
            Images[i].GetComponent<Image>().sprite=sprite6;
        }
        else  if(c==7)
        {
            Images[i].GetComponent<Image>().sprite=sprite7;
        }
        else  if(c==8)
        {
            Images[i].GetComponent<Image>().sprite=sprite8;
        }
        else  if(c==9)
        {
            Images[i].GetComponent<Image>().sprite=sprite9;
        }
       }

       
     
    }
      public void Display(){
             nameText.text ="";
          foreach (string human in nameList) 
          {
            display = display.ToString () + human.ToString() + "\n";
         }
         nameText.text = display;
        // print("display "+display);
         
    }
     public void Remove()
     {
        //     nameList.Clear();
        //  RaadAllData();
        nameList3.RemoveAt(buttonName);
        passwordList.RemoveAt(buttonName);
        picList.RemoveAt(buttonName);
        // for(int i=0;i<picList.Count;i++){
        //  print("picList "+i+picList[i]);
        // }
        nameIncheckList.RemoveAt(buttonName);
        nameOnTable.RemoveAt(buttonName);
        
       
        for(int i=0;i<GetCount();i++){
        buttons[i].gameObject.SetActive(false); 
        reportBtn[i].gameObject.SetActive(false); 
        starBtn[i].gameObject.SetActive(false); 
        //print("i "+i);
       }
           
         Invoke("ChangeButtons", 2); 
              
     }

      
        public void OnClickedMember(Button button)
    {
        nameIncheckList.Clear();
        keykListEditUI.Clear();
        passwordList.Clear();
        RaadAllData();


        if(button.name=="0"){
             buttonNameMember=0; 
           // print("buttonNameMember "+button.name)  ;
            
           
        }else if(button.name=="1"){
             buttonNameMember=1;   
           //print("buttonNameMember "+button.name)  ;
           
        }else if(button.name=="2"){
             buttonNameMember=2;   
      //print("buttonNameMember "+button.name)  ;
           
        }else if(button.name=="3"){
             buttonNameMember=3;   
           //print("buttonNameMember "+button.name)  ;
           
        }else if(button.name=="4"){
             buttonNameMember=4;   
           // print("buttonNameMember "+button.name)  ;
           
        }else if(button.name=="5"){
             buttonNameMember=5;   
            // print("buttonNameMember "+button.name)  ;
           
        }else if(button.name=="6"){
             buttonNameMember=6;   
            // print("buttonNameMember "+button.name)  ;
           
        }else if(button.name=="7"){
             buttonNameMember=7;   
            // print("buttonNameMember "+button.name)  ;
           
        }else if(button.name=="8"){
             buttonNameMember=8;   
            // print("buttonNameMember "+button.name)  ;
           
        }else if(button.name=="9"){
             buttonNameMember=9;   
            // print("buttonNameMember "+button.name)  ;
           
        }else if(button.name=="10"){
             buttonNameMember=10;   
            // print("buttonNameMember "+button.name)  ;
           
        }
       
        for(int i=0;i<passwordList.Count;i++){
             print("passwordList " +passwordList[i]); 
        }
       
        Invoke("CheckPasswordImage", 2);
    }

     public void CheckPasswordMember()
     {
        p =""+passwordList[buttonNameMember];
        print("buttonNameMember "+buttonNameMember) ;
        print("P " +passwordList[buttonNameMember]);
        string pf =checkPasswordField1.text+""+checkPasswordField2.text+""+checkPasswordField3.text+""+checkPasswordField4.text;
        if(String.Equals(p,pf)){
              print("pass");
              SceneManager.LoadScene("ChooseManu");

         }else{
              print("not pass");
         }
        
        
    }
    public void CheckPasswordImage() 
    {
        
         int c=Int32.Parse(""+picList[buttonNameMember]);
           
         checkPasswordName.text=""+nameIncheckList[buttonNameMember];
    
        if(c==1)

        {
            checkPasswordImage.GetComponent<Image>().sprite=sprite1;
           // print("CheckPasswordImage "+c);
        }
        else  if(c==2)
        {
            checkPasswordImage.GetComponent<Image>().sprite=sprite2;
            //("CheckPasswordImage "+c);
        }
        else  if(c==3)
        {
            checkPasswordImage.GetComponent<Image>().sprite=sprite3;
            //print("CheckPasswordImage "+c);
        }
         else  if(c==4)
        {
            checkPasswordImage.GetComponent<Image>().sprite=sprite4;
        }
        else  if(c==5)
        {
            checkPasswordImage.GetComponent<Image>().sprite=sprite5;
        }
        else  if(c==6)
        {
            checkPasswordImage.GetComponent<Image>().sprite=sprite6;
        }
        else  if(c==7)
        {
            checkPasswordImage.GetComponent<Image>().sprite=sprite7;
        }
        else  if(c==8)
        {
            checkPasswordImage.GetComponent<Image>().sprite=sprite8;
        }
        else  if(c==9)
        {
            checkPasswordImage.GetComponent<Image>().sprite=sprite9;
        }
        
     
    }
       public void CheckPasswordAddmember()
    {
        //ลอง-------------------------------------------------------------------------------
        // string password =passwordAddField.text;
        
        // auth.SignInWithEmailAndPasswordAsync(userEmail, password).ContinueWith(task => {
        //     if (task.IsCanceled) {
        //         print("not pass1");
        //         Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
        //         return;
        //     }
        //     if (task.IsFaulted) {
        //         print("not pass2");
        //         Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
        //     return;
        //     }else{
        //           AddmemberNew();
        //     }
        //Firebase.Auth.FirebaseUser newUser = task.Result;
       
       // });
        //ลอง-------------------------------------------------------------------------------

           
         //string p =""+passwordList[buttonName];
         string pf =passwordAddField.text;
         // print("passwordUser " +passwordUser);
         if(String.Equals(passwordUser,pf)){
            print("pass");
           passwordAddmemberbox.SetActive(false);
            Addmemberbox.SetActive(false);
            OnSubmit();
            AddSuccessUI.SetActive(true);
            Invoke("AddSuccess", 3); 

            
         }else{
              print("not pass");
         } 
    }

     

       public void CheckPasswordRemovemember()
    {
         //string p =""+passwordList[buttonName];
         string pf =passwordRemoveField.text;
           // print("passwordUser " +passwordUser);
         if(String.Equals(passwordUser,pf)){
            print("pass");
            Remove();
            remove0.SetActive(false);
            remove1.SetActive(false);
            remove2.SetActive(false);
            remove3.SetActive(false);
            remove4.SetActive(false);
            remove5.SetActive(false);
            remove6.SetActive(false);
            remove7.SetActive(false);
            remove8.SetActive(false);
            remove9.SetActive(false);
            remove10.SetActive(false);
            passwordRemovememberbox.SetActive(false);
            RemoveSuccessUI.SetActive(true);
            Invoke("RemoveSuccess", 3); 
            
         }else{
              print("not pass");
         } 
    }

        public void CheckPasswordLogout()
    {
         //string p =""+passwordList[buttonName];
         string pf =passwordLogoutField.text;
           // print("passwordUser " +passwordUser);
         if(String.Equals(passwordUser,pf)){
            print("pass");
            passwordLogoutbox.SetActive(false);
            SceneManager.LoadScene("Login");

         }else{
              print("not pass");
         } 
    }
  
    public void WriteAllData()
    {

        memberURL = reference.Child(LoginManager.localId).Push().Key;
        print("memberurl "+memberURL);
        Dictionary<string, Object> childUpdates = new Dictionary<string, Object>();
        // เขียนข้อมูลลง Model
        Member mData = new Member();
        // mData.m_name = Random.Range(0f, 5f);
        mData.m_password = passwordField1.text+""+passwordField2.text+""+passwordField3.text+""+passwordField4.text;
        mData.pic = ProfileMember.count;
        memberName = mData.m_name = nameField.text;
        nameList2.Add(nameField.text);
        picList2.Add(ProfileMember.count);
        keykListEditUI.Add(memberURL);
        passwordList.Add(passwordField1.text+""+passwordField2.text+""+passwordField3.text+""+passwordField4.text);
        
        string json = JsonUtility.ToJson(mData);
        print("json "+json);
        string s = LoginManager.localId;
        // เขียนข้อมูลลง Firebase
        reference.Child(LoginManager.localId).Child(memberName).SetValueAsync(memberURL);    
        reference.Child(LoginManager.localId).Child(memberURL).SetRawJsonValueAsync(json);
        reference.Child(LoginManager.localId).Child(memberURL).Child("ObservationHistory").SetValueAsync(0);    
    
}
  

 public void RaadAllData()
    {
        FirebaseDatabase.DefaultInstance.GetReference(LoginManager.localId)
        // หากข้อมูลมีการเปลี่ยนแหลงให้ทำการอ่านและแสดง
        .ValueChanged += HandleValueChanged;
    }

    private void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        // อ่าน Key เพื่อใช้แสดงผล
        List<string> keys = args.Snapshot.Children.Select(s => s.Key).ToList();
        foreach (var key in keys)
        {
            DisplayData(args.Snapshot, key);
        }
    }
    // ใช้สำหรับ แสดงข้อมูลที่โหลดครับ
    void DisplayData(DataSnapshot snapshot, string key)
    {

        string j = snapshot.Child(key).GetRawJsonValue();
        Member u = JsonUtility.FromJson<Member>(j);
         // Debug.Log(u.pic+" "+u.m_name+" "+u.m_password);
        //Debug.Log("key "+key);
            getNameMember(u.m_name);
            getpassswordMember(u.m_password);
            getPicMember(u.pic);
       if(!keyList.Contains(key)&&!key.Contains("User")){
            getKeyMember(key);
        
       
       }
       if(!nameOnTable.Contains(u.m_name)){
           nameOnTable.Add(u.m_name);
       }
       
    }
    // Update is called once per frame
   
    public void dddddd(){
    for(int i = 0 ; i < passwordList.Count; i++){
         print("passwordList "+passwordList[i]);

    }
     }
     void getNameMember(string name)
    {

        nameList.Add(name);
        nameList3.Add(name);
        
        //if(!name.Equals("")){
//         foreach (string aString in nameIncheckList)
// {
//     if (!nameIncheckList.Contains( aString ))
//         {
//         nameIncheckList.Add(name);
//         print("name ="+name);
//      }
//     }
        if(!name.Equals("")){
        nameIncheckList.Add(name);
        //nameIncheckList.RemoveAt(nameIncheckList.Count);
 //print("name ="+name);
}
     
      
    }
    void getKeyMember(string key)
    {

        keyList.Add(key);
           
    }
   void getpassswordMember(string password)
    {

        passwordList.Add(password);
           
    }
    void getPicMember(int pic)
    {

        picList.Add(pic);

           
    }
  
    public void OnClicked(Button button)
    {
        nameList3.Clear();
        picList.Clear();
        RaadAllData();
        if(button.name=="0"){
             buttonName=0;   
             buttonKey =""+keyList[0];
           
        }else if(button.name=="1"){
             buttonName=1;   
            buttonKey =""+keyList[1];
           
        }else if(button.name=="2"){
             buttonName=2;   
            buttonKey =""+keyList[2];
           
        }else if(button.name=="3"){
             buttonName=3;   
             buttonKey =""+keyList[3];
           
        }else if(button.name=="4"){
             buttonName=4;   
             buttonKey =""+keyList[4];
           
        }else if(button.name=="5"){
             buttonName=4;   
             buttonKey =""+keyList[5];
           
        }else if(button.name=="6"){
             buttonName=4;   
             buttonKey =""+keyList[6];
           
        }else if(button.name=="7"){
             buttonName=4;   
             buttonKey =""+keyList[7];
           
        }else if(button.name=="8"){
             buttonName=4;   
             buttonKey =""+keyList[8];
           
        }else if(button.name=="9"){
             buttonName=4;   
             buttonKey =""+keyList[9];
           
        }else if(button.name=="10"){
             buttonName=4;   
             buttonKey =""+keyList[10];
           
        }
        
   
    }
    public void AddSuccess()
    {
        AddSuccessUI.SetActive(false);
    }
     
    public void RemoveSuccess()
    {
        RemoveSuccessUI.SetActive(false);
    }

   
     

}
