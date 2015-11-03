using UnityEngine;
using System.Collections;

public class test2 : MonoBehaviour {

	[SerializeField] GameObject explosion;
	public float explosionForce;
	
	void OnTriggerEnter (Collider other)
	{
		other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y + 0.5f, other.transform.position.z);
		other.GetComponent<Rigidbody>().AddForce((other.transform.position-transform.position) * explosionForce, ForceMode.Impulse);
		Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
	}
	
	
}
