using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;

public class InputManager :MonoBehaviour {
    [BoxGroup("GameObject"), ShowInInspector, ReadOnly]
    private GameObject objectDirector;
    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private GameDirector scriptGameDirector;

    [BoxGroup("GameObject"), ShowInInspector, ReadOnly]
    private GameObject objectPuppet;

    [BoxGroup("Parameter"), ShowInInspector, ReadOnly]
    private bool isGameScene;

    [BoxGroup("Parameter"), ShowInInspector, ReadOnly]
    private float speed;

    public float Speed {
        get {
            return speed;
        }
        set {
            speed = value;

            if (speed > 1.0f) { // 仮
                speed = 1.0f;
            } else if (speed < 0) {
                speed = 0;
            }
        }
    }

    [BoxGroup("Parameter"), ShowInInspector, ReadOnly]
    private float maxOfMovingRangeY, minOfMovingRangeY;

    public float MaxOfMovingRangeY {
        get {
            return maxOfMovingRangeY;
        }
        set {
            maxOfMovingRangeY = value;
        }
    }

    public float MinOfMovingRangeY {
        get {
            return minOfMovingRangeY;
        }
        set {
            minOfMovingRangeY = value;
        }
    }


    private void Awake() {
        this.objectDirector = GameObject.FindWithTag("Director");

        this.InitializeGameScene();
    }

    private void Update() {
        this.SetPlayerMovement();
    }

    private void InitializeGameScene() {
        if (SceneManager.GetActiveScene().name == "Game") {
            this.SetPlayerToPuppet();
            this.scriptGameDirector = objectDirector.GetComponent<GameDirector>();

            this.isGameScene = true;

        } else {
            this.isGameScene = false;
        }
    }

    private void SetPlayerToPuppet() {
        this.objectPuppet = GameObject.FindWithTag("Player");
        this.Speed = PlayerManager.Speed;
        this.MaxOfMovingRangeY = PlayerManager.MaxOfMovingRangeY;
        this.MinOfMovingRangeY = PlayerManager.MinOfMovingRangeY;
    }

    private void SetPlayerMovement() {
        if (!this.isGameScene) {
            return;
        }

        Vector3 newPosition = this.objectPuppet.transform.position;

        if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.UpArrow))) {
            if (newPosition.y < this.MaxOfMovingRangeY) {
                newPosition.y += this.Speed;
            }
        }

        if ((Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.DownArrow))) {
            if (newPosition.y > this.MinOfMovingRangeY) {
                newPosition.y -= this.Speed;
            }
        }

        this.objectPuppet.transform.position = newPosition;
    }
}
