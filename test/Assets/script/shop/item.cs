using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class item : MonoBehaviour
{
    public shop shopScript; //ссылка на скрипт магазина
    public Text nameItem; //имя товара
    public Text priceItem; //цена товара
    int price;
     
    public void buyItem () {
        shopScript.nameItem = nameItem.text;
        int.TryParse(priceItem.text, out price);
        shopScript.priceItem = price;
        shopScript.buyItem();
    }

    void Update() {
        if ((shopScript.secretScroll == true) && (nameItem.text == "Странный свиток")) {
            gameObject.SetActive(true);
        }
    }
}
