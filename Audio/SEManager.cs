using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class SEManager : AudioManager {
    [SerializeField, BoxGroup("Audio")]
    private AudioClip seAlerm;

    [SerializeField, BoxGroup("Audio")]
    private AudioClip seBulletHit;

    [SerializeField, BoxGroup("Audio")]
    private AudioClip seBulletVanish;

    [SerializeField, BoxGroup("Audio")]
    private AudioClip seDamage;

    [SerializeField, BoxGroup("Audio")]
    private AudioClip seDestroy1, seDestroy2, seDestroy3;

    [SerializeField, BoxGroup("Audio")]
    private AudioClip seShoot;

    [SerializeField, BoxGroup("Audio")]
    private AudioClip seStartGame;

    [SerializeField, BoxGroup("Audio")]
    private AudioClip seStartWave;

    [SerializeField, BoxGroup("Audio")]
    private AudioClip seTargetVanish;

    [SerializeField, BoxGroup("Audio")]
    private AudioClip seTest;

    private void Start() {
        this.Volume = ConstantManager.InitialVolumeSE;
        this.UpdateVolume();
    }

    public void PlaySEAlerm() {
        this.PlaySE(this.seAlerm);
    }

    public void PlaySEBulletHit() {
        this.PlaySE(this.seBulletHit);
    }

    public void PlaySEBulletVanish() {
        this.PlaySE(this.seBulletVanish);
    }

    public void PlaySEDamage() {
        this.PlaySE(this.seDamage);
    }
    
    public void PlaySEDestroy1() {
        this.PlaySE(this.seDestroy1);
    }

    public void PlaySEDestroy2() {
        this.PlaySE(this.seDestroy2);
    }

    public void PlaySEDestroy3() {
        this.PlaySE(this.seDestroy3);
    }

    public void PlaySEShoot() {
        this.PlaySE(this.seShoot);
    }

    public void PlaySEStartGame() {
        this.PlaySE(this.seStartGame);
    }

    public void PlaySEStartWave() {
        this.PlaySE(this.seStartWave);
    }

    public void PlaySETest() {
        this.PlaySE(this.seTest);
    }

    public void PlaySETargetVanish() {
        this.PlaySE(this.seTargetVanish);
    }
}
/*

[BoxGroup("GameObject"), ShowInInspector, ReadOnly]
private GameObject objectSEManager;
[BoxGroup("Component"), ShowInInspector, ReadOnly]
private SEManager scriptSEManager;

this.objectSEManager = GameObject.FindWithTag("SEManager");
this.scriptSEManager = this.objectSEManager.GetComponent<SEManager>();

this.scriptSEManager.();

 */
