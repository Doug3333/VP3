using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameStartz : MonoBehaviour
{
    [SerializeField] TMP_InputField NameHere;


    public void StartGame()
    {
        PlayerPrefs.SetString("Name", NameHere.text);
        Debug.Log(PlayerPrefs.GetString("Name"));

    }




}
