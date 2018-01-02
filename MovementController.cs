using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {
	private Rigidbody2D rb;
	private float lastHorizontalMovementValue;
	private float lastVerticalMovementValue;
	private SpriteRenderer sprite;
	private bool onStairs = false;
	private float gravityScale;
	private Animator animator;
    private PirateController pirateController;

	public string horizontalInputTag;
	public string verticalInputTag;
	public float speed = 1.5F;
	public float horizontalMovementOffset = 0.01F;
	public float verticalMovementOffset = 0.1F;
	[Range(0.1F, 0.9F)]
	public float stairsFactor = 0.5F;
    public AudioSource audioWalkingWater;
    public AudioSource audioWalkingWood;
	public bool flipCondition = true;


    void Start() {
		rb = GetComponent<Rigidbody2D> ();
		sprite = GetComponent<SpriteRenderer> ();
		animator = GetComponent<Animator> ();
        pirateController = GetComponent<PirateController>();
	}

	void FixedUpdate () {
		float horizontalInput = Input.GetAxis (horizontalInputTag);
		float verticalInput = Input.GetAxis (verticalInputTag);

		float horizontalMovement = 0;
		float verticalMovement = 0;

        animator.SetFloat("PlayerRun", Mathf.Abs(horizontalInput));

        if (Mathf.Abs(horizontalInput) > horizontalMovementOffset && Mathf.Abs(horizontalInput) >= Mathf.Abs(lastHorizontalMovementValue)) {
			//play sounds
			if(!audioWalkingWood.isPlaying && !audioWalkingWater.isPlaying){
				if (pirateController.onWater)
					audioWalkingWater.Play();
				else
					audioWalkingWood.Play();
			}

			if (horizontalInput > 0) {
				horizontalMovement = 1;
				sprite.flipX = flipCondition;
			} else {
				horizontalMovement = -1;
				sprite.flipX = !flipCondition;
			}
		}

		lastHorizontalMovementValue = horizontalInput;

		if(onStairs && Mathf.Abs(verticalInput) > verticalMovementOffset && Mathf.Abs(verticalInput) >= Mathf.Abs(lastVerticalMovementValue)) {
			if (verticalInput > 0) {
				verticalMovement = 1;
			} else {
				verticalMovement = -1;
			}
		}

		lastVerticalMovementValue = verticalInput;

		if(onStairs)
			horizontalMovement *= stairsFactor;

		rb.velocity = new Vector2 (horizontalMovement * speed, verticalMovement * speed * stairsFactor);
	}

	public void SetOnStairs(bool value){
		onStairs = value;
	}
}
