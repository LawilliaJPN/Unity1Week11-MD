using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class OutputTime : MonoBehaviour {
    [SerializeField, BoxGroup("GameObject")]
    private GameObject objectTextTimer, objectTextWave, objectTextTimerEmphasis;

    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private Text textTimer, textWave, textTimerEmphasis;

    private void Awake() {
        this.textTimer = this.objectTextTimer.GetComponent<Text>();
        this.textWave = this.objectTextWave.GetComponent<Text>();
        this.textTimerEmphasis = this.objectTextTimerEmphasis.GetComponent<Text>();

        this.HideTextWave();
        this.HideTextTimerEmphasis();
    }

    private void Update() {
        this.UpdateTextTimer();
    }

    private void UpdateTextTimer() {
        if (!GameDirector.IsGameRunning) {
            this.HideTextTimer();
            this.HideTextTimerEmphasis();
            return;
        }

        if (GameDirector.TimerInGame < ConstantManager.StandardOfTimerEmphasis) {
            this.HideTextTimer();
            this.textTimerEmphasis.text = Math.Ceiling(GameDirector.TimerInGame).ToString();

        } else {
            this.textTimer.text = Math.Ceiling(GameDirector.TimerInGame).ToString();
            this.HideTextTimerEmphasis();
        }
    }

    public void OutputCurrentWave() {
        if (GameDirector.CurrentWave == ConstantManager.NumberOfWaves) {
            this.textWave.text = "最終Wave";

        } else {
            this.textWave.text = "Wave" + GameDirector.CurrentWave;

        }

        Invoke("HideTextWave", ConstantManager.TimeDisplayTextWave);
    }

    private void HideTextTimer() {
        this.textTimer.text = "";
    }

    private void HideTextWave() {
        this.textWave.text = "";
    }

    private void HideTextTimerEmphasis() {
        this.textTimerEmphasis.text = "";
    }
}
