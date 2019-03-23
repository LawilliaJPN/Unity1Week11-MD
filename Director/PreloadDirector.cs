using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.SceneManagement;

public class PreloadDirector : MonoBehaviour {
    [SerializeField, BoxGroup("GameObject")]
    private GameObject objectGameManagers;

    private void Start() {
        DontDestroyOnLoad(this.objectGameManagers);

        SceneManager.LoadScene("Title");
    }
}