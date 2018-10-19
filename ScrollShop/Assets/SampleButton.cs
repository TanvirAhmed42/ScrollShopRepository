using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleButton : MonoBehaviour {

	public Button button;
	public Text nameLabel;
	public Text priceLabel;
	public Image iconImage;

	Item item;
	ShopScrollList scrollList;

	public void Setup (Item currentItem, ShopScrollList currentScrollList) {
		item = currentItem;
		nameLabel.text = item.itemName;
		iconImage.sprite = item.icon;
		priceLabel.text = item.price.ToString ();

		scrollList = currentScrollList;
	}

	public void HandleClick () {
		scrollList.TryTransferItemToOtherShop (item);
	}
}
