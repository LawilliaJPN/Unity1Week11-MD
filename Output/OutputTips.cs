using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class OutputTips : MonoBehaviour {
    [SerializeField, BoxGroup("GameObject")]
    private GameObject objectTextTipsInGame;

    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private Text textTipsInGame;

    [BoxGroup("Tips"), ShowInInspector, ReadOnly]
    private string[] arrayTextTips = new string[ConstantManager.NumOfTipsInGame];

    [BoxGroup("Tips"), ShowInInspector, ReadOnly]
    private List<string> listTextTipsRandomly = new List<string>();

    [BoxGroup("Tips"), ShowInInspector, ReadOnly]
    private string nextTextTips = "";

    [BoxGroup("Tips"), ShowInInspector, ReadOnly]
    private int currentTipsNumber = 0;

    [BoxGroup("Tips"), ShowInInspector, ReadOnly]
    private float standardOfNextTimer = 0;

    [BoxGroup("Tips"), ShowInInspector, ReadOnly]
    private int tempRandomNumber = -1;

    private void Awake() {
        this.textTipsInGame = this.objectTextTipsInGame.GetComponent<Text>();

        for (int i = 0; i < ConstantManager.NumOfTipsInGame; i++) {
            this.arrayTextTips[i] = "";
        }

        this.arrayTextTips[ConstantManager.OrderOfTipsMoveWASD] = TipsTextManager.TipsControllMoveWASD;
        this.arrayTextTips[ConstantManager.OrderOfTipsShootClick] = TipsTextManager.TipsControllShootClick;

        this.SetTipsRandomlyList();
    }

    private void Update() {
        if (!GameDirector.IsGameRunning) {
            this.HideTips();
            return;
        }

        if (GameDirector.TimerInGame < this.standardOfNextTimer) {
            this.UpdateOutputTipsInGame();
        }
    }

    public void UpdateOutputTipsInGame() {
        if (ConstantManager.IsDebugMode) {
            Debug.Log("OutputTips UpdateOutputTipsInGame");
        }

        if (this.currentTipsNumber >= ConstantManager.NumOfTipsInGame) {
            this.textTipsInGame.text = "";
            return;
        }

        if (GameDirector.CurrentWave >= ConstantManager.NumberOfWaves) {
            this.textTipsInGame.text = "";
            return;
        }

        if (this.arrayTextTips[this.currentTipsNumber] != "") {
            this.OutputTipsInGame(this.arrayTextTips[this.currentTipsNumber]);

        } else if (this.nextTextTips != "") {
            this.OutputTipsInGame(this.nextTextTips);
            this.nextTextTips = "";

        } else {
            string randomTextTips = this.GetTipsRandomly();
            this.OutputTipsInGame(randomTextTips);
        }
    }

    private void OutputTipsInGame(string newTextTips) {
        if (ConstantManager.IsDebugMode) {
            Debug.Log("OutputTips OutputTipsInGame / Timer:" + GameDirector.TimerInGame + "TipsNum:" + this.currentTipsNumber);
        }

        this.textTipsInGame.text = newTextTips;
        this.arrayTextTips[this.currentTipsNumber] = newTextTips;

        if (this.currentTipsNumber == ConstantManager.OrderOfTipsShootClick) {
            TipsBoolManager.SetIsAlreadyTipsFalse();
        } 

        this.currentTipsNumber++;
        this.standardOfNextTimer = GameDirector.TimerInGame - ConstantManager.TipsSpan;

        Invoke("HideTips", ConstantManager.HideTipsSpan);
    }

    public void SetNextTips(string newTextTips) {
        if (ConstantManager.IsDebugMode) {
            Debug.Log("SetNextTips: " + newTextTips);
        }

        this.nextTextTips = newTextTips;
    }

    private void SetTipsRandomlyList() {
        this.listTextTipsRandomly.Add(TipsTextManager.TipsControllMoveArrow);
        this.listTextTipsRandomly.Add(TipsTextManager.TipsControllMoveHJKL);
        this.listTextTipsRandomly.Add(TipsTextManager.TipsControllShootSpace);

        this.listTextTipsRandomly.Add(TipsTextManager.TipsChildrenSlowdown);

        this.listTextTipsRandomly.Add(TipsTextManager.TipsAdviceNotConnect);
        this.listTextTipsRandomly.Add(TipsTextManager.TipsAdviceConnect);
        this.listTextTipsRandomly.Add(TipsTextManager.TipsAdviceRight);
        this.listTextTipsRandomly.Add(TipsTextManager.TipsAdviceNotRapidFire);

        this.listTextTipsRandomly.Add(TipsTextManager.TipsScoreWhenBulletCollideWithTarget);
        this.listTextTipsRandomly.Add(TipsTextManager.TipsScoreWhenGroupBulletCollideWithTarget);
        this.listTextTipsRandomly.Add(TipsTextManager.TipsScoreWhenTargetCollideWithTarget);
        this.listTextTipsRandomly.Add(TipsTextManager.TipsScoreWhenPlayerCollideWithTarget);
        this.listTextTipsRandomly.Add(TipsTextManager.TipsScoreWhenWaveFinish);
        this.listTextTipsRandomly.Add(TipsTextManager.TipsScoreExplosion);
    }

    private string GetTipsRandomly() {
        int index = Random.Range(0, this.listTextTipsRandomly.Count);

        if (index == this.tempRandomNumber) {
            index++;
            index %= this.listTextTipsRandomly.Count;
        }

        this.tempRandomNumber = index;

        return this.listTextTipsRandomly[index];
    }

    private void HideTips() {
        this.textTipsInGame.text = "";
    }
}
