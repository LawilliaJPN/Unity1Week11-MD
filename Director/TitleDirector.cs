using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.SceneManagement;

public class TitleDirector : MonoBehaviour {

    private void Update() {
        // デバッグ用
        if (Input.GetKeyDown(KeyCode.RightShift)) {
            SceneManager.LoadScene("Game");
        }
    }
}
