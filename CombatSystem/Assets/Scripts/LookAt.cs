using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [Tooltip("The transform this object should look at")]
    [SerializeField] private Transform target;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);   
    }
}
