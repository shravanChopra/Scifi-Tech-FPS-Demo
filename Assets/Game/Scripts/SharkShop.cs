using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkShop : MonoBehaviour
{

	private AudioSource _collectWeaponAudio;

	void Start()
	{
		_collectWeaponAudio = GetComponent<AudioSource>();
	}

	void OnTriggerStay(Collider other)
	{
		// check if it's the player
		if (other.tag == "Player")
		{
			Player player = other.GetComponent<Player>();
			
			if (player != null)
			{
				// check for E key
				if (Input.GetKeyDown(KeyCode.E))
				{
					// check if the player has the coin
					if (player.hasCoin)
					{
						// trade the coin for the weapon
						player.CollectWeapon();
						
						// play the sound
						_collectWeaponAudio.Play();
					}
					else
					{
						Debug.Log("Get out of here!");
					}
				}	
			}
		}
	}
	
}
