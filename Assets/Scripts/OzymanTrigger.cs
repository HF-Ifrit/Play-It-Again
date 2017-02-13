using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class OzymanTrigger : MonoBehaviour
{
    public GameObject nameText;
    public GameObject dialogueText;
    public GameObject dialoguePanel;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
            StartCoroutine(NotifyPlayer(col));
    }

    IEnumerator NotifyPlayer(Collider2D col)
    {
        col.gameObject.GetComponent<PlayerController>().enabled = false;
        col.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        nameText.GetComponent<Text>().text = "Ozyman";
        dialogueText.GetComponent<Text>().text = "Did you just slaughter my cave beasts?" 
            + "You know how hard it is to find good help these days?"
            + "Those were some of the best guard beasts I’ve ever had."
            + "Damn brats. If you’re gonna barge in here and ruin my whole setup, you’re gonna have to pay for it!";
        dialoguePanel.SetActive(true);
        yield return new WaitForSeconds(7f);
        dialoguePanel.SetActive(false);
        col.gameObject.GetComponent<PlayerController>().enabled = true;
        SceneManager.LoadScene("OzymanFight");
    }
}
