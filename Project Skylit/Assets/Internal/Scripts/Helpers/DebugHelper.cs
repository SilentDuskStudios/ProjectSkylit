using UnityEngine;

public class DebugHelper : MonoBehaviour
{
    #region " - - - - - - Fields - - - - - - "



    #endregion

    #region " - - - - - - Methods - - - - - - "

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
            Time.timeScale = 1f;

        if (Input.GetKeyDown(KeyCode.Keypad2))
            Time.timeScale = 2f;

        if (Input.GetKeyDown(KeyCode.Keypad3))
            Time.timeScale = 3f;

        if (Input.GetKeyDown(KeyCode.Keypad4))
            GameManager.gameManager.currencyManager.Add(10);
    }

    #endregion
}