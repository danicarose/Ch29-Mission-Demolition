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
}
