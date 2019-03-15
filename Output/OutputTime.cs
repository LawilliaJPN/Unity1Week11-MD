using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class OutputTime :MonoBehaviour {
    [SerializeField, BoxGroup("GameObject")]
    private GameObject objectTextTimer;

    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private Text textTimer;

    private void Awake() {
        this.textTimer = this.objectTextTimer.GetComponent<Text>();
    }

    private void Update() {
        this.UpdateTextTimer();
    }

    private void UpdateTextTimer() {
        if (GameDirector.IsGameRunning) {
            this.textTimer.text = Math.Ceiling(GameDirector.TimerInGame).ToString();

        } else {
            this.textTimer.text = "";
        }
    }
}
