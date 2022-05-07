using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class item : MonoBehaviour
{
    public shop scriptShop; //ссылка на скрипт магазина
    public Text nameItem; //имя товара
    public Text priceItem; //цена товара
    int price;
     
    public void buyItem () {
        scriptShop.nameItem = nameItem.text;
        int.TryParse(priceItem.text, out price);
        scriptShop.priceItem = price;
        scriptShop.buyItem();
    }
}
