using UnityEngine;

public class AirdropSelfDestruct : MonoBehaviour {

    #region " - - - - - - Fields - - - - - - "

    [SerializeField]
    private float selfDestructTimer;

    private float currentTimer;

    [SerializeField]
    private float descendSpeed;

    private bool destroy;

    #endregion

    #region " - - - - - - Methods - - - - - - "

    private void Update() {

        currentTimer += Time.deltaTime;

        if (currentTimer >= selfDestructTimer) {

            destroy = true;
            if (destroy) {
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                Destroy(this.gameObject, 3f);
            }

            this.gameObject.transform.Translate(Vector3.down * Time.deltaTime * descendSpeed);
        }

    }

    #endregion

}