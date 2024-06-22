using System.Collections;
using System.Collections.Generic;
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

    public void SpaceSwapRight()
    {
        spacesManager.LoadSpaceSwap(spacesManager.GetRightSpace());
        spacesManager.ActivateSpaceSwap(spacesManager.GetRightSpace());
        //TODO: Have transition (perhaps a wipe) between scenes
    }
    public void SpaceSwapLeft() 
    {
        spacesManager.LoadSpaceSwap(spacesManager.GetLeftSpace());
        spacesManager.ActivateSpaceSwap(spacesManager.GetLeftSpace());
        //TODO: Have transition (perhaps a wipe) between scenes
    }

    // Removes all elements of a scene from showing allowing for full pass-through
    public void HideAllSpaces()
    {
        spacesManager.LoadSpaceSwap(spacesManager.GetEmptySpace());
        spacesManager.ActivateSpaceSwap(spacesManager.GetEmptySpace());
        //TODO: Have transition (perhaps a fade or shrink) between scenes

    }
}
