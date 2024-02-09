using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PrintTrial : MonoBehaviour
{
    public Transform paintbrush;
    CreateTrail creator;
    public Material trailMaterial;
    // Start is called before the first frame update
    void Start()
    {
        creator = GetComponent<CreateTrail>();
        Color color = Color.white;
        color.a = 0.0f;
        creator.trailPrefab.GetComponent<TrailRenderer>().startColor = color;
        creator.trailPrefab.GetComponent<TrailRenderer>().endColor = color;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = (paintbrush.position - Vector3.forward * 0.5f) * 0.25f;
        Color color = GameObject.Find("Paintbrush").GetComponent<CreateTrail>().color;
        creator.trailPrefab.GetComponent<TrailRenderer>().startColor = color;
        creator.trailPrefab.GetComponent<TrailRenderer>().endColor = color;
    }

    public void Print()
    {
        GameObject[] currentPrint = GameObject.FindGameObjectsWithTag("Saved Trail");
        foreach (GameObject go in currentPrint)
        {
            Destroy(go);
        }
    }
}