using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;

public class GameDirector :MonoBehaviour {
    [SerializeField, BoxGroup("GameObject")]
    private GameObject objectPlayer;
    [SerializeField, BoxGroup("GameObject")]
    private GameObject objectEnemy;
    [SerializeField, BoxGroup("GameObject")]
    private GameObject objectButtonsInGame, objectButtonsInResult;
    [SerializeField, BoxGroup("GameObject")]
    private GameObject objectTextsInGame, objectTextsInResult;

    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private BGMPlayer scriptBGMPlayer;
    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private OutputScore scriptOutputScore;
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
        set {
            isGameRunning = value;
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

    [BoxGroup("Timer"), ShowInInspector, ReadOnly]
    private static float timerBeforeRetry;

    public static float TimerBeforeRetry {
        get {
            return timerBeforeRetry;
        }
    }

    [BoxGroup("Counter"), ShowInInspector, ReadOnly]
    private static float counterAlermSE;

    [BoxGroup("Timer"), ShowInInspector, ReadOnly]
    public static bool isAlreadyBeginCount = false;

    private void Awake() {
        this.scriptBGMPlayer = this.GetComponent<BGMPlayer>();
        this.scriptOutputScore = this.GetComponent<OutputScore>();
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
        timerBeforeRetry = 0;
    }

    private void Start() {
        this.SetDisactiveComponentsInResult();

        ScoreManager.ResetScores();

        this.NextWave();

        if (!isAlreadyBeginCount) {
            this.Retry();
        }
    }

    private void Update() {
        if (isGameRunning) {
            timerInGame -= Time.deltaTime;
        }

        if (timerBeforeRetry > 0) {
            timerBeforeRetry -= Time.deltaTime;
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

        if (isAlreadyBeginCount) {
            this.scriptEnemyManager.CoolTime = 0;

            TipsBoolManager.SetIsAlreadyTipsFalse();
            this.scriptOutputTips.SetNextTips(TipsTextManager.Tips3Wave);
            this.scriptOutputTips.UpdateOutputTipsInGame();

            counterAlermSE = ConstantManager.StandardOfTimerEmphasis;

            this.scriptOutputTime.OutputCurrentWave();

            this.scriptSEManager.PlaySEStartWave();
            ScoreManager.DebugScore();
        }

    }

    private void FinishGame() {
        this.StopGame();

        this.SetDisactiveComponentsInGame();
        this.SetActiveComponentsInResult();
        this.scriptOutputScore.OutputTextResult();

        this.scriptBGMPlayer.PlayBGMResult();

        ScoreManager.DebugScore();

        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(ScoreManager.TotalScore);
    }

    public void Retry() {
        this.StopGame();

        this.SetActiveTextsInGame();
        this.SetDisactiveButtonsInGame();
        this.SetDisactiveComponentsInResult();

        this.scriptSEManager.PlaySEStartGame();

        timerBeforeRetry = ConstantManager.TimeBeforeRetry;
        Invoke("ReloadGameScene", ConstantManager.TimeBeforeRetry);
    }

    private void ReloadGameScene() {
        isAlreadyBeginCount = true;
        SceneManager.LoadScene("Game");
    }

    private void StopGame() {
        this.scriptDestroyAll.DestroyAllGroup(ConstantManager.PointRatioType.WaveFinish);

        this.rendererPlayer.enabled = false;
        this.rendererEnemy.enabled = false;

        isGameRunning = false;
        counterAlermSE = 0;
        timerInGame = 0;

        this.scriptOutputTime.HideTextWave();

        this.scriptBGMPlayer.StopBGM();
    }

    private void SetActiveTextsInGame() {
        this.objectTextsInGame.SetActive(true);
    }

    private void SetActiveComponentsInGame() {
        this.objectButtonsInGame.SetActive(true);
        this.objectTextsInGame.SetActive(true);
    }

    private void SetActiveComponentsInResult() {
        this.objectButtonsInResult.SetActive(true);
        this.objectTextsInResult.SetActive(true);
    }

    private void SetDisactiveComponentsInGame() {
        this.objectButtonsInGame.SetActive(false);
        this.objectTextsInGame.SetActive(false);
    }

    private void SetDisactiveButtonsInGame() {
        this.objectButtonsInGame.SetActive(false);
    }

    private void SetDisactiveComponentsInResult() {
        this.objectButtonsInResult.SetActive(false);
        this.objectTextsInResult.SetActive(false);
    }

    private void PlaySEAlerm() {
        if (timerInGame < counterAlermSE) {
            this.scriptSEManager.PlaySEAlerm();
            counterAlermSE -= 1.0f;
        }
    }
}