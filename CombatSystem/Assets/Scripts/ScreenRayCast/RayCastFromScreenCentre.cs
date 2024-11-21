using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastFromScreenCentre : MonoBehaviour
{
    [Tooltip("The physics layer to try to hit with this raycast")]
    [SerializeField] private LayerMask hitLayer;


    [Tooltip("The maximum distance this raycast can travel")]
    [SerializeField] private float maxDistance;

    //hold a reference to our camera selector, so we know which camera is in use
    private CameraSelector cameraSelctor;

    //protected = like private, but child scripts can see
    //virtual = lets a child script override this function with its own version
    protected virtual void Start()
    {
        cameraSelctor = FindObjectOfType<CameraSelector>();
    }

    public RaycastHit TryToHit()
    {
        //a struct cannot be "null", so we initialise an empty struct instead
        RaycastHit hit = new RaycastHit(); 

        //get the currently used camera
        Camera camera = cameraSelctor.GetCamera();

        //use half the camera width and heigh to determine the screen centre, and cast a ray from there
        Ray ray = camera.ScreenPointToRay(new Vector3(camera.pixelWidth, camera.pixelHeight) * 0.5f);

        if (Physics.Raycast(ray, out hit, maxDistance, hitLayer))
        {
            return hit;
        }

        //if we hit nothing, record the furthest point we *could* have hit
        hit.point = ray.origin + ray.direction * maxDistance;

        //then we can return the otherwise empty hit
        return hit;
    }
}
