using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsController : MonoBehaviour {
	private const int STAIRS_LAYER = 9;
	private MovementController movementController;
	private Rigidbody2D rb;
	private float gravityScale;

	void Start() {
		movementController = gameObject.GetComponent<MovementController> ();
		rb = GetComponent<Rigidbody2D> ();
		gravityScale = rb.gravityScale;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.layer == STAIRS_LAYER) {
			rb.gravityScale = 0;
			movementController.SetOnStairs(true);
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if(other.gameObject.layer == STAIRS_LAYER) {
			movementController.SetOnStairs(true);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.layer == STAIRS_LAYER) {
			movementController.SetOnStairs(false);
			rb.gravityScale = gravityScale;
		}
	}
}
