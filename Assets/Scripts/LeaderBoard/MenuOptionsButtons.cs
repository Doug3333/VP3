using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class MenuOptionsButtons : MonoBehaviour
{

    [SerializeField] GameObject YAYA;
    [SerializeField] GameObject YYA;
    [SerializeField] GameObject AYY;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (YAYA.activeSelf == false)
            {
                YAYA.SetActive(true);
                YYA.SetActive(false);

            }
            else
            {
                YAYA.SetActive(false);
                YYA.SetActive(true);

            }
        }

    }

    public void Play()
    {
        YAYA.SetActive(false);

        YYA.SetActive(true);

        GamesManager.Instance.SwitchState<PlayingState>();

        
    }

    public void QuitGame()
    {
        UnityEngine.Application.Quit();
       #if (UNITY_EDITOR)
        UnityEditor.EditorApplication.isPlaying = false;
      #endif
    }
}

