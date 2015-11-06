using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class CombatHandler : MonoBehaviour {

	public GameObject Larm, Rarm, Cam, Shield;
	float shiftTimer, dashTimer;
	bool Dash;
	Vector3 dashDir;
	FirstPersonController m_FirstPerson;
	CharacterController m_CharacterController;
	
	private void Start()
	{
		m_FirstPerson = GetComponent<FirstPersonController>();
		m_CharacterController = GetComponent<CharacterController>();
	}
	
	
	void Update () 
	{
		
		
		//Attack
		if (Input.GetMouseButton(0))
		{
			if (Shield.activeSelf)
			{
				
			}
		}
		
		//guard
		if (Input.GetMouseButton(1))
		{
			Shield.SetActive(true);
		}
		else
		{
			Shield.SetActive(false);
		}
		
		//---------------------------------- Running
		
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			shiftTimer = 0;
		}
		
		if (Input.GetKey(KeyCode.LeftShift))
		{
			shiftTimer += Time.deltaTime;
			if (shiftTimer > 0.5f)
			{
				if (m_CharacterController.isGrounded)
				{
					m_FirstPerson.Sprint = true;
				}
			}
		}
		else
			m_FirstPerson.Sprint = false;
		
		if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			if (shiftTimer < 0.3f || !m_CharacterController.isGrounded)
			{
				Dash = true;
				dashTimer = 0;
				if (Input.GetKey(KeyCode.W))
					dashDir = Vector3.forward;
				else if (Input.GetKey(KeyCode.A))
					dashDir = Vector3.left;
				else if (Input.GetKey(KeyCode.D))
					dashDir = Vector3.right;
				else
					dashDir = Vector3.back;
			}
			shiftTimer = 0;
		}
		
		// ---------------------------------- Dashing
		
		if (Dash)
		{
			RaycastHit dashCheck;
			if (Physics.Raycast (transform.position, transform.up, out dashCheck, 1.6f)) 
			{
				if (!dashCheck.collider.isTrigger && dashCheck.transform.tag != "Player")
					transform.Translate(dashDir * Time.deltaTime * 20);
			}
			else
				transform.Translate(dashDir * Time.deltaTime * 20);
			dashTimer += Time.deltaTime;
			if (dashTimer > 0.3f)
				Dash = false;
		}
	
	}
}
