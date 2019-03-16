using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class OutputScore : MonoBehaviour {
    [SerializeField, BoxGroup("GameObject")]
    private GameObject objectTextScore;

    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private Text textScore;

    private void Awake() {
        this.textScore = this.objectTextScore.GetComponent<Text>();
    }

    private void Update() {
        if (GameDirector.IsGameRunning) {
            this.UpdateTextScore();

        } else {
            this.HideScore();
        }
    }

    private void UpdateTextScore() {
        this.textScore.text = ScoreManager.TotalScore.ToString("D6");
    }

    private void HideScore() {
        this.textScore.text = "";
    }
}