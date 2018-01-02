using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public string buttonTagP1;
	public string buttonTagP2;
	public ShipController shipControllerP1;
    public ShipController shipControllerP2;
    public PirateController pirateControllerP1;
    public PirateController pirateControllerP2;
    public ShootController shootControllerP1;
    public ShootController shootControllerP2;
    public ReloadController reloadControllerP1;
    public ReloadController reloadControllerP2;
    public AudioSource music;
    public AudioSource endGame;
    public ParticleSystem confetiP1;
    public ParticleSystem confetiP2;
    public ParticleSystem rainyP1;
    public ParticleSystem rainyP2;
	public RectTransform bannerP1;
	public RectTransform bannerP2;
    public RectTransform draw;

    private bool first = true;

    private void Update() {

        if (isGameOver() && first) {
            music.Stop();
            endGame.Play();
            first = false;
            StartCoroutine(Wait(3)); //wait for press action button
        }

		if (Input.GetKey (KeyCode.Escape))
			Application.Quit ();
			
    }

    private bool isGameOver() {

        bool over = false;

        if (shipControllerP1.getMeterValue() == 1 && shipControllerP2.getMeterValue() == 1) {
            over = true;
            confetiP1.gameObject.SetActive(true);
            confetiP2.gameObject.SetActive(true);

			draw.gameObject.SetActive (true);
        } else if (shipControllerP1.getMeterValue() == 1) {
            over = true;
            confetiP2.gameObject.SetActive(true);
			bannerP2.gameObject.SetActive (true);
            rainyP1.gameObject.SetActive(true);
        } else if (shipControllerP2.getMeterValue() == 1) {
            over = true;
            rainyP2.gameObject.SetActive(true);
            confetiP1.gameObject.SetActive(true);
			bannerP1.gameObject.SetActive (true);
        }

        if (over) {
            shipControllerP1.gameOver = true;
            pirateControllerP1.gameOver = true;
            shootControllerP1.gameOver = true;
            reloadControllerP1.gameOver = true;
            shipControllerP2.gameOver = true;
            pirateControllerP2.gameOver = true;
            shootControllerP2.gameOver = true;
            reloadControllerP2.gameOver = true;
            return true;
        }
        

        return false;
    }

    private IEnumerator Wait(float seconds) {

        yield return new WaitForSeconds(seconds);

        while (true) {

			if (Input.GetButtonDown(buttonTagP1) || Input.GetButtonDown(buttonTagP2)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
            }

            yield return null;

        }
    }
}
