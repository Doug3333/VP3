using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnPlayerDeath : MonoBehaviour
{
    public UpgradeManager upgradeManager;
    public ScoreSaverName scoreSaver;
    [SerializeField] GameObject YAYEEE;
    [SerializeField] Player player;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log("t");
        if (player.Health <= 0 && !GamesManager.Instance.IsState<PauseState>()) //New Game Instance
        {
            Debug.Log("Death");


            StartCoroutine(OnPlayerDeath2(2));

        }
    }

    IEnumerator OnPlayerDeath2(float time)  //??
    {
        scoreSaver.SaveData(PlayerPrefs.GetString("Name"), upgradeManager.PlayerLevel);
        YAYEEE.SetActive(true);

        //YYA.SetActive(true); //Dont know the refrence, the refrence is to Canvas but dont know??

        GamesManager.Instance.SwitchState<PauseState>();
        //Debug.Log(Time.time);
        yield return new WaitForSeconds(time);
        //Debug.Log(Time.time);
        SceneManager.LoadScene("SampleScene");

        //Time.deltaTime.pause(10);
        //GamesManager.Instance.SwitchState<StartNewGame>();

    }
}
