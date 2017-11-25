using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour 
{
	private AudioSource _coinAudioSource;

	void Start()
	{
		_coinAudioSource = GetComponent<AudioSource>();
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player")
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				Player player = other.GetComponent<Player>();
				if (player != null)
				{
					player.CollectCoin();
					_coinAudioSource.Play();
					Destroy(gameObject, 0.5f);
				}
			}
		}
	}

}
