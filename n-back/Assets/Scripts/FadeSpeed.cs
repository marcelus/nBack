using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeSpeed : MonoBehaviour {

    public MainController mainController;

    void Start()
    {
        StartCoroutine(fillField());
    }

    public void UpdateFadeSpeed()
    {
        mainController.SetFadeSpeed(int.Parse(this.GetComponentInChildren<Text>().text));
    }

    IEnumerator fillField()
    {
        yield return new WaitForSeconds(1 / 5);
        this.GetComponent<InputField>().text = mainController.GetFadeSpeed().ToString();
    }
}
