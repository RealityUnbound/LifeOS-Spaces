using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] RoomManager roomManager;
    [SerializeField] SpacesManager spacesManager;
    [SerializeField] InputManager inputManager;
    [SerializeField] AppManager appManager;

    [Header("Scene Management")]
    private Scene currentScene;
    private int sceneCount; // Currently not in use, but applicable when scaling to get scenes by their index
    private int currentSceneIndex; // Currently not in use, but applicable when scaling to get scenes by their index

    //[SerializeField] SceneAsset lScene;
    //[SerializeField] SceneAsset rScene;
    //[SerializeField] SceneAsset passthroughScene;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
