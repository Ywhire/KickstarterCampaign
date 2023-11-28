using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Vector3 target = transform.InverseTransformPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        target.z = 0;

        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg + -90;
        transform.Rotate(0, 0, angle);
    }

}
