using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;

public class BGMPlayerAtNewScene : MonoBehaviour {
    [BoxGroup("GameObject"), ShowInInspector, ReadOnly]
    private GameObject objectBGMManager;
    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private BGMManager scriptBGMManager;

    private void Awake() {
        this.objectBGMManager = GameObject.FindWithTag("BGMManager");
        this.scriptBGMManager = this.objectBGMManager.GetComponent<BGMManager>();
    }

    private void Start() {
        this.PlayBGMAtNewScene();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.RightAlt)) {
            // デバッグ用
            this.scriptBGMManager.SwitchBGM();
        }
    }

    public void PlayBGMAtNewScene() {
        Debug.Log("PlayBGMAtNewScene / " + SceneManager.GetActiveScene().name);

        switch (SceneManager.GetActiveScene().name) {
            case "Title":
                this.scriptBGMManager.PlayBGMTitle();
                break;
            case "Game":
                this.scriptBGMManager.PlayBGMWave1();
                break;
        }
    }
}
