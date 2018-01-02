using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class InitInterfaceManager : MonoBehaviour {
	public Animator animator;

     void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }


    void Update () {
		if (Input.anyKey) {
			animator.SetTrigger ("InitGame");
		}
	}
	public void InitGame() {
			SceneManager.LoadScene ("_Scenes/Fali" ,LoadSceneMode.Single);
	}
}
