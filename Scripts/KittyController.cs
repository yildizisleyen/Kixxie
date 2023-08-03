using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KittyController : MonoBehaviour
{
    public static KittyController Instance { get; private set; }
    [SerializeField] private GameObject _kittySmiling;
    private float _delay=0.7f;
    public int _count;
    public int _lives;
    private int _maxlive = 3;
    [SerializeField]
    private UIManager _uimanager;
    [SerializeField]
    private Spawn _spawnManager;
    [SerializeField]
    private GameObject _Sound;
    [SerializeField]
    private CapsuleCollider2D _collider;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        _Sound.SetActive(true);
        _kittySmiling.SetActive(false);
        _lives = 3;
        _count = 0;
        InvokeRepeating("timeBorder", 0.01f, 4f);
        _uimanager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if(_uimanager == null)
        {
            Debug.LogError("UI Manager is null!!");
        }
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<Spawn>();
        if(_spawnManager == null)
        {
            Debug.LogError("Spawn Manager is null!");
        }
        _collider = GetComponent<CapsuleCollider2D>();

    }
    private void FixedUpdate()
    {
        if(_lives <= 3 && _lives >= 0) 
        {
            livesUpdate();
        }
        
        Debug.Log("LIVES=" + _lives);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit: " + other.transform.name);
        if (other.gameObject.CompareTag("Food") || other.gameObject.CompareTag("Fish"))
        {
            _count++;
            _uimanager.Score(_count);
            StartCoroutine(kittySmiling());
            Destroy(other.gameObject,0.28f);
            _lives++;
            SoundManager.playSound("Meow");
        }
    }
    void timeBorder()
    {
        _lives--;
    }
    public void livesUpdate()
    {
        _uimanager.updateBar(_lives);
        if(_lives < 1)
        {
            _spawnManager.endOfGame();
        }
        if(_lives > _maxlive)
        {
            _lives = _maxlive;
        }
        if(_lives == 0)
        {
            _collider.enabled = false;
            CancelInvoke();
            StartCoroutine(_soundSetFalse());
        }
    }
    
    IEnumerator kittySmiling()
    {
        _kittySmiling.SetActive(true);
        yield return new WaitForSeconds(_delay);
        _kittySmiling.SetActive(false);
    }
    IEnumerator _soundSetFalse()
    {
        yield return new WaitForSeconds(2.5f);
        _Sound.SetActive(false);

    }
}
