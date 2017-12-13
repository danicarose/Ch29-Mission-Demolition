using System.Collections;
<<<<<<< HEAD
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLine : MonoBehaviour {

    static public ProjectileLine S;

    public float minDist = .1f;
    public LineRenderer line;
    private GameObject _poi;
    public List<Vector3> points;
    Rigidbody rb;

    private void Awake()
    {
        S = this;
        line = GetComponent<LineRenderer>();
        line.enabled = false;
        points = new List<Vector3>();
    }

=======
using System.Collections.Generic; //this line is needed to use Lists
using UnityEngine;

public class ProjectileLine : MonoBehaviour {
    static public ProjectileLine S; //Singleton

    //fields set in the Unity Inspector pane
    public float minDist = 0.1f;
    public bool ____________________________;

    //fields set dynamically
    public LineRenderer line;
    private GameObject _poi;
    public List<Vector3> points;

    private void Awake()
    {
        S = this; //Set the singleton

        //Get a reference to the LineRenderer
        line = GetComponent<LineRenderer>();

        //Disable the LineRenderer until it's needed
        line.enabled = false;

        //Initialize the points list
        points = new List<Vector3>();
    }

    //This is a property (that is, a method masquerading as a field)
>>>>>>> db32a70c998e0cacac092876bd91db774cc592b2
    public GameObject poi
    {
        get
        {
            return (_poi);
<<<<<<< HEAD
        } 
        set
        {
            _poi = value;
            if (_poi != null)
            {
=======
        }
        set
        {
            _poi = value;
            if(_poi != null)
            {
                //When _poi is set to something new, it resets everything 
>>>>>>> db32a70c998e0cacac092876bd91db774cc592b2
                line.enabled = false;
                points = new List<Vector3>();
                AddPoint();
            }
        }
    }

<<<<<<< HEAD
=======
    //This can be used to clear the line directly 
>>>>>>> db32a70c998e0cacac092876bd91db774cc592b2
    public void Clear()
    {
        _poi = null;
        line.enabled = false;
        points = new List<Vector3>();
    }

    public void AddPoint()
    {
<<<<<<< HEAD
        Vector3 pt = _poi.transform.position;
        if (points.Count > 0 && (pt - lastPoint).magnitude < minDist)
        {
            return;
        }
        if (points.Count == 0)
        {
            Vector3 launchPos = Slingshot.S.launchPoint.transform.position;
            Vector3 launchPosDiff = pt - launchPos;
            points.Add(pt + launchPosDiff);
            points.Add(pt);
            line.SetVertexCount(2);
            line.SetPosition(0, points[0]);
            line.SetPosition(0, points[1]);
            line.enabled = true;
        }
        else
        {
=======
        //This is called to add a point to the line 
        Vector3 pt = _poi.transform.position;
        if (points.Count > 0 && (pt - lastPoint).magnitude < minDist)
        {
            //If the point isn't far enough from the last point, it returns
            return;
        }
        if(points.Count == 0)
        {
            //If this is the launch point...
            Vector3 launchPos = Slingshot.S.launchPoint.transform.position;
            Vector3 launchPosDiff = pt - launchPos;

            //...it adds an extra bit of line to aid aiming later
            points.Add(pt + launchPosDiff);
            points.Add(pt);
            line.SetVertexCount(2);

            //Sets the first two points
            line.SetPosition(0, points[0]);
            line.SetPosition(1, points[1]);

            //Enables the LineRenderer
            line.enabled = true;

        }
        else
        {
            //Normal behavior of adding a point
>>>>>>> db32a70c998e0cacac092876bd91db774cc592b2
            points.Add(pt);
            line.SetVertexCount(points.Count);
            line.SetPosition(points.Count - 1, lastPoint);
            line.enabled = true;
        }
    }

<<<<<<< HEAD
=======
    //Returns the location of the most recently added point
>>>>>>> db32a70c998e0cacac092876bd91db774cc592b2
    public Vector3 lastPoint
    {
        get
        {
<<<<<<< HEAD
            if(points == null)
            {
                return (Vector3.zero);
=======
            if (points == null)
            {
                //If there are no points, returns Vector3.zero
                return (points[points.Count - 1]);
>>>>>>> db32a70c998e0cacac092876bd91db774cc592b2
            }
            return (points[points.Count - 1]);
        }
    }

<<<<<<< HEAD
    private void FixedUpdate()
    {
        if(poi == null)
        {
            if (FollowCam.S.poi != null)
            {
                if (FollowCam.S.poi.tag == "Projectile")
=======
    void FixedUpdate()
    {
       if(poi == null)
        {
            //If there is no poi, search for one
            if(FollowCam.S.poi != null)
            {
                if(FollowCam.S.poi.tag == "Projectile")
>>>>>>> db32a70c998e0cacac092876bd91db774cc592b2
                {
                    poi = FollowCam.S.poi;
                }
                else
                {
<<<<<<< HEAD
                    return;
=======
                    return; //Return if we didn't find a poi
>>>>>>> db32a70c998e0cacac092876bd91db774cc592b2
                }
            }
            else
            {
                return;
            }
        }
<<<<<<< HEAD
        AddPoint();
        rb = poi.GetComponent<Rigidbody>();
        if (rb.IsSleeping())
        {
            poi = null;
        }
    }
=======
        //If there is a poi, it's loc is added every FixedUpdate
        AddPoint();
        if (poi.GetComponent<Rigidbody>().IsSleeping())
        {
            //Once the poi is sleeping,it is cleared
            poi = null;
        }
    }
    
>>>>>>> db32a70c998e0cacac092876bd91db774cc592b2
}
