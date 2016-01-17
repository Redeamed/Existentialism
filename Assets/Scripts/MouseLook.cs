using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

   [SerializeField] private float sensibility;

    void Start()
    {

    }

    void Update()
    {
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * sensibility, 0), Space.World);
        transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y") * sensibility, 0, 0));

    }
}
