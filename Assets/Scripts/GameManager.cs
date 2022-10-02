using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject Ball;

    [SerializeField] private GameObject Ring1;
    [SerializeField] private GameObject Ring2;
    [SerializeField] private GameObject Ring3;
    [SerializeField] private GameObject Ring4;
    [SerializeField] private GameObject Ring5;

    [SerializeField] private GameObject _playButton;

    List<GameObject> Rings = new List<GameObject>();
    private float _newPosition = -10f;

    private void Awake()
    {
        Time.timeScale = 0f;
    }
    void Start()
    {
        Rings.AddRange(new GameObject[] {Ring1, Ring2, Ring3, Ring4, Ring5});

        Ring1.transform.position = new Vector3(0f, 5f, 0f);
        Ring2.transform.position = new Vector3(0f, 2f, 0f);
        Ring3.transform.position = new Vector3(0f, -1f, 0f);
        Ring4.transform.position = new Vector3(0f, -4f, 0f);
        Ring5.transform.position = new Vector3(0f, -7f, 0f);
    }

    void Update()
    {
        foreach (GameObject ring in Rings)
        {
            if(ring.transform.position.y > Ball.transform.position.y + 3f)
            {
                ring.transform.position = new Vector3(0f, _newPosition, 0f);
                _newPosition -= 3f;
            }
        }
    }
    public void Play_Button()
    {
        Time.timeScale = 1.3f;
        _playButton.SetActive(false);

    }
    public void Restart_Button()
    {
        SceneManager.LoadScene(0);
    }
}
