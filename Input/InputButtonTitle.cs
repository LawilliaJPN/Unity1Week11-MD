using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;

public class InputButtonTitle : MonoBehaviour {
    public void InputButtonStart() {
        SceneManager.LoadScene("Game");
    }

    public void InputButtonRanking() {
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(0);
    }

    public void InputButtonTweet() {
        string tweetSentence = ConstantManager.GameNameJaJP + " ver." + ConstantManager.GameVersionText;
        naichilab.UnityRoomTweet.Tweet(ConstantManager.GameIdAtUnityroom, tweetSentence, ConstantManager.TweetHashtag, ConstantManager.GameIdAtUnityroom);
    }
}