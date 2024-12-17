using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    [SerializeField] GameObject subjectPanel;
    public void OnStartButton()
    {
        SceneManager.LoadScene("MainTown");
    }

    public void OnDeleteSaveDataButton()
    {
        subjectPanel.SetActive(true);
    }

    public void OnPrecautionsButton()
    {
        subjectPanel.SetActive(true);
    }
}
