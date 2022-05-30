using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class item : MonoBehaviour {
    public shop shopScript; //ссылка на скрипт магазина
    public string category;
    public string stat;
    public int value;
    public Text nameItem; //имя товара
    public Text priceItem; //цена товара
    public GameObject buyed;
    public List<GameObject> priceObj = new List<GameObject>();
    int price;
    public bool isBuy;
     
    public void buyItem () {
        if (isBuy == false) {
            shopScript.nameItem = nameItem.text;
            int.TryParse(priceItem.text, out price);
            shopScript.priceItem = price;
            shopScript.category = category;
            shopScript.stat = stat;
            shopScript.value = value;
            shopScript.buyItem();
        }
    }
}
