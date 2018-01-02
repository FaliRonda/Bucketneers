using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateController : MonoBehaviour {
    public CubeController cubeController;
	public float canBailHeight = -3F;
	public string bailButtonTag;
    public bool onWater = false;
    public AudioSource splash;
    public AudioSource seriousDrip;
    public AudioSource hitWood;
    public ParticleSystem splashParticles;
    [HideInInspector] public bool gameOver = false;

    private Animator animator;
	private bool onCanon = false;

    private void Start() {
        animator = GetComponent<Animator>();
    }

	private void Update(){
		onWater = transform.position.y < canBailHeight;
		if (Input.GetButtonDown (bailButtonTag)) {
			Bail (onWater);
		}
	}

    private void Bail(bool onWater) {
		if (!onCanon && !gameOver) {
			if (onWater) {
				bool refilled = cubeController.Refill ();

				if (refilled) {
					animator.SetTrigger ("PlayerRefill");
                    splashParticles.Play();
					if(!splash.isPlaying) splash.Play();

					if (cubeController.IsFull ())
						animator.SetBool ("PlayerCubeFull", true);
				} else {
                    splashParticles.Play();
                    if (!seriousDrip.isPlaying) seriousDrip.Play();
				}
			} else if (cubeController.IsFull ()) {
                splashParticles.Play();
                if (!seriousDrip.isPlaying) seriousDrip.Play();
            } else {
				animator.SetTrigger ("PlayerRefill");
				if(!hitWood.isPlaying) hitWood.Play();
			}
		}
    }

	public void setOnCanon(bool value) {
		onCanon = value;
	}

	public bool getOnCanon() {
		return onCanon;
	}
}
