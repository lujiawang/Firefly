using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoldUI : MonoBehaviour
{
    private HoldArea[] allHold;

    private HoldArea _holdArea;
    public int ID = 0;

    private RawImage image;

    // Start is called before the first frame update
    void Start()
    {
        allHold = GameObject.FindObjectsOfType<HoldArea>();
        foreach(HoldArea ha in allHold)
        {
            if (ha.ID == ID)
            {
                _holdArea = ha;
                break;
            }
        }
        if (_holdArea == null)
        {
            this.enabled = false;
        }
        image = this.gameObject.GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_holdArea.held)
        {
            image.color = Color.black;
            this.enabled = false;
        }
    }
}
