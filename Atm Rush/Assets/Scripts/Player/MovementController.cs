using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class MovementController : Singleton<MovementController>
{
    public float _limitX = 2;
    public float _xSpeed = 25;
    public float _forwardSpeed = 2;
    public float _waveSpeed = .1f;
    public float _waveScale = .1f;

    // Update is called once per frame
    void Update()
    {

        float _touchXDelta = 0;
        float _newX = 0;
        if (Input.GetMouseButton(0))
        {
            _touchXDelta = Input.GetAxis("Mouse X");
        }
        _newX = transform.position.x + _xSpeed * _touchXDelta * Time.deltaTime;
        _newX = Mathf.Clamp(_newX, -_limitX, _limitX);



        Vector3 newPosition = new Vector3(_newX, transform.position.y, transform.position.z + _forwardSpeed * Time.deltaTime);
        transform.position = newPosition;

        for (int i = 1; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            child.DOMoveX(transform.position.x, (i * .2f));
            
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(WaveMoney());
        }
    }

    public void StartWaveMoney()
    {
        StartCoroutine(WaveMoney());
    }

    IEnumerator WaveMoney()
    {
        for (int i = 1; i < transform.childCount; i++)
        {
            transform.GetChild(i).localScale += new Vector3(_waveScale, _waveScale, _waveScale);
            yield return new WaitForSeconds(_waveSpeed);
            transform.GetChild(i).localScale -= new Vector3(_waveScale, _waveScale, _waveScale);
        }
        
    }
}