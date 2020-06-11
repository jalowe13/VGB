using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveCheck : MonoBehaviour
{
    Material material; //Default Dissolve Material

    bool isDissolving = false;
    float fade = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //Material Ref

        material = Resources.Load("Dissolve") as Material; //Default Dissolve Light
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            GetComponent<SpriteRenderer>().material = material;
            isDissolving = true;
        }

        if (isDissolving)
        {
            fade -= Time.deltaTime;

            if (fade <= 0f)
            {
                fade = 0f;
                isDissolving = false;
            }

            //Property Set

            material.SetFloat("_Fade", fade);
        }
    }
}
