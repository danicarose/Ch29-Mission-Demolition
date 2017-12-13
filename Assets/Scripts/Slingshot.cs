﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour {

    static public Slingshot S;

    public GameObject prefabProjectile;
    public float velocityMult = 4f;
	public GameObject launchPoint;
    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;
    public Rigidbody rb;

	void Awake(){
        S = this;

		Transform launchPointTrans = transform.Find ("LaunchPoint");
		launchPoint = launchPointTrans.gameObject;
		launchPoint.SetActive(false);
        launchPos = launchPointTrans.position;
	}

	void OnMouseEnter(){
		//print ("Slingshot:OnMouseEnter()");
		launchPoint.SetActive(true);
	}

	void OnMouseExit(){
		//print ("Slingshot:OnMouseExit()");
		launchPoint.SetActive(false);
	}

    private void OnMouseDown()
    {
        aimingMode = true;
        projectile = Instantiate(prefabProjectile) as GameObject;
        projectile.transform.position = launchPos;
        rb = projectile.GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    public void Update()
    {
        if (!aimingMode) return;
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 mouseDelta = mousePos3D - launchPos;
        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if(mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }

        if (Input.GetMouseButtonUp(0))
        {
            aimingMode = false;
            rb = projectile.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.velocity = -mouseDelta * velocityMult;
            FollowCam.S.poi = projectile; //application of singleton S
            projectile = null;
        }
    }
}
