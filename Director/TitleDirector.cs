using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.SceneManagement;

public class TitleDirector : MonoBehaviour {
    [BoxGroup("GameObject"), ShowInInspector, ReadOnly]
    private GameObject objectBGMManager;
    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private BGMManager scriptBGMManager;

    private void Awake() {
        this.objectBGMManager = GameObject.FindWithTag("BGMManager");
        this.scriptBGMManager = this.objectBGMManager.GetComponent<BGMManager>();
    }

    private void Start() {
        this.scriptBGMManager.PlayBGMAtNewScene();
    }

    private void Update() {
        // デバッグ用
        if (Input.GetKeyDown(KeyCode.RightShift)) {
            SceneManager.LoadScene("Game");
        }
    }
}
