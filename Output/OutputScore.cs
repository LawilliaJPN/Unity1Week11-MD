using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class OutputScore : MonoBehaviour {
    [SerializeField, BoxGroup("GameObject")]
    private GameObject objectTextScoreInGame, objectTextScoreTotal;
    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private Text textScoreInGame, textScoreTotal;

    [SerializeField, BoxGroup("GameObject")]
    private GameObject objectTextScoreWave1, objectTextScoreWave2, objectTextScoreWave3;

    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private Text textScoreWave1, textScoreWave2, textScoreWave3;

    private void Awake() {
        this.textScoreInGame = this.objectTextScoreInGame.GetComponent<Text>();
        this.textScoreTotal = this.objectTextScoreTotal.GetComponent<Text>();

        this.textScoreWave1 = this.objectTextScoreWave1.GetComponent<Text>();
        this.textScoreWave2 = this.objectTextScoreWave2.GetComponent<Text>();
        this.textScoreWave3 = this.objectTextScoreWave3.GetComponent<Text>();
    }

    private void Update() {
        if (GameDirector.IsGameRunning) {
            this.UpdateTextScore();

        } else {
            this.HideScore();
        }
    }

    public void OutputTextResult() {
        this.textScoreTotal.text = ScoreManager.TotalScore.ToString("D6");
        this.textScoreWave1.text = ScoreManager.WaveScores[0].ToString("D6");
        this.textScoreWave2.text = ScoreManager.WaveScores[1].ToString("D6");
        this.textScoreWave3.text = ScoreManager.WaveScores[2].ToString("D6");
    }

    private void UpdateTextScore() {
        this.textScoreInGame.text = ScoreManager.TotalScore.ToString("D6");
    }

    private void HideScore() {
        this.textScoreInGame.text = "";
    }
}