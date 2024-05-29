using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Grid), typeof(BoxCollider))]
public class RoomManager : MonoBehaviour
{
    /// <summary>
    /// Sets up room to be able to spawn objects to interact with
    /// Meta and GorillaZila influenced system for managing rooms
    /// </summary>

    [Header("Dependencies")]
    [SerializeField] OVRSceneManager sceneManager;

    [Header("Settings")]
    [SerializeField] LayerMask wallLayer;
    [SerializeField] LayerMask furnitureLayer;
    [SerializeField] float paddingFromFurniture = .2f;

    private OVRSceneRoom room;
    private BoxCollider roomBounds;
    private Grid grid;
    private TransformFollower follower;

    private void Awake()
    {
        if (sceneManager == null)
            sceneManager = GameObject.FindObjectOfType<OVRSceneManager>();

        sceneManager.SceneModelLoadedSuccessfully += OnSceneLoaded;
        grid = GetComponent<Grid>();
        follower = GetComponent<TransformFollower>();
        roomBounds = GetComponent<BoxCollider>();
        roomBounds.isTrigger = true;
    }
    private void OnSceneLoaded()
    {
        room = GameObject.FindAnyObjectByType<OVRSceneRoom>();
        room.gameObject.SetLayerRecursive("Room");

        //Setup collider for room to fit the bounds of the space (using collider as a Bounds type doesn't work with rotation)
        float height = room.Walls[0].Height;
        float width = room.Floor.Width;
        float depth = room.Floor.Height;
        roomBounds.size = new Vector3(width, depth, height);
        roomBounds.center = new Vector3(0, 0, height / 2f);
        follower.target = room.Floor.transform;
    }
    public bool IsInsideGuardian(Vector3 position)
    {
        position.y = 0;
        var result = OVRManager.boundary.TestPoint(position, OVRBoundary.BoundaryType.PlayArea);
        float dist = result.ClosestDistance;
        return dist <= .1f;
    }

    //Checks if the point is colliding with furniture using a Physics check box
    public bool IsInsideFurniture(Vector3 position)
    {
        bool isInFurniture = Physics.CheckBox(position, grid.cellSize, transform.rotation, furnitureLayer);
        bool isBelowFurniture = Physics.Raycast(position, Vector3.up, Mathf.Infinity, furnitureLayer);
        return isInFurniture || isBelowFurniture;
    }
    //Returns true if a point is facing in the forward direction (i.e. the normal) of the closest wall to that given point
    public bool IsPointInRoom(Vector3 point, float padding = 0)
    {
        float distance = DistanceToClosestWall(point, out Vector3 closestPoint, out OVRScenePlane closestWall);
        if (distance < padding || closestWall == null)
        {
            return false;
        }
        bool isInBoxCollider = roomBounds.ClosestPoint(point) == point;
        Vector3 dirToWall = (closestPoint - point).normalized;
        float dotProduct = Vector3.Dot(closestWall.transform.forward, dirToWall);
        return isInBoxCollider && dotProduct < -.5f;
    }
    //Calculate the closest point to any given wall in the OVRSceneRoom
    public float DistanceToClosestWall(Vector3 point, out Vector3 closestPoint, out OVRScenePlane closestWall)
    {

        float minDist = Mathf.Infinity;
        closestPoint = Vector3.zero;
        closestWall = null;
        if (room == null)
        {
            return minDist;
        }
        foreach (OVRScenePlane wall in room.Walls)
        {
            var col = wall.GetComponentInChildren<Collider>();
            Vector3 cp = col.ClosestPoint(point);
            float dist = Vector3.Distance(cp, point);
            if (dist < minDist)
            {
                minDist = dist;
                closestPoint = cp;
                closestWall = wall;
            }
        }
        return minDist;
    }
    //Calculate the closest point to any furniture in the OVRSceneRoom
    //public float DistanceToClosestScreen(Vector3 point, out Vector3 closestPoint, out OVRScene)
    //Returns the center position of the room
    public Vector3 CenterOfRoom()
    {
        Vector3 centerOfRoom = roomBounds.transform.TransformPoint(roomBounds.center);
        return centerOfRoom;
    }
}
