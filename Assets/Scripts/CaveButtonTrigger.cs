using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CaveButtonTrigger : MonoBehaviour
{
    public Material pushedColor;
    public GameObject gate;
    public GameObject nameText;
    public GameObject dialogueText;
    public GameObject dialoguePanel;

    private Renderer _rend;
	// Use this for initialization
	void Start () {
        _rend = GetComponentInParent<Renderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            _rend.material = pushedColor;
            StartCoroutine(NotifyPlayer(col));
            GameManager.Manager.loweredGate = true;
        }
    }


    IEnumerator NotifyPlayer(Collider2D col)
    {
        col.gameObject.GetComponent<PlayerController>().enabled = false;
        col.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        nameText.GetComponent<Text>().text = "Floor Button";
        dialogueText.GetComponent<Text>().text = "You step on the button and hear rocks shifting somewhere else in the cave";
        dialoguePanel.SetActive(true);
        yield return new WaitForSeconds(5f);
        dialoguePanel.SetActive(false);
        col.gameObject.GetComponent<PlayerController>().enabled = true;
    }
}
