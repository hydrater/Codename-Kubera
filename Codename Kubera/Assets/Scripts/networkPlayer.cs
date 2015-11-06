using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class networkPlayer : Photon.MonoBehaviour {
	Vector3 realPosition = Vector3.zero;
	Quaternion realRotation = Quaternion.identity, headRotation = Quaternion.identity;
	public GameObject head;
	
	void Update()
	{
		if (!photonView.isMine)
		{
			transform.position = Vector3.Lerp(transform.position, realPosition, 0.1f);
			//transform.rotation = Quaternion.Lerp(transform.rotation, realRotation, 0.1f);
			head.transform.localRotation = Quaternion.Lerp(head.transform.rotation, headRotation, 0.1f);
		}
	}
	
	public void OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
			stream.SendNext(head.transform.rotation);
		}
		else
		{
			realPosition = (Vector3)stream.ReceiveNext();
			realRotation = (Quaternion)stream.ReceiveNext();
			headRotation = (Quaternion)stream.ReceiveNext();
		}
	}
}










