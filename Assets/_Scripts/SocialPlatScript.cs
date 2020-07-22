using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

#if UNITY_ANDROID
using GooglePlayGames;
using GooglePlayGames.BasicApi;
#elif UNITY_IOS
using UnityEngine.SocialPlatforms.GameCenter;
#endif
public class SocialPlatScript : MonoBehaviour
{
    public UnityEngine.UI.Text socialPlatform;
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("SocialPlatform");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

#if UNITY_ANDROID
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        //// enables saving game progress.
        ////.EnableSavedGames()
        //// registers a callback to handle game invitations received while the game is not running.
        ////.WithInvitationDelegate(< callback method >)
        //// registers a callback for turn based match notifications received while the
        //// game is not running.
        ////.WithMatchDelegate(< callback method >)
        //// requests the email address of the player be available.
        //// Will bring up a prompt for consent.
        ////.RequestEmail()
        //// requests a server auth code be generated so it can be passed to an
        ////  associated back end server application and exchanged for an OAuth token.
        ////.RequestServerAuthCode(false)
        //// requests an ID token be generated.  This OAuth token can be used to
        ////  identify the player to other services such as Firebase.
        //.RequestIdToken()
        //.Build();

        //PlayGamesPlatform.InitializeInstance(config);
        //// recommended for debugging:
        //PlayGamesPlatform.DebugLogEnabled = true;
        // Activate the Google Play Games platform
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();

#elif UNITY_IOS

#else

#endif
        // print("TRY TO AUTHENTICATE");
        // Social.localUser.Authenticate((bool success, string something) => {
        //     // handle success or failure
        //     print("DID AUTHENTICATE?");
        //     print(success.ToString());
        //     print("STRING CALLBACK");
        //     print(something);
        // });
        //Social.Active.act

        
    }

    public static void ResetAchivements()
    {
#if UNITY_IOS
        GameCenterPlatform.ResetAllAchievements((resetResult) => {
            Debug.Log((resetResult) ? "Reset done." : "Reset failed.");
        });
#elif UNITY_ANDROID

#endif

    }

    // Unlock an achievement
    public static void SetAchievement(string pAchievementID, float pProgress = 100.0f)
    {
        // unlock achievement (achievement ID "pAchievementID)
        Social.ReportProgress(pAchievementID, pProgress, (bool success) => {
            // handle success or failure
            print("ACHIEVEMENT UNLOCKED");
        });
    }

    // Set Score to Leaderboard
    public static void ReportScore(string pLeaderboardID, int pScore)
    {
        // post score 12345 to leaderboard ID pLeaderboardID)
        Social.ReportScore(pScore, pLeaderboardID, (bool success) => {
            // handle success or failure
        });

    }

    // Show Achievments UI
    public static void ShowAchivement()
    {
        Social.ShowAchievementsUI();
    }

    // Show Leaderboard UI
    public static void ShowLeaderboard()
    {
//#if UNITY_ANDROID
        Social.ShowLeaderboardUI();
//#elif UNITY_IOS
//        GameCenterPlatform.ShowLeaderboardUI();
//#endif
    }



    // Start is called before the first frame update
    private void Start()
    {
        socialPlatform.text = Social.Active.ToString();

        Social.localUser.Authenticate((bool success, string str) => {
            // handle success or failure

            if (success == true)
            {
                print("Authentication Success");
                // SubmitScore(highscore);
            } else
            {
                print("Authentication failed: " + str);
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
