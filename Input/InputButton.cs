using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;

public class InputButton : MonoBehaviour {
    [SerializeField, BoxGroup("GameObject")]
    private GameObject objectGameDirector;
    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private GameDirector scriptGameDirector;

    [SerializeField, BoxGroup("GameObject")]
    private GameObject objectButtonRetryInGame;

    private void Awake() {
        this.scriptGameDirector = this.objectGameDirector.GetComponent<GameDirector>();
    }

    public void InputButtonRanking() {
        if (GameDirector.IsGameRunning) {
            return;
        }

        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(ScoreManager.TotalScore);
    }

    public void InputButtonTweet() {
        if (GameDirector.IsGameRunning) {
            return;
        }

        string tweetSentence = "【" + ConstantManager.GameNameJaJP + " ver." + ConstantManager.GameVersionText + "】今回のスコア：" + ScoreManager.TotalScore;
        naichilab.UnityRoomTweet.Tweet(ConstantManager.GameIdAtUnityroom, tweetSentence, ConstantManager.TweetHashtag, ConstantManager.GameIdAtUnityroom);
    }

    public void InputButtonRetry() {
        if (GameDirector.IsGameRunning) {
            return;
        }

        this.scriptGameDirector.Retry();
    }

    public void InputButtonRetryInGame() {
        if (!GameDirector.IsGameRunning) {
            return;
        }

        this.scriptGameDirector.Retry();
    }
}
