using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	public float health = 50f;
	public Animator anim;

	public void TakeDamage(float amount) {
		health -= amount;
		if(health <= 0f){
			Die();
		}
	}

	void Die(){
		anim.SetBool("isDead",true);
		anim.SetBool("isIdle",false);
		anim.SetBool("isWalking",false);
		anim.SetBool("isAttacking",false);
		Destroy(gameObject, 4f);
	}
}
