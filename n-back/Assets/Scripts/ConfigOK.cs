using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigOK : MonoBehaviour {

    public void onPress()
    {
        this.GetComponentInParent<Canvas>().enabled = false;
    }
}
