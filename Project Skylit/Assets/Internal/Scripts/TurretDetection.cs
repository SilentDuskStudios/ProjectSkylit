using UnityEngine;

public class TurretDetection : MonoBehaviour {

    #region " - - - - - - Properties - - - - - - "

    public Transform Target { get; private set; }
    public bool HasTarget { get; set; }

    #endregion

    #region " - - - - - - Methods - - - - - - "

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "Beast") {

            if (!HasTarget) {
                HasTarget = true;
                Target = other.gameObject.transform;
            }
        }
    }

    private void OnTriggerStay(Collider other) {

        if (other.gameObject.tag == "Beast") {

            if (!HasTarget) {
                HasTarget = true;
                Target = other.gameObject.transform;
            }
        }
    }

    private void OnTriggerExit(Collider other) {

        if (other.gameObject.tag == "Beast") {

            if(other.gameObject.transform == Target) {
                Target = null;
                HasTarget = false;

            }
        }
    }

    #endregion

}