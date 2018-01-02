using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boing : MonoBehaviour
{


    public AnimationCurve curva;
    public float tiempo;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, curva.Evaluate(tiempo));
        tiempo += Time.deltaTime * 0.5f;
        //if (tiempo > 1)
        //{
          //  tiempo = 0;
        //}
    }
}
