using System.Linq;
using Assets.Scripts;
using UnityEngine;

public class MovePlate : MonoBehaviour
{
    public GameObject controller;
    private GameObject reference;

    private float newCoorX;
    private float newCoorY;
    private float newCoorZ;

    private string removeStone;

    public void OnMouseUp()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        GameObject removableStone = controller.GetComponent<PanchaKone>().GetStone(removeStone);
        DestroyImmediate(removableStone);

        var stoneRef = reference.GetComponent<Stone>();
        var removeStoneName = StoneCoordinateMap.GetStoneName(stoneRef.GetXBoard(), stoneRef.GetYBoard(), stoneRef.GetZBoard());
        controller.GetComponent<PanchaKone>().SetStoneEmpty(removeStoneName);

        reference.GetComponent<Stone>().SetXBoard(newCoorX);
        reference.GetComponent<Stone>().SetYBoard(newCoorY);
        reference.GetComponent<Stone>().SetZBoard(newCoorZ);

        reference.GetComponent<Stone>().SetCoordinates();

        var newName =  StoneCoordinateMap.GetStoneName(newCoorX, newCoorY, newCoorZ);
        reference.GetComponent<Stone>().name = newName;

        controller.GetComponent<PanchaKone>().SetStone(reference);
        reference.GetComponent<Stone>().DestroyMovePlates();

        GameStatus();

    }

    private void GameStatus()
    {
        GameObject[] stones = GameObject.FindGameObjectsWithTag("Stone");
        if (stones.Length == 1)
        {
            //stones.FirstOrDefault()!.GetComponent<SpriteRenderer>().color = Color.blue;
            stones.FirstOrDefault()!.GetComponent<Renderer>().material.color = Color.blue;

            //Debug.Log("Winner !");
        }
        else if (stones.Length < 7)
        {
            if (IsGameOver(stones))
            {
                foreach (var stone in stones)
                {
                    //stone.GetComponent<SpriteRenderer>().color = Color.red;
                    stone.GetComponent<Renderer>().material.color = Color.red;

                }
                //Debug.Log("Game Over");
            }
        }
    }

    private bool IsGameOver(GameObject[] stones)
    {
        var isMovePossible = false;

        foreach (var stone in stones)
        {
            switch (stone.name)
            {
                case StoneCoordinateMap.TopStone:
                    isMovePossible = IsMovePossible(StoneCoordinateMap.InnerLeftStone, StoneCoordinateMap.MidLeftStone) 
                                     || IsMovePossible(StoneCoordinateMap.InnerRightStone, StoneCoordinateMap.MidRightStone);

                    break;
                case StoneCoordinateMap.LeftStone:
                    isMovePossible = IsMovePossible(StoneCoordinateMap.InnerLeftStone, StoneCoordinateMap.InnerRightStone)
                                     || IsMovePossible(StoneCoordinateMap.MidLeftStone, StoneCoordinateMap.BottomStone);

                    break;
                case StoneCoordinateMap.InnerLeftStone:
                    isMovePossible = IsMovePossible(StoneCoordinateMap.InnerRightStone, StoneCoordinateMap.RightStone)
                                     || IsMovePossible(StoneCoordinateMap.MidLeftStone, StoneCoordinateMap.LastLeftStone);

                    break;
                case StoneCoordinateMap.InnerRightStone:
                    isMovePossible = IsMovePossible(StoneCoordinateMap.InnerLeftStone, StoneCoordinateMap.LastLeftStone)
                                     || IsMovePossible(StoneCoordinateMap.MidRightStone, StoneCoordinateMap.LastRightStone);

                    break;
                case StoneCoordinateMap.RightStone:
                    isMovePossible = IsMovePossible(StoneCoordinateMap.InnerRightStone, StoneCoordinateMap.InnerLeftStone) 
                                     || IsMovePossible(StoneCoordinateMap.MidRightStone, StoneCoordinateMap.BottomStone);

                    break;
                case StoneCoordinateMap.MidLeftStone:
                    isMovePossible = IsMovePossible(StoneCoordinateMap.InnerLeftStone, StoneCoordinateMap.TopStone)
                                     || IsMovePossible(StoneCoordinateMap.BottomStone, StoneCoordinateMap.LastRightStone);

                    break;
                case StoneCoordinateMap.MidRightStone:
                    isMovePossible = IsMovePossible(StoneCoordinateMap.InnerRightStone, StoneCoordinateMap.TopStone)
                                     || IsMovePossible(StoneCoordinateMap.BottomStone, StoneCoordinateMap.LastLeftStone);

                    break;
                case StoneCoordinateMap.BottomStone:
                    isMovePossible = IsMovePossible(StoneCoordinateMap.MidLeftStone, StoneCoordinateMap.LeftStone)
                                     || IsMovePossible(StoneCoordinateMap.MidRightStone, StoneCoordinateMap.RightStone);

                    break;
                case StoneCoordinateMap.LastLeftStone:
                    isMovePossible = IsMovePossible(StoneCoordinateMap.MidLeftStone, StoneCoordinateMap.InnerLeftStone)
                                     || IsMovePossible(StoneCoordinateMap.BottomStone, StoneCoordinateMap.MidRightStone);

                    break;
                case StoneCoordinateMap.LastRightStone:
                    isMovePossible = IsMovePossible(StoneCoordinateMap.BottomStone, StoneCoordinateMap.MidLeftStone)
                                     || IsMovePossible(StoneCoordinateMap.MidRightStone, StoneCoordinateMap.InnerRightStone);

                    break;
                default:
                    Debug.LogError($"Invalid Stone name {name}");
                    break;
            }
            if (!isMovePossible) continue;
            return false;
        }

        return true;
    }

    private bool IsMovePossible(string nextStone, string otherStone)
    {
        var stoneReference = reference.GetComponent<Stone>();

        var isPresent = stoneReference.IsNextStonePresent(nextStone);
        var isAbsent = stoneReference.IsOtherStoneAbsent(otherStone);

        return isPresent && isAbsent;
    }

    public void SetNewCoordinates(float x, float y, float z)
    {
        newCoorX = x;
        newCoorY = y;
        newCoorZ = z;
    }

    public void SetRemoveStoneCoordinates(string stone)
    {
        removeStone = stone;
    }

    public void SetReference(GameObject obj)
    {
        reference = obj;
    }

    public GameObject GetReference()
    {
        return reference;
    }
}
