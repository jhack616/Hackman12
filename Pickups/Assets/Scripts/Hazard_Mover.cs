using UnityEngine;
using System.Collections;

public class Hazard_Mover : MonoBehaviour {
	Vector3 startPos;
 	void Start()
 	{
 		startPos=transform.position;
	}
    void Update() 
    {
    	if ( (transform.position).x > 20 )
    	{
    		transform.position=startPos;
    	}
    	transform.Translate(Time.deltaTime*8, 0, 0);
    }
}