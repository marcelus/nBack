using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CancelRepetition : MonoBehaviour
{
    public MainController mainController;
    public StartButton startButton;

    public void SetGameControllerReference(MainController controller)
    {
        mainController = controller;
    }

    public void onPress()
    {
        //StopCoroutine(mainController.displayStimulous());
        startButton.StopAllCoroutines();
        mainController.ClearBoard();
        //mainController.StopAllCoroutines();
        mainController.stimulousButtons.enabled = false;
        mainController.mainSceneButtons.enabled = true;
    }
}

