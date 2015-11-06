using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class notMine : Photon.MonoBehaviour {
	public GameObject cam, Head;

	void Start()
	{
		if (!photonView.isMine)
		{
			GetComponent<FirstPersonController>().enabled = false;
			GetComponent<CombatHandler>().enabled = false;
			Destroy(cam);
			Destroy(Head.GetComponent<AudioListener>());
		}
		Destroy(this);
	}
}
