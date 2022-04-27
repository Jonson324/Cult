using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class item : MonoBehaviour
{
    public shop scriptShop; //ссылка на скрипт магазина
    public string nameItem; //имя товара
    public int priceItem; //цена товара
    public Text textItem; //ценник товара
     
    public void buyItem () {
        scriptShop.nameItem = nameItem;
        scriptShop.priceItem = priceItem;

        scriptShop.buyItem();
    }
}
