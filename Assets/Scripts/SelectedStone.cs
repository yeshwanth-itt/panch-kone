using Assets.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectedStone : MonoBehaviour
{
    public Material originalMaterial;
    private Transform selection;

    public Color startColor = Color.gray;
    public Color endColor = Color.gray;
    [Range(0, 10)]
    public float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (selection != null && selection.GetComponent<MeshRenderer>().tag == "Stone")
        {
            selection.GetComponent<MeshRenderer>().material.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * speed, 1));
        }

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit rayCastHit))
            {
                if (selection != null)
                {
                    selection.GetComponent<MeshRenderer>().material = originalMaterial;
                }

                selection = rayCastHit.transform;
            }
        }
    }
}
