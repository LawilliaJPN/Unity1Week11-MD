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
    private float tempRotation;

    public float TempRotation {
        get {
            return tempRotation;
        }
        set {
            tempRotation = value;
        }
    }

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

    private void Update() {
        if (!isRotation) {
            return;
        }

        float newRotation = 360 * this.scriptBGMManager.GetRatioInBar();

        this.UpdateRotation(newRotation);
    }

    private void UpdateRotation(float newRotation) {
        float rotationAngleZ;

        /*
        if (this.gameObject.tag != "Bullet") {
            Debug.Log("tempRotation" + tempRotation);
            Debug.Log("newRotation" + newRotation);

            Debug.Log("this.transform.localRotation.eulerAngles.z " + this.transform.localRotation.eulerAngles.z);
            Debug.Log("this.transform.eulerAngles.z " + this.transform.eulerAngles.z);
            Debug.Log("this.transform.rotation.eulerAngles.z " + this.transform.rotation.eulerAngles.z);
        }*/

        if (this.IsClockwise) {
            rotationAngleZ = tempRotation - newRotation;

        } else {
            rotationAngleZ = newRotation - tempRotation;
        }

        tempRotation = newRotation;
        rotationAngleZ %= 360;

        this.transform.Rotate(new Vector3(0, 0, rotationAngleZ));
    }
}
