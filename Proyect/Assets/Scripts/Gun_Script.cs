using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Script : MonoBehaviour {

	// Use this for initialization
	public float damage = 10f;
	public float impactForce = 30f;
	public float fireRate = 15f;
	public float range = 100f;

	public int maxAmmo = 10;
	private int currentAmmo = -1;
	public float reloadTime = 2.5f;
	private bool isReloading = false;

	public Camera fpsCam;
	public ParticleSystem muzzelFlash;
	public GameObject bloodFX;
	public GameObject holeFX;

	private float nextTimeToFire = 0f;
	public Animator animator;

	void Start(){
		if(currentAmmo == -1){
			currentAmmo = maxAmmo;
		}
	}

	void OnEnable(){
		isReloading = false;
		animator.SetBool("reloading",false);
	}

    // Update is called once per frame
    void Update () {
		if(isReloading){
			return;
		}
		animator.SetBool("idle",true);
		if(currentAmmo <= 0){
			animator.SetBool("idle",false);
			StartCoroutine(Reload());
			return;
		}

		if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire){
			animator.SetBool("idle",false);
			nextTimeToFire = Time.time + 1f/fireRate;
			Shoot();
		}
		
	}

	void Shoot(){
		muzzelFlash.Play();
		currentAmmo --;
		RaycastHit hit;
		animator.SetBool("shooting",true);
		if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)){
			Debug.Log(hit.transform.name);

			Enemy enemy = hit.transform.GetComponent<Enemy>();
			if(enemy != null){
				enemy.TakeDamage(damage);
			}
			if(hit.rigidbody != null){
				hit.rigidbody.AddForce(-hit.normal * impactForce);
			}
			if(hit.transform.tag=="Dummie"){
				Instantiate(bloodFX, hit.point, Quaternion.LookRotation(hit.normal));
			}
			if(hit.transform.tag=="LevelPart"){
				Instantiate(holeFX, hit.point, Quaternion.LookRotation(hit.normal));
			}	
			animator.SetBool("shooting",false);
			animator.SetBool("idle",true);
		}
		animator.SetBool("shooting",false);
		animator.SetBool("idle",true);
	}

	IEnumerator Reload(){
		isReloading = true;
		animator.SetBool("reloading",true);
		yield return new WaitForSeconds(reloadTime -0.25f);
		animator.SetBool("reloading",false);
		yield return new WaitForSeconds(0.25f);
		currentAmmo = maxAmmo;
		isReloading = false;
	}
}
