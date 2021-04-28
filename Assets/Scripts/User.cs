using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class User
{
   // public string userName;
  //  public int userScore;
    public string localId;
     public string userName;
    public string userSurname;
    public string userEmail;
    public string username;
    public string password;
    public int gender;
    public User()
    {
       // userName = PlayerScores.playerName;
       // userScore = PlayerScores.playerScore;
        localId = RegisterManager.localId;
        userName = RegisterManager.u_name;
        userSurname = RegisterManager.u_lastname;
        userEmail = RegisterManager.u_email;
        username = RegisterManager.u_username;
        password = RegisterManager.u_password;
        gender=RegisterManager.u_gender;
    }
}
