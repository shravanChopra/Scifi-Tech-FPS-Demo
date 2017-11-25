using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	[SerializeField] private Text ammoText;
	[SerializeField] private GameObject coinImage;

	public void UpdateAmmo(int ammoCount)
	{
		ammoText.text = "Ammo: " + ammoCount;
	}
	
	public void UpdateCoin()
	{
		coinImage.SetActive(true);
	}
}
