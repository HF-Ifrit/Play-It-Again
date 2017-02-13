using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3(player.transform.position.x,player.transform.position.y,transform.position.z);
	}
}
