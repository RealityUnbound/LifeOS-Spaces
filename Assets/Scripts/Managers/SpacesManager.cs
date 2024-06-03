using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpacesManager : MonoBehaviour
{
    public static SpacesManager instance;

    [Header("Spaces Set Up")]
    //[SerializeField] SceneAsset scene1;
    //private SceneAsset currentSpace;
    [SerializeField] Scene emptySpace;
    private UnityEngine.SceneManagement.Scene currentSpace;
    private UnityEngine.SceneManagement.Scene leftSpace;
    private UnityEngine.SceneManagement.Scene rightSpace;
    //public List<SceneAsset> spaces = new List<SceneAsset>(); // Deprecated for SceneManager.GetSceneByName()

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        leftSpace = SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex - 1);
        rightSpace = SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpaceSwap(UnityEngine.SceneManagement.Scene newScene)
    {
        if (newScene == null)
        {
            print("No Space Available");
            return;
        }
        SceneManager.LoadSceneAsync(newScene.buildIndex);
    }

    public Scene GetRightSpace(){ return rightSpace; }
    public Scene GetLeftSpace() { return leftSpace; }
    public Scene GetEmptySpace() { return emptySpace; }


}
