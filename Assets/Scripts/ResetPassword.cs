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

public class ResetPassword : MonoBehaviour
{
  

    public InputField resetEmailField;

    private string databaseURL = "https://project-75a5c-default-rtdb.firebaseio.com"; 
    private string AuthKey = "AIzaSyBdvdw8w_v66y96r7ndXpKRs39lMiZwABY";
    
    public static fsSerializer serializer = new fsSerializer();
    
    public static string email;

    private string idToken;
    
   public static string localId;

    public GameObject enterEmailAgain;
    public GameObject success;



    private FirebaseAuth auth;
 //   public Button SignupButton, SigninButton;
    public DatabaseReference reference;

void Start()
    {
        success.SetActive(false);
        enterEmailAgain.SetActive(false);
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        auth = FirebaseAuth.DefaultInstance;
       
        //SignupButton.onClick.AddListener(() => Signup(nameText.text, surnameText.text, emailText.text, usernameText.text, passwordText.text));
       // SignupButton.onClick.AddListener(() => StartCoroutine(Register(emailText.text, passwordText.text, usernameText.text)));
       // SigninButton.onClick.AddListener(() => LoginAction(emailText.text, passwordText.text));
       FirebaseApp.GetInstance("https://project-75a5c-default-rtdb.firebaseio.com/");
    
    }
    public void submit(){
        email = resetEmailField.text;
        
        if(email==("")){
            enterEmailAgain.SetActive(true);
        }else{
            enterEmailAgain.SetActive(false);
            success.SetActive(true);
            auth.SendPasswordResetEmailAsync(email).ContinueWith(task => {
        if (task.IsCanceled) {
            Debug.LogError("SendPasswordResetEmailAsync was canceled.");
            return;
        }
        if (task.IsFaulted) {
            Debug.LogError("SendPasswordResetEmailAsync encountered an error: " + task.Exception);
            return;
        }
        

        /*Debug.Log("Password reset email sent successfully.");*/
  });    
            
        }
    }
    public void goTologin(){
        SceneManager.LoadScene("Login");
    }
}
