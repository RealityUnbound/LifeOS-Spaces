using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpacesManager : MonoBehaviour
{
    public static SpacesManager instance;

    [Header("Spaces Set Up")]
    [SerializeField] Scene emptySpace;
    [SerializeField] Scene leftSpace;
    [SerializeField] Scene rightSpace;

    private Scene currentSpace;

    //[SerializeField] SceneAsset scene1;
    //private SceneAsset currentSpace;

    //public List<SceneAsset> spaces = new List<SceneAsset>(); // Deprecated for SceneManager.GetSceneByName()

    Hashtable spaces;

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

    public void SpaceSwap(UnityEngine.SceneManagement.Scene newScene)
    {
        if (newScene == null)
        {
            print("No Space Available");
            return;
        }
        SceneManager.LoadSceneAsync(newScene.buildIndex);
    }

    public Scene GetRightSpace() { return rightSpace; }
    public Scene GetLeftSpace() { return leftSpace; }
    public Scene GetEmptySpace() { return emptySpace; }


}
