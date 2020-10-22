using UnityEngine;
using System.Collections;

public class RealBox : MonoBehaviour
{
    public GameObject BoxReal;
    public GameObject BoxShadow;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        BoxReal.transform.position = new Vector3(BoxShadow.transform.position.x, BoxReal.transform.position.y);
    }
}