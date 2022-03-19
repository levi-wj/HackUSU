using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private float canvasH;
    
    // Start is called before the first frame update
    void Start()
    {
        RectTransform parentCanvas = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        canvasH = parentCanvas.rect.height;
    }

    // Update is called once per frame
    void Update()
    {        
        transform.Translate(new Vector3(0, -canvasH * Time.deltaTime, 0));
    }
}
