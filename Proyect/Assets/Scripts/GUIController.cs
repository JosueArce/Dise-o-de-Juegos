using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIController : MonoBehaviour {

	public GameObject texto;
	public GameObject inputField;
	public GameObject healthBar;
	public int currentHP = 100;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Q))
        {
            if (getCurrentHP() < 100)
            {
                changeHP(1);
            }
        }
        if (Input.GetKey(KeyCode.E))
        {
            if (getCurrentHP() > 0)
            {
                changeHP(-1);
            }
        }
        healthBar.GetComponent<Slider>().value = currentHP;
	}
    void changeHP(int dHP)
    {
        currentHP += dHP;
    }
    int getCurrentHP()
    {
        return currentHP;
    }
    

	public void getText()
    {
        texto.GetComponent<Text>().text = inputField.GetComponent<InputField>().text.ToString();
    }

	void ChangeHP(int number){
		healthBar.GetComponent<Slider>().value-=number;
	}

	public void LoadVolcanoMap(){
		SceneManager.LoadScene("Volcano_Map");
	}
}
