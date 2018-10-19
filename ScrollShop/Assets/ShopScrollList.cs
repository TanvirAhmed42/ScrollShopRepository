using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item {
	public string itemName;
	public Sprite icon;
	public float price = 1f;
}

public class ShopScrollList : MonoBehaviour {

	public List<Item> itemList;
	public Transform contentPanel;
	public ShopScrollList otherShop;
	public Text myGoldDisplay;
	public GameObject buttonPrefab;
	public float gold = 20f;

	// Use this for initialization
	void Start () {
		RefreshDisplay ();
	}

	public void RefreshDisplay () {
		myGoldDisplay.text = "Gold :" + gold.ToString ();
		RemoveButtons ();
		AddButtons ();
	}

	public void RefreshDisplay2 () {
		myGoldDisplay.text = "Gold :" + gold.ToString ();
		RemoveButtons ();
		AddButtons ();
	}

	void AddButtons () {
		for (int i = 0; i < itemList.Count; i++) {
			Item item = itemList [i];
			GameObject newButton = (GameObject)Instantiate (buttonPrefab);
			newButton.transform.SetParent (contentPanel);
			newButton.transform.localScale = new Vector3 (1, 1, 1);

			SampleButton sampleButton = newButton.GetComponent<SampleButton> ();
			sampleButton.Setup (item, this);
		}
	}

	void RemoveButtons () {
		for (int i = contentPanel.childCount - 1; i >= 0; i--) {
			Destroy (contentPanel.GetChild (i).gameObject);
		}
	}

	public void TryTransferItemToOtherShop (Item item) {
		if (otherShop.gold >= item.price) {
			gold += item.price;
			otherShop.gold -= item.price;
			AddItem (item, otherShop);
			RemoveItem (item, this);

			RefreshDisplay2 ();
			otherShop.RefreshDisplay2 ();
		}
	}

	void AddItem (Item itemToAdd, ShopScrollList shopList) {
		shopList.itemList.Add (itemToAdd);
	}

	void RemoveItem (Item itemToRemove, ShopScrollList shopList) {
		for (int i = shopList.itemList.Count - 1; i >= 0; i--) {
			if (shopList.itemList [i] == itemToRemove) {
				shopList.itemList.RemoveAt (i);
				return;
			}
		}
	}
}
