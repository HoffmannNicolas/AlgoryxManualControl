using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AGXUnity.Model;

public class ScriptController : MonoBehaviour
{

    private WheelLoaderInputController controller;

    // Start is called before the first frame update
    void Start() {
        this.controller = (WheelLoaderInputController) gameObject.GetComponent("WheelLoaderInputController");
        controller.InputMode = WheelLoaderInputController.ActionMode.Manual;
    }

    // Update is called once per frame
    void Update()
    {
        // UnityEngine.Component comp = gameObject.GetComponent("WheelLoaderInputController");
        controller.Throttle = 1;
        Debug.Log(controller.Throttle);
    }
}
