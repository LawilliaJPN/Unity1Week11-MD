using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class GameDirector :MonoBehaviour {
    [SerializeField, BoxGroup("GameObject")]
    private GameObject objectPlayer;
    [SerializeField, BoxGroup("GameObject")]
    private GameObject objectEnemy;

    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private BGMPlayer scriptBGMPlayer;
    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private DestroyAll scriptDestroyAll;

    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private MeshRenderer rendererPlayer, rendererEnemy;

    [BoxGroup("Game"), ShowInInspector, ReadOnly]
    private static bool isGameRunning;

    public static bool IsGameRunning {
        get {
            return isGameRunning;
        }
    }

    [BoxGroup("Timer"), ShowInInspector, ReadOnly]
    private static float timerInGame;

    public static float TimerInGame {
        get {
            return timerInGame;
        }
    }

    [BoxGroup("Audio"), ShowInInspector, ReadOnly]
    private static bool isChangedBGM;

    public static bool IsChangedBGM {
        get {
            return isChangedBGM;
        }
    }

    private void Awake() {
        this.scriptBGMPlayer = this.GetComponent<BGMPlayer>();
        this.scriptDestroyAll = this.GetComponent<DestroyAll>();

        this.rendererPlayer = this.objectPlayer.GetComponent<MeshRenderer>();
        this.rendererEnemy = this.objectEnemy.GetComponent<MeshRenderer>();

        timerInGame = ConstantManager.GameTime;
        isGameRunning = true;
        isChangedBGM = false;
    }

    private void Update() {
        if (isGameRunning) {
            timerInGame -= Time.deltaTime;
        }

        if (timerInGame < 0) {
            this.FinishGame();

        } else if (timerInGame < (ConstantManager.GameTime / 2)) {
            if (!isChangedBGM) {
                this.LaterGame();
            }
        }
    }

    private void LaterGame() {
        this.scriptDestroyAll.DestroyAllGroup();

        this.scriptBGMPlayer.PlayBGMLater();

        isChangedBGM = true;
    }

    private void FinishGame() {
        this.scriptDestroyAll.DestroyAllGroup();
        this.scriptBGMPlayer.PlayBGMResult();

        this.rendererPlayer.enabled = false;
        this.rendererEnemy.enabled = false;

        isGameRunning = false;
        timerInGame = 0;
    }
}