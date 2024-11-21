using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; //This gives us access to UnityEvent


public class EventOnInput : MonoBehaviour
{
    //this will tell our script what type of input to listen for
    public enum InputType
    {
        Down,
        Held,
        Released
    }

    [SerializeField] InputType type;
    [SerializeField] private KeyCode triggerKey;
    [SerializeField] private UnityEvent onTrigger;
    // Update is called once per frame
    void Update()
    {
        switch (type)
        {
            case InputType.Down:
                if(Input.GetKeyDown(triggerKey))
                {
                    onTrigger?.Invoke();
                }
                break;
            case InputType.Held:
                if (Input.GetKey(triggerKey))
                {
                    onTrigger?.Invoke();
                }
                break;
            case InputType.Released:
                if (Input.GetKeyUp(triggerKey))
                {
                    onTrigger?.Invoke();
                }
                break;
        }

        if (Input.GetKeyUp(triggerKey))
        {
            onTrigger.Invoke();
        }
    }
}
