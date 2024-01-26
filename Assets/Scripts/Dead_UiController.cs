using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dead_UiController : MonoBehaviour
{
    public GameObject _youDiedPanel;

    public void YouDiedPannel()
    {
        if (PlayerInfo.instance.currentHealth == 0)
        {
            _youDiedPanel.SetActive(true);
        }
    }

    public void BackToMainButton()
    {
        Debug.Log("BackToMainButton called");

        SceneManager.LoadScene(0);
        _youDiedPanel.SetActive(true);

    }

    public void TryAgainButton()
    {
        SceneManager.LoadScene(1);
    }



}
