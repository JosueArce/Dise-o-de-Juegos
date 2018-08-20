using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveEnemy : MonoBehaviour {
    public Transform player;
    public float velocity = 0.3f;
    float rotSpeed = 0.1f;
    static Animator anim;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	// Update is called once per frame
	void Update ()
    {
        if (Vector3.Distance(player.position, this.transform.position) < 10)
        {
            Vector3 direccion = player.position - this.transform.position;
            direccion.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direccion), 0.1f);
            /*this.transform.position = Vector3.MoveTowards(transform.position, player.position,
                velocity * Time.deltaTime);*/
            anim.SetBool("isIdle", false);
            if (direccion.magnitude > 1)
            {
                this.transform.Translate(0, 0, 0.05f);
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);

            }
            else
            {
                anim.SetBool("isAttacking", true);
                anim.SetBool("isWalking", false);
            }
        }
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isAttacking", false);
            anim.SetBool("isWalking", false);
        }
    }
}
