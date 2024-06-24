using Oculus.Interaction;
using Oculus.Interaction.PoseDetection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseManager : MonoBehaviour
{
    [SerializeField] InputManager inputManager;

    [SerializeField, Interface(typeof(IActiveState))]
    private List<SequenceActiveState> gestureSequences;

    //[SerializeField] SequenceActiveState swipeRightGesture;
    //[SerializeField] SequenceActiveState swipeLeftGesture;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //// Recognizes and Validates when the pose and gesture for Swiping Right occurs
    //private void SpaceSwipeRight() // Moved Functionality to InputManager
    //{
    //    if (swipeRightGesture.Active)
    //    {
    //        inputManager.SpaceSwapRight();
    //    }
    //    else
    //    {
    //        return;
    //    }
    //}
    //// Recognizes and Validates when the pose and gesture for Swiping Left occurs
    //private void SpaceSwipeLeft() // Moved Functionality to InputManager
    //{
    //    if (swipeLeftGesture.Active)
    //    {
    //        inputManager.SpaceSwapLeft();

    //    }
    //    else
    //    {
    //        return;
    //    }
    //}
}
