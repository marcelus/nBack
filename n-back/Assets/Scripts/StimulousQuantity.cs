using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StimulousQuantity : MonoBehaviour {

    public MainController mainController;
	
	void Start ()
    {
        StartCoroutine(fillField());
	}

    public void updateStimulousQuantity ()
    {
        mainController.SetStimulousQuantity(int.Parse(this.GetComponentInChildren<Text>().text));
    }

    IEnumerator fillField()
    {
        yield return new WaitForSeconds(1 / 5);
        this.GetComponent<InputField>().text = mainController.GetStimulousQuantity().ToString();
    }

}