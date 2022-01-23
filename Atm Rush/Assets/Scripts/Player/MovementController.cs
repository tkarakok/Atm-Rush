using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class MovementController : Singleton<MovementController>
{
    public Animator animator;
    [SerializeField] private float _limitX = 2;
    [SerializeField] private float _xSpeed = 25;
    [SerializeField] private float _forwardSpeed = 2;
    [SerializeField] private float _waveSpeed = .1f;
    [SerializeField] private float _waveScale = .1f;
    
    // Update is called once per frame
    void Update()
    {
        if (StateManager.Instance.state == State.InGame)
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
        }
        
    }


    #region Money Wave

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
    #endregion
}