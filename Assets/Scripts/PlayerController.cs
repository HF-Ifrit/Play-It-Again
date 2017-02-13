using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public GameObject menuPanel;
    public float speed = 50;
    private Rigidbody2D _rb;
    private Animator _playerAnim;

    // Use this for initialization
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Menu input - Character presses C key to reveal and hide menu options
        if (Input.GetKeyUp(KeyCode.C))
            menuPanel.SetActive(!menuPanel.activeInHierarchy);

        //Player movement - Move based on players input keys
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * speed;

        //Change Animator's Direction value based on which direction the player is inputting
        if (movement.x > 0)
            _playerAnim.SetInteger("Direction", 2);
        else if (movement.x < 0)
            _playerAnim.SetInteger("Direction", 4);

        if (movement.y > 0)
            _playerAnim.SetInteger("Direction", 1);
        else if (movement.y < 0)
            _playerAnim.SetInteger("Direction", 3);

        //Freeze player if the menu is open
        if (!menuPanel.activeInHierarchy)
            _rb.velocity = movement;
        else
            _rb.velocity = Vector3.zero;
    }
}
