using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpacesManager : MonoBehaviour
{
    public static SpacesManager instance;
    [SerializeField] GameManager gameManager;

    [Header("Spaces Set Up")]
    [SerializeField] private SceneAsset lScene;
    [SerializeField] private SceneAsset rScene;
    [SerializeField] private SceneAsset passthroughScene;
    private Scene currentSpace;



    //[SerializeField] SceneAsset scene1;
    //private SceneAsset currentSpace;

    //public List<SceneAsset> spaces = new List<SceneAsset>(); // Deprecated for SceneManager.GetSceneByName()

    //Hashtable spaces;

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
        currentSpace = SceneManager.GetActiveScene();
        //leftSpace = SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex - 1); // A different implementation for Scene Management
        //rightSpace = SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadSpaceSwap(SceneAsset newScene)
    {
        if (newScene == null)
        {
            print("No Space Available");
            return;
        }
        SceneManager.LoadSceneAsync(newScene.name);
    }

    public void ActivateSpaceSwap(SceneAsset newScene)
    {
        if (newScene == null)
        {
            print("No Space Available");
            return;
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(newScene.name));
        currentSpace = SceneManager.GetActiveScene();
    }

    public SceneAsset GetRightSpace() { return rScene; }
    public SceneAsset GetLeftSpace() { return lScene; }
    public SceneAsset GetEmptySpace() { return passthroughScene; }


}
