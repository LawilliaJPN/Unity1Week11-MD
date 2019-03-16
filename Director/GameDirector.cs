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
    private OutputTime scriptOutputTime;
    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private OutputTips scriptOutputTips;
    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private DestroyAll scriptDestroyAll;

    [BoxGroup("GameObject"), ShowInInspector, ReadOnly]
    private GameObject objectSEManager;
    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private SEManager scriptSEManager;

    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private EnemyManager scriptEnemyManager;

    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private MeshRenderer rendererPlayer, rendererEnemy;

    [BoxGroup("Game"), ShowInInspector, ReadOnly]
    private static bool isGameRunning;

    public static bool IsGameRunning {
        get {
            return isGameRunning;
        }
    }

    [BoxGroup("Game"), ShowInInspector, ReadOnly]
    private static int currentWave;

    public static int CurrentWave {
        get {
            return currentWave;
        }
    }

    [BoxGroup("Timer"), ShowInInspector, ReadOnly]
    private static float timerInGame;

    public static float TimerInGame {
        get {
            return timerInGame;
        }
    }

    [BoxGroup("Counter"), ShowInInspector, ReadOnly]
    private static float counterAlermSE;

    private void Awake() {
        this.scriptBGMPlayer = this.GetComponent<BGMPlayer>();
        this.scriptOutputTime = this.GetComponent<OutputTime>();
        this.scriptOutputTips = this.GetComponent<OutputTips>();
        this.scriptDestroyAll = this.GetComponent<DestroyAll>();

        this.objectSEManager = GameObject.FindWithTag("SEManager");
        this.scriptSEManager = this.objectSEManager.GetComponent<SEManager>();

        this.rendererPlayer = this.objectPlayer.GetComponent<MeshRenderer>();
        this.rendererEnemy = this.objectEnemy.GetComponent<MeshRenderer>();

        this.scriptEnemyManager = this.objectEnemy.GetComponent<EnemyManager>();

        isGameRunning = true;
        currentWave = 0;
    }

    private void Start() {
        ScoreManager.ResetScores();

        this.NextWave();
    }

    private void Update() {
        if (isGameRunning) {
            timerInGame -= Time.deltaTime;
        }

        if (timerInGame < 0) {
            if (currentWave == ConstantManager.NumberOfWaves) {
                this.FinishGame();

            } else {
                this.NextWave();
            }
        }

        this.PlaySEAlerm();
    }

    private void NextWave() {
        this.scriptDestroyAll.DestroyAllGroup(ConstantManager.PointRatioType.WaveFinish);

        currentWave++;

        switch (currentWave) {
            case 1:
                timerInGame = ConstantManager.GameTimeWave1;
                this.scriptBGMPlayer.PlayBGMWave1();

                this.scriptEnemyManager.CoolTimeSpan = ConstantManager.TargetGeneratorCoolTimeWave1;
                break;

            case 2:
                timerInGame = ConstantManager.GameTimeWave2;
                this.scriptBGMPlayer.PlayBGMWave2();

                this.scriptEnemyManager.CoolTimeSpan = ConstantManager.TargetGeneratorCoolTimeWave2;
                break;

            case 3:
                timerInGame = ConstantManager.GameTimeWave3;
                this.scriptBGMPlayer.PlayBGMWave3();

                this.scriptEnemyManager.CoolTimeSpan = ConstantManager.TargetGeneratorCoolTimeWave3;
                break;
        }

        this.scriptEnemyManager.CoolTime = 0;

        TipsBoolManager.SetIsAlreadyTipsFalse();
        this.scriptOutputTips.SetNextTips(TipsTextManager.Tips3Wave);
        this.scriptOutputTips.UpdateOutputTipsInGame();

        counterAlermSE = ConstantManager.StandardOfTimerEmphasis;

        this.scriptOutputTime.OutputCurrentWave();

        this.scriptSEManager.PlaySEStartWave();

        if (ConstantManager.IsDebugMode) {
            Debug.Log("----------");
            Debug.Log("WaveScore");
            foreach (int waveScore in ScoreManager.WaveScores) {
                Debug.Log(waveScore);
            }
            Debug.Log("----------");
        }
    }

    private void FinishGame() {
        this.scriptDestroyAll.DestroyAllGroup(ConstantManager.PointRatioType.WaveFinish);
        this.scriptBGMPlayer.PlayBGMResult();

        this.rendererPlayer.enabled = false;
        this.rendererEnemy.enabled = false;

        isGameRunning = false;
        timerInGame = 0;
    }

    private void PlaySEAlerm() {
        if (timerInGame < counterAlermSE) {
            this.scriptSEManager.PlaySEAlerm();
            counterAlermSE -= 1.0f;
        }
    }
}