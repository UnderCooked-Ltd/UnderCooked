using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbingFeedback : MonoBehaviour
{
    public  Material HighlightMaterial;
    private Material DefaultMaterial;

    public void OnObjectEnter()
    {
        gameObject.GetComponent<Renderer>().material = HighlightMaterial;
    }

    public void OnObjectExit()
    {
        gameObject.GetComponent<Renderer>().material = DefaultMaterial;
    }

    // Start is called before the first frame update
    void Start()
    {
        DefaultMaterial = gameObject.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
