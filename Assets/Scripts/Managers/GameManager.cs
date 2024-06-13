using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] RoomManager roomManager;
    [SerializeField] SpacesManager spacesManager;
    [SerializeField] InputManager inputManager;
    [SerializeField] AppManager appManager;

    [Header("Scene Management")]
    [SerializeField] SceneAsset currentScene;
    private int sceneCount;
    private int currentSceneIndex;

    [SerializeField] SceneAsset lScene;
    [SerializeField] SceneAsset rScene;
    [SerializeField] SceneAsset passthroughScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
