using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkRepetition : MonoBehaviour {

    public MainController mainController;

    public void SetGameControllerReference(MainController controller)
    {
        mainController = controller;
    }

    public void onPress()
    {
        StartCoroutine(mainController.displayStimulous());
    }
}
