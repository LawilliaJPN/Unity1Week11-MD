using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class RotateObject : ControllShaper2D {
    [BoxGroup("Shaper2D"), ShowInInspector, ReadOnly]
    private int rotationInitialValue;

    private void Start() {
        this.rotationInitialValue = Random.Range(0, 360 + 1);
    }

    private void Update() {
        int newRotation = this.rotationInitialValue + (int)(360 * this.scriptBGMManager.GetRatioInBar());
        this.UpdateRotation(newRotation);
    }

    private void UpdateRotation(int newRotation) {
        newRotation %= 360;

        this.shaper2D.rotation = newRotation;
    }
}
