using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigOpen : MonoBehaviour {

    public Canvas configCanvas;

    public void onPress()
    {
        configCanvas.enabled = true;
    }

}
