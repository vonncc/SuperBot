using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTest : MonoBehaviour
{
    public enum ToShow
    {
        achievement,
        leaderboard,
        submitScore
    }

    public ToShow toShow;

    int score;

    public void OnClick()
    {
        switch (toShow)
        {
            case ToShow.achievement:
                SocialPlatScript.ShowAchivement();
                break;
            case ToShow.leaderboard:
                SocialPlatScript.ShowLeaderboard();
                break;
            case ToShow.submitScore:
                score += 1;
                SocialPlatScript.ReportScore("CggIw9ipnxAQAhAC", score);
                break;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
