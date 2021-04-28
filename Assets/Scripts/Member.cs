using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Member 

{  
    public string m_name;
    public string m_password;
    public int pic;
    public int speakingHistory;
    public int speakingFullScore=4;
    public int helpOtherHistory;
    public int helpOtherFullScore=6;
    public int keepInorderHistory;
    public int keepInorderFullScore=3;
    // Start is called before the first frame update
//    public Member()
//     {
//        // userName = PlayerScores.playerName;
//        // userScore = PlayerScores.playerScore;
//        no=AddmemberManager.count;
//         m_name = AddmemberManager.nameMember;
//         m_password = AddmemberManager.passwordMember;
//     }
}
