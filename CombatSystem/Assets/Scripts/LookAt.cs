using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [Tooltip("The transform this object should look at")]
    [SerializeField] private Transform target;

    private void Start()
    {
        if (target == null)
        {
            target = FindObjectOfType<CustomController>().transform;
        }  
    }


    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);   
    }
}
