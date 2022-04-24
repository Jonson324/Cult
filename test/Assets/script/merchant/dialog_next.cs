using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialog_next : MonoBehaviour
{
    public GameObject Text1; //первая реплика
    public GameObject Text2; //вторая реплика
    public GameObject dialog1_end; //финальная реплика
	public GameObject Ring; //объект задания
    private bool next; //переключатель
    public task taskScript; //ссылка на скрипт взаимодействия с npc

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
			if (next == false) {
				next = true;
				if (taskScript.ring_obtained == true) {
					taskScript.EndDialog2 = true;
				}
			} else {
				next = false;
				if (taskScript.ring_obtained == false) {
					Ring.SetActive(true);
					taskScript.EndDialog1 = true;
				}
			}
		}
		
		if (next == false) {
			Text1.SetActive (true);
			Text2.SetActive (false);
		} else {
			Text1.SetActive (false);
			Text2.SetActive (true);
		}
	}
}
