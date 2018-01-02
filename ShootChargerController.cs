using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootChargerController : MeterController {
	public void ShootCharge () {
		DecreaseMeter ();
	}
	
	public void ReloadCharge () {
		IncreaseMeter ();
	}
}
