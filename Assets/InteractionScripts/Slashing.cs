using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slashing : MonoBehaviour
{
    public  int NumberOfSlash = 10;
    public Slider progressBar;
    private int CurrentNumberOfSlash = 0;
    public GameObject NewObject;

    public void OnObjectExit()
    {
        if (Hand.HasObject())
            if (Hand.GetObject().tag == Tags.Knife_Tag)
            {
                Debug.Log("Slashing " + CurrentNumberOfSlash);
                progressBar.gameObject.SetActive(true);
                CurrentNumberOfSlash += 1;
                 progressBar.value = 100 * ((float)CurrentNumberOfSlash) / ((float)(NumberOfSlash-1));
                if (CurrentNumberOfSlash == NumberOfSlash)
                {
                    Instantiate(NewObject, transform.position, transform.rotation);
                    Destroy(gameObject);
                    progressBar.gameObject.SetActive(false);
                }
            }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
