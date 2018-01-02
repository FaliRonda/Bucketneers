using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShootController : MonoBehaviour {
	private const int CANON_CONTROLLER = 8;
	private PirateController pirateController;

	public string buttonTag;
	public CanonController canonController;
    [HideInInspector] public bool gameOver = false;

	private void Start(){
		pirateController = GetComponent<PirateController> ();
        StartCoroutine(Wait());
    }

	void OnTriggerEnter2D(Collider2D other) {
		bool playerOnCanon = other.gameObject.layer == CANON_CONTROLLER;
		pirateController.setOnCanon (playerOnCanon);
	}

	void OnTriggerExit2D(Collider2D other) {
		pirateController.setOnCanon (false);
	}

    private IEnumerator Wait()
    {
        while(true) {
            if (pirateController.getOnCanon() && Input.GetButtonDown(buttonTag) && !gameOver)
            {
                canonController.Shoot();
            }
            yield return null;
        }
    }
}
