using UnityEngine;
using System.Collections;

public class Talkable : MonoBehaviour
{
    public string npcName;
    public string npcDialogue;
    private DialoguePlayer _dialoguePlayer;

    // Use this for initialization
    void Start ()
    {
        _dialoguePlayer = GameObject.FindGameObjectWithTag("DManager").GetComponent<DialoguePlayer>();
    }

    //Assign this npc's name and dialogue to the dialogue manager and reveal the text panel
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            _dialoguePlayer.GetNPCInfo(npcName,npcDialogue);
            _dialoguePlayer.PlayDialogue();
        }
    }
    
    //Close the text panel when leaving the npc's dialogue zone
    void OnTriggerExit2D(Collider2D col)
    {
        _dialoguePlayer.EndDialogue();
    }
}
