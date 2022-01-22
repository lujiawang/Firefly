using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressUI : MonoBehaviour
{
    private PressArea[] allPress;

    private PressArea _pressArea;
    public int ID = 0;

    private RawImage image;

    // Start is called before the first frame update
    void Start()
    {
        allPress = GameObject.FindObjectsOfType<PressArea>();
        foreach(PressArea pa in allPress)
        {
            if (pa.ID == ID)
            {
                _pressArea = pa;
                break;
            }
        }
        if (_pressArea == null)
        {
            this.enabled = false;
        }
        image = this.gameObject.GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {

        if (_pressArea.pressed)
        {
            image.color = Color.black;
            this.enabled = false;
        }
    }
}
