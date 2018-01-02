using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MeterController : MonoBehaviour {
	[SerializeField]
	protected Image meter;

	public float increaseRatio = 0.1f;
	public float decreaseRatio = 0.1f;

	public AudioSource successIncreaseAS;
	public AudioSource failIncreaseAS;

	public AudioSource successDecreaseAS;
	public AudioSource failDecreaseAS;

	protected bool IncreaseMeter () {
		bool result = meter.fillAmount < 1;
		if (result) meter.fillAmount += increaseRatio;
		return result;
	}

    protected bool IncreaseMeterRandom() {
        bool result = meter.fillAmount < 1;
        if (result) meter.fillAmount += Random.Range(0.1f,0.2f);
        return result;
    }

    protected bool DecreaseMeter () {
		bool result = meter.fillAmount > 0;
		if (result) meter.fillAmount -= decreaseRatio;
		return result;
	}

	public bool IsFull(){
		return meter.fillAmount == 1;
	}

	public bool IsEmpty(){
		return meter.fillAmount == 0;
	}

    public float getMeterValue() {
        return meter.fillAmount;
    }
}
