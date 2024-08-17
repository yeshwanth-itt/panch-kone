using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;


public class PanchaKone : MonoBehaviour
{
    /// board Position(2, 3.8, 1)
    /// board Scale (1.745913 2.671027 1)
    /// Camera Position(2.1 3 -11.3)
    /// Camera Scale(1, 1, 1)

    public GameObject Stone;
    private List<GameObject> Stones;

    private Dictionary<string, GameObject> StoneDictionary = new();


    void Start()
    {
        Stones = new List<GameObject>();

        foreach (KeyValuePair<string, StoneModel> stone in StoneCoordinateMap.StoneDictionary)
        {
            var stoneObject = Create(stone.Value);
            Stones.Add(stoneObject);

            StoneDictionary.Add(stone.Key, stoneObject);
        }

        var randomNumber = Random.Range(0, 10);
        var removeStone = Stones[randomNumber].name;
        DestroyImmediate(Stones[randomNumber]);
        StoneDictionary[removeStone] = null;
        Stones.RemoveAt(randomNumber);
    }

    public GameObject Create(StoneModel stoneModel)
    {
        GameObject obj = Instantiate(Stone, new Vector3(0, 0, 0), Quaternion.identity);
        Stone stone = obj.GetComponent<Stone>();
        stone.name = stoneModel.Name;
        stone.SetXBoard(stoneModel.X);
        stone.SetYBoard(stoneModel.Y);
        stone.SetZBoard(stoneModel.Z);
        stone.Activate();
        return obj;
    }

    public void SetStone(GameObject obj)
    {
        if (obj == null)
        {
            return;
        }

        StoneDictionary[obj.name] = obj;
    }

    public void SetStoneEmpty(string key)
    {
        StoneDictionary[key] = null;
    }

    public GameObject GetStone(string key)
    {
        return StoneDictionary[key];
    }
}