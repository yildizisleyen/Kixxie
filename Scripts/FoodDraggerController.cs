using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using Random = UnityEngine.Random;

public class FoodDraggerController : MonoBehaviour
{
    //public static FoodDraggerController Instance { get; private set; }
    private Vector3 _dragOffset;
    private Camera _cam;
    [SerializeField] private int _speed;
    private Rigidbody2D _rigidbody;
    private bool isCollision = false;
    [SerializeField]
    private float amp;
    [SerializeField]
    private float freq;
    private Vector3 _startpos;
    private float vecXmin = -4.5f;
    private float vecXmax = -3.3f;
    [SerializeField]
    private float _foodSpeed;
    private float posY;
    [SerializeField]
    private float _maxRotate;
    private float _speedRotate = 1.5f;


    private void Awake()
    {
        //_collider = GetComponent<CircleCollider2D>();
        //Instance = this;
        _cam = Camera.main;
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _startpos = this.gameObject.transform.position;
        Debug.Log(_startpos);
    }
    private void FixedUpdate()
    {
        if (isCollision == true)
        {
            Movement(0f);
        }else if (_startpos.x > vecXmin && _startpos.x < vecXmax)
        {
            Movement(1f);
        }
        else
        {
            Movement(-1f);
        }
        
    }
    public void Movement(float posX)
    {
        posY = (Mathf.Sin(Time.time * freq) * amp);
        float posXwSpeed = posX * _foodSpeed;
        if(KittyController.Instance._count >= 4)
        {
            posXwSpeed *= 1.8f;
            Debug.Log("FAST SPEED:" + posXwSpeed);
        }
        _rigidbody.velocity = new Vector3(posXwSpeed, posY, 0);
        var step = posY * _speedRotate;
        transform.rotation = Quaternion.Euler(0f, 0f, _maxRotate * step);  
    }
  
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("HIT");
        if(other.gameObject.CompareTag("Cat")) 
        {
            isCollision = true;
        }
    }
    private void OnMouseDown()
    {
        _dragOffset = transform.position - GetMousePos();
    }
    private void OnMouseDrag()
    {
        var target = GetMousePos() + _dragOffset;
        var set = _speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, set);
        //transform.position = GetMousePos() + _dragOffset;
    }
    Vector3 GetMousePos()
    {
        var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition); //Camera.main þeklinde kullanmak yavaþlattýðý için deðiþiklik yapýldý
        mousePos.z = 0;
        return mousePos;
    }
    

}
