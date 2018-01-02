using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeController : MeterController {
	public ShipController shipController;

	public bool Drain() {
		bool drained = DecreaseMeter ();

		if (drained) {
			//successDecreaseAS.Play ();
		}

		return drained;
	}

	public bool Refill() {
		bool refilled = IncreaseMeter ();

		if (refilled) {
			//successIncreaseAS.Play ();

			if (IsFull()) {
				shipController.Drift ();
			}
		}

		return refilled;
	}

	public void DrainAll() {
		meter.fillAmount = 0;
    }
}
