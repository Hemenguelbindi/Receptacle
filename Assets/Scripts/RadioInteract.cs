using Script.Move;
using TMPro;
using UnityEngine;

public class RadioInteract : MonoBehaviour
{
    public TextMeshProUGUI text;
    public PlayerMove move;

    AudioSource connection;

    bool isConnection;

    [SerializeField] float _timer;

    private void Start()
    {
        connection = GetComponent<AudioSource>();
        move = FindFirstObjectByType<PlayerMove>();
        isConnection = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.gameObject.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F) && isConnection == false)
            {
                connection.Play();
                text.gameObject.SetActive(false);
                move._canMove = false;
                isConnection = true;
            }
        }
    }

    private void Update()
    {
        if (isConnection == true)
        {
            _timer += Time.deltaTime;

            if (_timer >= 61f)
            {
                isConnection = false;
                move._canMove = true;
                _timer = 0;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.gameObject.SetActive(false);
        }
    }
}

