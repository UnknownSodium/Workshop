using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartButtonComp : MonoBehaviour
{
    public void OnPressStartButton()
    {
        SceneManager.LoadScene("Gameplay");
    }
}

