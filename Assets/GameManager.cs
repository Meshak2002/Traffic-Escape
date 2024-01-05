using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int cars;
    public int NextScene = 1;
    public List<Transform> TCars;
    public static GameManager instance;
    public GameObject canv;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(cars==TCars.Count) {
            canv.SetActive(true);
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {

        SceneManager.LoadScene(NextScene);
    }
}
