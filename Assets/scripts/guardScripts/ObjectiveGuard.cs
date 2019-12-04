using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveGuard : MonoBehaviour
{
    // Start is called before the first frame update
    public float step;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos3d = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 vecDiff = mousePos3d - transform.position;
        
        if(vecDiff.magnitude > 0.5f)
        {
            Vector2 movVector = vecDiff.normalized * step * Time.deltaTime;
            transform.Translate(movVector);
        } 
    }
}
