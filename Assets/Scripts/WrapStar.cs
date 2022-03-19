using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapStar : MonoBehaviour
{
    private float canvasH = 100;

    // Start is called before the first frame update
    void Start()
    {
        // prevent errors in Update(), we're gonna be calling orthographic camera properties
        Camera.main.orthographic = true;

        Canvas canvas = FindObjectOfType<Canvas>();
        
        canvasH = canvas.GetComponent<RectTransform>().rect.height;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < canvasH / 2)
            transform.position = new Vector3(transform.position.x, canvasH / 2, transform.position.z);
    }
}
