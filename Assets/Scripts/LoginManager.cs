using System.Collections;
using System.Collections.Generic;
using FullSerializer;
using Proyecto26;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Firebase.Database;
using Firebase;
using Firebase.Auth;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
  

    //Login variables
    [Header("Login")]
    public InputField emailLoginField;
    public InputField passwordLoginField;
    public TMP_Text testLogin;
    //public Text warningLoginText;
    //public Text confirmLoginText;


    public static string uname;
    public static string usurname;
    public static string uemail;
    public static string uusername;
    public static string upassword;


    //User user = new User();

    private string databaseURL = "https://project-75a5c-default-rtdb.firebaseio.com"; 
    private string AuthKey = "AIzaSyBdvdw8w_v66y96r7ndXpKRs39lMiZwABY";
    
    public static fsSerializer serializer = new fsSerializer();
    
    
    public static int playerScore;
    public static string playerName;

    private string idToken;
    
   public static string localId;



    private FirebaseAuth auth;
 //   public Button SignupButton, SigninButton;
    public Text ErrorText;
    public DatabaseReference reference;
    // private string getLocalId;
    
    /*
   
    public void OnGetScore()
    {
        GetLocalId();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + user.userScore;
    }
    */
void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        auth = FirebaseAuth.DefaultInstance;
       
        //SignupButton.onClick.AddListener(() => Signup(nameText.text, surnameText.text, emailText.text, usernameText.text, passwordText.text));
       // SignupButton.onClick.AddListener(() => StartCoroutine(Register(emailText.text, passwordText.text, usernameText.text)));
       // SigninButton.onClick.AddListener(() => LoginAction(emailText.text, passwordText.text));
       FirebaseApp.GetInstance("https://project-75a5c-default-rtdb.firebaseio.com/");
    
}



     private void UpdateErrorMessage(string message)
    {
        ErrorText.text = message;
        Invoke("ClearErrorMessage", 5);
    }

    void ClearErrorMessage()
    {
        ErrorText.text = "";
    }
    public void Login()
    {
     SceneManager.LoadScene("User");
    }
    
    public void RegisterButton()
    {
        SceneManager.LoadScene("Register");
    }
    
       public void SignInUserButton()
    {
        SignInUser(emailLoginField.text, passwordLoginField.text);
         
    }
    
    private void SignInUser(string email, string password)
    {   
        string userData = "{\"email\":\"" + email + "\",\"password\":\"" + password + "\",\"returnSecureToken\":true}";
        RestClient.Post<SignResponse>("https://www.googleapis.com/identitytoolkit/v3/relyingparty/verifyPassword?key=" + AuthKey, userData).Then(
            response =>
            {
                string emailVerification = "{\"idToken\":\"" + response.idToken + "\"}";
                RestClient.Post(
                    "https://www.googleapis.com/identitytoolkit/v3/relyingparty/getAccountInfo?key=" + AuthKey,
                    emailVerification).Then(
                    emailResponse =>
                    {

                        fsData emailVerificationData = fsJsonParser.Parse(emailResponse.Text);
                        EmailConfirmationInfo emailConfirmationInfo = new EmailConfirmationInfo();
                        serializer.TryDeserialize(emailVerificationData, ref emailConfirmationInfo).AssertSuccessWithoutWarnings();
                        
                        if (emailConfirmationInfo.users[0].emailVerified)
                        {
                            idToken = response.idToken;
                            localId = response.localId;
                            uemail=email;
                             Debug.Log(uemail);
                           // uusername=RegisterManager.u_username ;
                            GetUsername();
                            testLogin.text ="Login Success";
                            Login();
                        }
                        else
                        {
                            testLogin.text ="Verify your email";
                           // Debug.Log("You are stupid, you need to verify your email dumb");
                        }
                    });
                
            }).Catch(error =>
        {
            testLogin.text ="Email or Password is incorrect";
            Debug.Log(error);
        });
    }

    
    private void GetUsername()
    {
        FirebaseDatabase.DefaultInstance.GetReference(localId).GetValueAsync().ContinueWith(task => 
    {  
        DataSnapshot snapshot = task.Result;
        string ss = snapshot.Child(uusername).Child("password").Value.ToString();
        print(ss);
        print("data retrieved");
         Debug.Log(uusername);
    });        
        
    }
    
    // private void GetLocalId(){
    //     RestClient.Get(databaseURL + ".json?auth=" + idToken).Then(response =>
    //     {
    //         var username = getScoreText.text;
            
    //         fsData userData = fsJsonParser.Parse(response.Text);
    //         Dictionary<string, User> users = null;
    //         serializer.TryDeserialize(userData, ref users);

    //         foreach (var user in users.Values)
    //         {
    //             if (user.userName == username)
    //             {
    //                 getLocalId = user.localId;
    //                 RetrieveFromDatabase();
    //                 break;
    //             }
    //         }
    //     }).Catch(error =>
    //     {
    //         Debug.Log(error);
    //     });
    // }
}
