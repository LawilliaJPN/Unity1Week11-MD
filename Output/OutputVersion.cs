using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class OutputVersion : MonoBehaviour {
    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private Text textVersion;

    private void Awake() {
        this.textVersion = this.GetComponent<Text>();
    }

    private void Start() {
        this.textVersion.text = "ver." + ConstantManager.GameVersionText;
    }
}