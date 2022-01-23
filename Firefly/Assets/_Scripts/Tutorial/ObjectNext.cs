using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectNext : MonoBehaviour
{
    public bool finished = false;
    private GameObject nextObject;

    // Start is called before the first frame update
    void Start()
    {
        int index = transform.GetSiblingIndex();
        if (index < transform.parent.childCount)
        {
            nextObject = transform.parent.GetChild(index + 1).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (finished)
        {
            this.gameObject.SetActive(false);
            nextObject.SetActive(true);
        }
    }
}
