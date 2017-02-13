using UnityEngine;
using System.Collections;
//**************************************************NEEDS TO BE FIXED
public class CanvasCloser : MonoBehaviour
{
    private RectTransform[] _canvasObjects;
    private bool[] _activeStates;

	// Use this for initialization
	void Start ()
    {
        
        //Gets all the canvas objects at the beginning of the scene and their current active states
        _canvasObjects = GetComponentsInChildren<RectTransform>();
        _activeStates = new bool[_canvasObjects.Length];
        for (int i = 0; i < _activeStates.Length; i++)
            _activeStates[i] = _canvasObjects[i].gameObject.activeInHierarchy;

        Debug.Log("Initial Menu States Found\nCanvas Objects: " + _activeStates.Length);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //When Escape key is pressed, set all the canvas objects to their original active states, thus "closing" the menu
        if (Input.GetKey(KeyCode.Escape))
        {
            for (int i = 0; i < _canvasObjects.Length; i++)
                _canvasObjects[i].gameObject.SetActive(_activeStates[i]);
            Debug.Log("Menu Cleared");
        }
	}
}
