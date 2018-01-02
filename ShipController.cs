using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MeterController {

    public List<float> floors = new List<float>(new float[] {0.3f,0.3f,0.15f, 1});
    public List<float> realDistBetFloors = new List<float>(new float[] { 0.63f, -0.28f, -0.68f, -1 });
    public float plungeTime = 2.5f;
    public ParticleSystem plungeParticles;
    [HideInInspector] public bool gameOver = false;

    private Animator animator;
    private float actualLimitDown = 0.15f;
    private float actualLimitUp = 0.0f;
    private int actualFloor = 0;
    private bool ocuped = false;
    private float y;


    void Start() {
        actualLimitUp = actualLimitDown + floors[0];
		StartCoroutine(PlungeInSeconds());


    }

	// Update is called once per frame
	void Update () {
        CheckShipStatus();
    }

    public void Plunge() {
		if (!IsFull() && meter.fillAmount < actualLimitUp && !gameOver) {
            ocuped = true;
            IncreaseMeter();
            ocuped = false;
        }
    }

    public void PlungeRandom() {
        if (!IsFull() && meter.fillAmount < actualLimitUp && !gameOver) {
            ocuped = true;
            IncreaseMeterRandom();
            ocuped = false;
        }

    }

    public void Drift() {
		if (!IsEmpty() && meter.fillAmount != actualLimitDown && !gameOver) {
            ocuped = true;
            DecreaseMeter();
            ocuped = false;
        }
    }

    public void CheckShipStatus() {
		if (meter.fillAmount > actualLimitUp && actualFloor < floors.Capacity-1) {
            //animator.SetTrigger("ShipPlunge");
            actualLimitDown += floors[actualFloor];
            actualFloor++;
            transform.position = new Vector2(transform.position.x, realDistBetFloors[actualFloor]);
            successIncreaseAS.Play();
            plungeParticles.Play();
            actualLimitUp += floors[actualFloor];
            
        }
    }

    private IEnumerator PlungeInSeconds() {

        while(true) {
			yield return new WaitForSeconds(plungeTime);
            if (ocuped) {
                yield return null; //wait 1 frame
            }
            ocuped = true;
            Plunge();
            ocuped = false;
        }
    }

    /*private IEnumerator AnimationBoing() {

        while (true)
        {
            transform.position = new Vector2(transform.position.x, boingCurve.Evaluate(time2));
            time2 += Time.deltaTime;
            if (time2 >= 1)
                time2 = 0;
            yield return null;
        }
    }

    private IEnumerator AnimationOfPlungeShip() {

        
        while (time <= 1) {
            transform.position = new Vector2(transform.position.x, plungeCurve.Evaluate(time));
            time += Time.deltaTime;
            yield return null;
        }
        time = 0;
    } */
}
