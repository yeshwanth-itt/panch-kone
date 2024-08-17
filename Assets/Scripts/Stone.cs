using Assets.Scripts;
using UnityEngine;


public class Stone : MonoBehaviour
{
    public GameObject controller;
    public GameObject movePlate;

    private float xBoard;
    private float yBoard;
    private float zBoard;

    //public Sprite stone;
    public GameObject stone;

    public void Activate()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        SetCoordinates();
    }

    public void SetCoordinates()
    {
        transform.position = new Vector3(xBoard, yBoard, zBoard);
    }

    public float GetXBoard()
    {
        return xBoard;
    }

    public float GetYBoard()
    {
        return yBoard;
    }

    public float GetZBoard()
    {
        return zBoard;
    }

    public void SetXBoard(float x)
    {
        xBoard = x;
    }

    public void SetYBoard(float y)
    {
        yBoard = y;
    }
        
    public void SetZBoard(float z)
    {
        zBoard = z;
    }

    private void OnMouseUp()
    {
        DestroyMovePlates();
        InitiateMovePlates();
    }

    public void DestroyMovePlates()
    {
        GameObject[] movePlates = GameObject.FindGameObjectsWithTag("MovePlate");
        foreach (var movePlate in movePlates)
        {
            Destroy(movePlate);
        }
    }   

    public void InitiateMovePlates()
    {
        switch (this.name)
        {
            case StoneCoordinateMap.TopStone:
                MovePlateSpawn(StoneCoordinateMap.InnerLeftStone, StoneCoordinateMap.MidLeftStone);
                MovePlateSpawn(StoneCoordinateMap.InnerRightStone, StoneCoordinateMap.MidRightStone);
                break;
            case StoneCoordinateMap.LeftStone:
                MovePlateSpawn(StoneCoordinateMap.InnerLeftStone, StoneCoordinateMap.InnerRightStone);
                MovePlateSpawn(StoneCoordinateMap.MidLeftStone, StoneCoordinateMap.BottomStone);
                break;
            case StoneCoordinateMap.InnerLeftStone:
                MovePlateSpawn(StoneCoordinateMap.InnerRightStone, StoneCoordinateMap.RightStone);
                MovePlateSpawn(StoneCoordinateMap.MidLeftStone, StoneCoordinateMap.LastLeftStone);
                break;
            case StoneCoordinateMap.InnerRightStone:
                MovePlateSpawn(StoneCoordinateMap.InnerLeftStone, StoneCoordinateMap.LeftStone);
                MovePlateSpawn(StoneCoordinateMap.MidRightStone, StoneCoordinateMap.LastRightStone);
                break;
            case StoneCoordinateMap.RightStone:
                MovePlateSpawn(StoneCoordinateMap.InnerRightStone, StoneCoordinateMap.InnerLeftStone);
                MovePlateSpawn(StoneCoordinateMap.MidRightStone, StoneCoordinateMap.BottomStone);
                break;
            case StoneCoordinateMap.MidLeftStone:
                MovePlateSpawn(StoneCoordinateMap.InnerLeftStone, StoneCoordinateMap.TopStone);
                MovePlateSpawn(StoneCoordinateMap.BottomStone, StoneCoordinateMap.LastRightStone);
                break;
            case StoneCoordinateMap.MidRightStone:
                MovePlateSpawn(StoneCoordinateMap.InnerRightStone, StoneCoordinateMap.TopStone);
                MovePlateSpawn(StoneCoordinateMap.BottomStone, StoneCoordinateMap.LastLeftStone);
                break;
            case StoneCoordinateMap.BottomStone:
                MovePlateSpawn(StoneCoordinateMap.MidLeftStone, StoneCoordinateMap.LeftStone);
                MovePlateSpawn(StoneCoordinateMap.MidRightStone, StoneCoordinateMap.RightStone);
                break;
            case StoneCoordinateMap.LastLeftStone:
                MovePlateSpawn(StoneCoordinateMap.MidLeftStone, StoneCoordinateMap.InnerLeftStone);
                MovePlateSpawn(StoneCoordinateMap.BottomStone, StoneCoordinateMap.MidRightStone);
                break;
            case StoneCoordinateMap.LastRightStone:
                MovePlateSpawn(StoneCoordinateMap.BottomStone, StoneCoordinateMap.MidLeftStone);
                MovePlateSpawn(StoneCoordinateMap.MidRightStone, StoneCoordinateMap.InnerRightStone);
                break;
            default:
                Debug.LogError($"Invalid Stone name {name}");
                break;
        }

    }

    private void MovePlateSpawn(string nextStone, string otherStone)
    {
        var isPresent = IsNextStonePresent(nextStone);
        var isAbsent = IsOtherStoneAbsent(otherStone);

        if (isPresent && isAbsent)
        {
            GameObject mp = InstantiateMovePlate(otherStone);
            MovePlate mpScript = mp.GetComponent<MovePlate>();
            mpScript.SetReference(gameObject);
            var otherStoneObj = StoneCoordinateMap.StoneDictionary[otherStone];
            mpScript.SetNewCoordinates(otherStoneObj.X, otherStoneObj.Y, otherStoneObj.Z);
            mpScript.SetRemoveStoneCoordinates(nextStone);
        }
    }

    private GameObject InstantiateMovePlate(string otherStone)
    {
        var movePlateObj = StoneCoordinateMap.MovePlateDictionary[otherStone];
    
        return Instantiate(movePlate, new Vector3(movePlateObj.X, movePlateObj.Y, movePlateObj.Z),
            movePlate.transform.rotation);
    }

    public bool IsNextStonePresent(string nextStone)
    {
        PanchaKone sc = controller.GetComponent<PanchaKone>();
        return sc.GetStone(nextStone) != null;
    }

    public bool IsOtherStoneAbsent(string otherStone)
    {
        PanchaKone sc = controller.GetComponent<PanchaKone>();
        return sc.GetStone(otherStone) == null;
    }
}

