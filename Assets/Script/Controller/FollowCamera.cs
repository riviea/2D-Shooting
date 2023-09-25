using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Camera _camera;
    private GameObject _target;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        _target = GameObject.Find("Knight");
    }

    // Update is called once per frame
    void Update()
    {
        _camera.transform.position = new Vector3(_target.transform.position.x, _target.transform.position.y, -10);
        Debug.Log(_target.transform.position + "/" + _camera.transform.position);
    }
}
