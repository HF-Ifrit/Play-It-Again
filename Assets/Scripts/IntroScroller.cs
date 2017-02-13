using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class IntroScroller : MonoBehaviour {
	public float speed;
	public float time1, time2;

	// Use this for initialization
	void Start () {
        /*
        time1 = 53.0f;
		time2 = 5.0f;
        */
	}
	
	// Update is called once per frame
	void Update () {
		if (time1 > 0) {
			time1 -= Time.deltaTime;
			this.transform.Translate (0, -speed, 0);
		} else {
			if (time2 > 0) {
				time2 -= Time.deltaTime;
			} else {
                if (SceneManager.GetActiveScene().name == "Intro")
                    SceneManager.LoadScene("AmadiaTown");
                else
                    SceneManager.LoadScene("Credits");
			}
		}
	}
}
