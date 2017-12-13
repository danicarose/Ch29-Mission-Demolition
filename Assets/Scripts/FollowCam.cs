using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {

    public float easing = .05f;
    public Vector2 minXY;
    static public FollowCam S; //use of Singleton
    public GameObject poi;
    public float camZ;
    public Camera cam;
    Rigidbody rb;

    private void Awake()
    {
        S = this;
        camZ = this.transform.position.z;
    }

    private void FixedUpdate()
    {
        Vector3 destination;
        if (poi == null)
        {
            destination = Vector3.zero;
        } else
        {
            destination = poi.transform.position;
            if(poi.tag == "Projectile")
            {
                rb = poi.GetComponent<Rigidbody>();
                if (rb.IsSleeping())
                {
                    poi = null;
                    return;
                }
            }
        }
    }
    // Update is called once per frame
    void Update () {
        if (poi == null) return;
        Vector3 destination = poi.transform.position;
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);
        destination = Vector3.Lerp(transform.position, destination, easing); //easing through interpolation and limits on the camera's location
        destination.z = camZ;
        transform.position = destination;
        cam = this.GetComponent<Camera>();
        cam.orthographicSize = destination.y + 10;
	}
<<<<<<< HEAD
=======

    void FixedUpdate () {
        Vector3 destination;

        //If there is no poi, return to P:[0,0,0]
        if(poi == null)
        {
            destination = Vector3.zero;
        }
        else
        {
            //Get the position of the poi
            destination = poi.transform.position;
            
            //If poi is a Projectile, check to see if it's at rest
            if(poi.tag == "Projectile")
            {
                //if it is sleeping (that is, not moving)
                if (poi.GetComponent<Rigidbody>().IsSleeping())
                {
                    //return to default view
                    poi = null;
                    //in the next update
                    return;
                }
            }
        }

		//Limit the X & Y to minimum values 
		destination.x = Mathf.Max(minxXY.x, destination.x); //THIS LINE WAS CHANGED BC OLD CODE DNE 
		destination.y = Mathf.Max(minxXY.y, destination.y); //ALSO CHANGED 

		//Interpolate from the current Camera position toward destination
		destination = Vector3.Lerp(transform.position, destination, easing); //NOTE: A Lerp is a linear interpolation

		// Retain a destination.z of camZ
		destination.z = camZ;

		// Set the camera to the destination
		transform.position = destination;

		//Set the orthographicSize of the Camera to keep Ground in view
		this.GetComponent<Camera>().orthographicSize = destination.y + 10; //ALSO CHANGED 
	}


>>>>>>> db32a70c998e0cacac092876bd91db774cc592b2
}
