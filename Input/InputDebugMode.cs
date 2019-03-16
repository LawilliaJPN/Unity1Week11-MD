using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;

public class InputDebugMode : MonoBehaviour {
    [BoxGroup("GameObject"), ShowInInspector, ReadOnly]
    private GameObject objectBGMManager;
    [BoxGroup("GameObject"), ShowInInspector, ReadOnly]
    private GameObject objectSEManager;

    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private BGMManager scriptBGMManager;
    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private SEManager scriptSEManager;


    [BoxGroup("GameObject"), ShowInInspector, ReadOnly]
    private GameObject objectGameDirector;
    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private DestroyAll scriptDestroyAll;

    private void Awake() {
        this.objectBGMManager = GameObject.FindWithTag("BGMManager");
        this.objectSEManager = GameObject.FindWithTag("SEManager");

        this.scriptBGMManager = this.objectBGMManager.GetComponent<BGMManager>();
        this.scriptSEManager = this.objectSEManager.GetComponent<SEManager>();

        if (SceneManager.GetActiveScene().name == "Game") {
            this.objectGameDirector = GameObject.FindWithTag("Director");
            this.scriptDestroyAll = this.objectGameDirector.GetComponent<DestroyAll>();
        }
    }

    private void Update() {
        if (!ConstantManager.IsDebugMode) {
            return;
        }

        if (Input.GetKey(KeyCode.Delete)) {
            if (SceneManager.GetActiveScene().name == "Game") {
                this.scriptDestroyAll.DestroyAllGroup(ConstantManager.PointRatioType.Debug);
            }
        }

        if (Input.GetKeyDown(KeyCode.RightAlt)) {
            this.scriptBGMManager.SwitchBGM();
        }

        if (Input.GetKeyDown(KeyCode.RightControl)) {
            this.scriptSEManager.PlaySETest();
        }

        if (Input.GetKeyDown(KeyCode.RightShift)) {
            if (SceneManager.GetActiveScene().name == "Title") {
                SceneManager.LoadScene("Game");
            }
        }
    }
}
