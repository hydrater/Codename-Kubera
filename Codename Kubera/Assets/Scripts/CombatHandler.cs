using UnityEngine;
using System.Collections;

public class CombatHandler : MonoBehaviour {

	public GameObject Larm, Rarm, Cam;
	
	void Start () {
	
	}
	
	void Update () 
	{
		
		
		//Attack
		if (Input.GetMouseButton(0))
		{
			
		}
		
		//guard
		if (Input.GetMouseButton(1))
		{
//			Larm.transform.rotation = Quaternion.Slerp(Larm.transform.rotation, Quaternion.Euler(270, 0, 0), Time.deltaTime * 30);
//			Rarm.transform.rotation = Quaternion.Slerp(Rarm.transform.rotation, Quaternion.Euler(270, 0, 0), Time.deltaTime * 30);
			Larm.transform.rotation =  Quaternion.Euler(270, Cam.transform.rotation.y,  Cam.transform.rotation.z);
			Rarm.transform.rotation =  Quaternion.Euler(270, Cam.transform.rotation.y,  Cam.transform.rotation.z);
		}
		else
		{
			Larm.transform.rotation = Cam.transform.rotation;
			Rarm.transform.rotation = Cam.transform.rotation;
		}
	
	}
}
