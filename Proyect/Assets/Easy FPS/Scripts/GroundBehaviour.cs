using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    public List<GroundType> GroundTypes = new List<GroundType>();
    public PlayerMovementScript FPC;
    public string currentground;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //if(hit.transform.tag)
        
    }
    public void setGroundType(GroundType ground)
    {
        if (currentground != ground.name)
        {
            FPC.currentSpeed = ground.walkSpeed;
            FPC.maxSpeed = (int)ground.runSpeed;
            currentground = ground.name;
        }
    }
    public class GroundType
    {
        public string name;
        public AudioClip[] footstepsounds;
        public float walkSpeed = 5;
        public float runSpeed = 10;
    }
}
