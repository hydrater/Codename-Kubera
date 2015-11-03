using UnityEngine;
using System.Collections;

public class generalNetworking : MonoBehaviour {
	const string VERSION = "Prototype";
	public const int levelIndexStart = 3; //The first non hub scene
	Transform spawnPoint;
	
	void Start()
	{
		if (!PhotonNetwork.connected)
			PhotonNetwork.ConnectUsingSettings(VERSION);
		//Cursor.lockState =  CursorLockMode.Locked;
		//Cursor.visible = false;
	}
	
	void OnJoinedLobby()
	{
		RoomOptions roomOptions = new RoomOptions() { isVisible = false, maxPlayers = 20};
		PhotonNetwork.JoinOrCreateRoom("!Arena", roomOptions, TypedLobby.Default);
	}
	
	void OnJoinedRoom()
	{
		PhotonNetwork.Instantiate("Player", transform.position, Quaternion.identity, 0);
	}
	
}
