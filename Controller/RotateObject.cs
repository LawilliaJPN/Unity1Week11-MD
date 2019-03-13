using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class RotateObject : MonoBehaviour {
    [BoxGroup("GameObject"), ShowInInspector, ReadOnly]
    protected GameObject objectBGMManager;
    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    protected BGMManager scriptBGMManager;

    [BoxGroup("Parameter"), ShowInInspector, ReadOnly]
    private int rotationInitialValue;

    [BoxGroup("Parameter"), ShowInInspector, ReadOnly]
    private float tempRotation;

    [BoxGroup("Parameter"), ShowInInspector, ReadOnly]
    private bool isClockwise = true;

    public bool IsClockwise {
        get {
            return isClockwise;
        }
        set {
            isClockwise = value;
        }
    }

    [BoxGroup("Parameter"), ShowInInspector, ReadOnly]
    private bool isRotation = true;

    public bool IsRotation {
        get {
            return isRotation;
        }
        set {
            isRotation = value;
        }
    }

    private void Awake() {
        this.objectBGMManager = GameObject.FindWithTag("BGMManager");
        this.scriptBGMManager = this.objectBGMManager.GetComponent<BGMManager>();
    }

    private void Start() {
        this.rotationInitialValue = Random.Range(0, 360 + 1);
    }

    private void Update() {
        if (!isRotation) {
            return;
        }

        float newRotation = this.rotationInitialValue + 360 * this.scriptBGMManager.GetRatioInBar();
        this.UpdateRotation(newRotation);
    }

    private void UpdateRotation(float newRotation) {
        float rotation = newRotation - tempRotation;
        tempRotation = newRotation;

        rotation %= 360;
 
        if (this.IsClockwise) {
            rotation = 360.0f - rotation;
        }

        this.transform.Rotate(new Vector3(0, 0, rotation));
    }
}
