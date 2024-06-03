using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] SpacesManager spacesManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpaceSwapRight()
    {
        spacesManager.SpaceSwap(spacesManager.GetRightSpace());
        //TODO: Have transition (perhaps a wipe) between scenes
    }
    private void SpaceSwapLeft() 
    {
        spacesManager.SpaceSwap(spacesManager.GetRightSpace());
        //TODO: Have transition (perhaps a wipe) between scenes
    }

    // Removes all elements of a scene from showing allowing for full pass-through
    private void HideAllSpaces()
    {
        spacesManager.SpaceSwap(spacesManager.GetEmptySpace());
        //TODO: Have transition (perhaps a fade or shrink) between scenes

    }
}
