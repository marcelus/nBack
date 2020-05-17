using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interval : MonoBehaviour {

    public MainController mainController;

    void Start()
    {
        StartCoroutine(fillField());
    }

    public void updateInterval()
    {
        mainController.SetInterval(int.Parse(this.GetComponentInChildren<Text>().text));
    }

    IEnumerator fillField()
    {
        yield return new WaitForSeconds(1 / 5);
        this.GetComponent<InputField>().text = mainController.GetInterval().ToString();
    }
}
