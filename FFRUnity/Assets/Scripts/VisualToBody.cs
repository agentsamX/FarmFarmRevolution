using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualToBody : MonoBehaviour
{
   
    public Transform target;
    void Update()
    {
        transform.position = target.position;
        transform.rotation = Quaternion.identity;
    }
}
