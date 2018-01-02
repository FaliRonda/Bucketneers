using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientonice : MonoBehaviour {

    // Use this for initialization
    public float Speed;
	void Start () {
        Speed = 4;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-transform.right * Speed * Time.deltaTime, Space.World);
    }
}
