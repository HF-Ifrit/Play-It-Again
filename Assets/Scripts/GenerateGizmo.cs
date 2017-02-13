using UnityEngine;
using System.Collections;

public class GenerateGizmo : MonoBehaviour
{
#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        UnityEditor.Handles.Label(transform.position, gameObject.name);
    }
#endif
}
