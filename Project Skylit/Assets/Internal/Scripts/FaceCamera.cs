using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "

    private Camera camera;

    #endregion //Fields

    #region " - - - - - - Methods - - - - - - "

    private void Start() {

        camera = Camera.main;
    }

    private void Update() {

        transform.LookAt(camera.transform);
    }

    #endregion //Methods
}