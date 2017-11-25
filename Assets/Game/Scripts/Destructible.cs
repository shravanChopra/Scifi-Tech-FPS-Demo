using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour 
{
	[SerializeField] private GameObject _crackedCrate;

	public void DestroyCrate()
	{
		// Perform object-swap, i.e. replace this object by cracked crate
		Instantiate(_crackedCrate, transform.position, transform.rotation);
		Destroy(gameObject);
	}

}
