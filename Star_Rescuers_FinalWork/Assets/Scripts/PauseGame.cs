using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    // Поле для "Панель паузы"
    [SerializeField] private GameObject _pausePanel;

    private bool isAction;

    // Start is called before the first frame update
    void Start()
    {
        isAction = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Панель паузы открывается и закрывается при нажатии на клавишу
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isAction)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
            _pausePanel.gameObject.SetActive(isAction);
            isAction = !isAction;
        }
    }
}
