using System.Collections;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 0.25f;

    [SerializeField]
    private float _rayLength = 1.4f;

    [SerializeField]
    private float _rayOffsetX = 0.5f;

    [SerializeField]
    private float _rayOffsetY = 0.5f;

    [SerializeField]
    private float _moveCd = 0.5f;

    private Vector3 _targetPosition;
    private Vector3 _startPosition;
    private bool _moving;

    private Vector3 _xOffset;
    private Vector3 _yOffset;

    private Vector3 _zAxisOriginA;
    private Vector3 _zAxisOriginB;

    public void Start()
    {
        SwipeControl.LSwipe += TurnLeft;
        SwipeControl.RSwipe += TurnRight;       
        StartCoroutine(Move());
    }

    private void Update()
    {
        _yOffset = transform.position + transform.up * _rayOffsetY;
        _xOffset = transform.right * _rayOffsetX;
        _zAxisOriginA = _yOffset + _xOffset;
        _zAxisOriginB = _yOffset - _xOffset;

        if (_moving)
        {
            if (Vector3.Distance(_startPosition, transform.position) > 1f)
            {
                float x = Mathf.Round(_targetPosition.x);
                float y = Mathf.Round(_targetPosition.y);
                float z = Mathf.Round(_targetPosition.z);

                // transform.position = new Vector3(x, y, z);
                transform.DOMove(new Vector3(x, y, z), 0.4f).OnComplete(() =>
                {

                    transform.DOScaleY(1f, 0.1f).SetId(1);
                    _moving = false;

                    return;


                }).SetId(1);

            }

            transform.position += (_targetPosition - _startPosition) * _moveSpeed * Time.deltaTime;
        }
    }

    private void OnDestroy()
    {
        SwipeControl.LSwipe -= TurnLeft;
        SwipeControl.RSwipe -= TurnRight;
        DOTween.Kill(this);
    }

    private WaitForSeconds _cashedWait;

    private IEnumerator Move()
    {
        _cashedWait = new WaitForSeconds(_moveCd);
        while (true)
        {
            yield return _cashedWait;
            if (CanMove(transform.forward))
            {
                _targetPosition = transform.position + transform.forward;
                _startPosition = transform.position;
                transform.DOScaleY(0.9f, 0.1f).SetId(1);
                _moving = true;
            }
        }
    }

    private void TurnLeft()
    {
        transform.DORotate(new Vector3(0, -90f, 0), 0.2f, RotateMode.LocalAxisAdd).SetId(1);
        //transform.Rotate(0f, -90f, 0f);
    }

    private void TurnRight()
    {
        transform.DORotate(new Vector3(0, 90f, 0), 0.2f, RotateMode.LocalAxisAdd).SetId(1);
       // transform.Rotate(0f, 90f, 0f);
    }

    private bool CanMove(Vector3 direction)
    {
        if (direction.z != 0)
        {
            if (Physics.Raycast(_zAxisOriginA, direction, _rayLength)) return false;
            if (Physics.Raycast(_zAxisOriginB, direction, _rayLength)) return false;
        }
        return true;
    }
}