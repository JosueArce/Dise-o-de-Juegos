using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingHealth : MonoBehaviour {


    public Texture text1;
    public Texture text2;
    public Texture text3;
    public Texture text4;

    float health = 100.0f;
    float maxHealth = 100.0f;
    private bool enterCollider = false;


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            enterCollider = true;
            Debug.Log("Player is Inside collider");
        }
    }


    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            enterCollider = false;
            Debug.Log("Player is outside collider");
        }
    }

    private void Update()
    {
        //health coundown whilst in the damage collider
        if(health > 0 && enterCollider)
        {
            health -= Time.deltaTime;
        }
        //health regeneration 
        if (health >= 0 && !enterCollider)
        {
            health += Time.deltaTime;
        }
        //when health reaches 100, set
        // to maxHealth avoid problems
        if (health > maxHealth)
        {
            health = maxHealth;
        }

    }

    private void OnGUI()
    {
        if (health < 100)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), text3);
        }
        if (health < 90)
        {
            GUI.DrawTexture(new Rect(0,0, Screen.width,Screen.height),text1);
        }
        if (health < 80)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), text2);
        }
    }

}
