using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonController : MeterController {
    public ParticleSystem particles;
	public ShipController shipController;
    public Animator smallChargerAnimator;

	private ShootChargerController shootChargerController;
    private Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
		shootChargerController = GetComponent<ShootChargerController> ();
    }

	public bool Shoot() {
		bool result = false;

		if (shootChargerController.IsFull ()) {
			shootChargerController.ShootCharge ();
			animator.SetTrigger ("CanonShoot");
            smallChargerAnimator.SetTrigger("CanonShoot");

            particles.Play();
            if (!successDecreaseAS.isPlaying)
                successDecreaseAS.Play(); //shoot of water

			StartCoroutine (WaitAndShoot ());

			result = DecreaseMeter ();

			if (result) {
				shootChargerController.ReloadCharge ();
			}
		} else {
			CanonAdvertisement ();
            if (!failDecreaseAS.isPlaying)
                failDecreaseAS.Play(); //empty pistol
        }
        return result;
    }

	private IEnumerator WaitAndShoot() {
		yield return new WaitForSeconds(0.5F);
		shipController.PlungeRandom ();
	}

    public bool Reload() {
        bool result = IncreaseMeter();

        if (result) {
            successIncreaseAS.pitch = 2;
            if (!successIncreaseAS.isPlaying)
                successIncreaseAS.Play(); //blup
			animator.SetTrigger("CanonReload");

			if (shootChargerController.IsEmpty ()) {
				shootChargerController.ReloadCharge ();
				DecreaseMeter ();
			}
        }
        else {
            successIncreaseAS.pitch = 2;
            successIncreaseAS.Play(); //deep blup
            CanonAdvertisement();
        }

        return result;
    }

    public void CanonAdvertisement() {
        animator.SetTrigger("CanonCant");
    }
}
