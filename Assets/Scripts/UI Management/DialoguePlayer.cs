using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialoguePlayer : MonoBehaviour
{
    public GameObject nameText;
    public GameObject diaText;
    public GameObject panel;
    private string _displayName;
    private string _displayDialogue;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Store information about our npc
    public void GetNPCInfo(string name, string dialogue)
    {
        _displayName = name;
        _displayDialogue = dialogue;
    }

    //Store npc information in respective UI textboxes; Reveal panel to show dialogue
    public void PlayDialogue()
    {
        nameText.GetComponent<Text>().text = _displayName;
        diaText.GetComponent<Text>().text = _displayDialogue;

        panel.SetActive(true);
    }

    //Hide panel when done with dialogue
    public void EndDialogue()
    {
        panel.SetActive(false);
    }
}
