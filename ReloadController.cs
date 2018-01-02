using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadController : MonoBehaviour {

    private const int CHARGER_LAYER = 10;
    private Animator animator;

	public CanonController canonController;
	public CubeController cubeController;
    [HideInInspector] public bool gameOver = false;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.layer == CHARGER_LAYER) {
            if (!canonController.IsFull() && cubeController.IsFull() && !gameOver)
            {
                cubeController.DrainAll();
				animator.SetBool("PlayerCubeFull", false);
                canonController.Reload();
            }
            else
                canonController.CanonAdvertisement();
        }
	}
}
