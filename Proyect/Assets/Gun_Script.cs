﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Script : MonoBehaviour {

	// Use this for initialization
	public float damage = 10f;
	public float range = 100f;
	public Camera fpsCam;
	public ParticleSystem muzzelFlash;
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButtonDown("Fire1")){
			Shoot();
		}
		
	}

	void Shoot(){
		muzzelFlash.Play();
		RaycastHit hit;
		if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)){
			Debug.Log(hit.transform.name);

			Enemy enemy = hit.transform.GetComponent<Enemy>();
			if(enemy != null){
				enemy.TakeDamage(damage);
			}
		}
	}
}
