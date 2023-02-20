using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientProvider : MonoBehaviour
{
    private Vector3 position;
    private Quaternion rotation;
    private float elapsed_time = 0.0f;
    public GameObject ingredient;
    public float timer_s = 1.0f;

    void Start()
    {
        position = new Vector3(ingredient.transform.position.x, ingredient.transform.position.y, ingredient.transform.position.z);
        rotation = new Quaternion (ingredient.transform.rotation.x, ingredient.transform.rotation.y, ingredient.transform.rotation.z, ingredient.transform.rotation.w);
    }

    void Update()
    {
        if (Mathf.Abs(position.x - ingredient.transform.position.x) >  0.1f)
        //if (Vector3.Distance(position, ingredient.transform.position) > 0.1f)
        {
            elapsed_time += Time.deltaTime;
            if(timer_s < elapsed_time)
            {
                GameObject n = Instantiate(ingredient);
                n.transform.position = position;
                n.transform.rotation = rotation;
                elapsed_time = 0.0f;
            }
        }
    }
}
