using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecePositioning : MonoBehaviour
{
    public GameObject SafePiece;
    public GameObject UnsafePiece;
    List<int> Angles = new List<int>();
    List<GameObject> Pieces = new List<GameObject>();

    private float _rotateSpeed = 8f;
    private float _moveX;

    void Start()
    {
        Angles.AddRange(new int[] { 0, 45, 90, 135, 180, 225, 270, 315 });
        PieceCreation();
    }

    private void Update()
    {
        /*_moveX = Input.GetAxis("Mouse X");

        if(Input.GetMouseButton(0))
        {
            transform.Rotate(0f, _moveX * _rotateSpeed * Time.deltaTime, 0f);
        }*/
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            _moveX = Input.GetTouch(0).deltaPosition.x;
            transform.Rotate(0, -_moveX * _rotateSpeed * Time.deltaTime, 0);
        }
    }


    private void PieceCreation()
    {
        RandomAngulation(Angles);

        int NumberOfSafePieces = Random.Range(3, 5);
        
        for (int i=0; i<NumberOfSafePieces; i++)
        {
            Pieces.Add(Instantiate(SafePiece, transform.position, Quaternion.Euler(0, Angles[i], 0)));
            Pieces[i].transform.parent = gameObject.transform;
        }

        int NumberOfUnsafePieces = Random.Range(2, 4);

        for (int j = NumberOfSafePieces; j < NumberOfSafePieces + NumberOfUnsafePieces; j++)
        {
            Pieces.Add(Instantiate(UnsafePiece, transform.position, Quaternion.Euler(0, Angles[j], 0)));
            Pieces[j].transform.parent = gameObject.transform;
        }
    }
    private void RandomAngulation(List<int> Angles)
    {
        for(int i = 0; i < Angles.Count; i++)
        {
            int t = Angles[i];
            int r = Random.Range(0, Angles.Count - i);
            Angles[i] = Angles[i + r];
            Angles[i + r] = t;
        }
    }
    IEnumerator RandomPositioning(List<GameObject> Pieces, List<int> Angles)
    {
        yield return new WaitForSeconds(0.5f);

        RandomAngulation(Angles);

        for (int i = 0; i < Pieces.Count; i++)
        {
            Pieces[i].transform.rotation = Quaternion.Euler(0, Angles[i], 0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Ball")
        {
            StartCoroutine(RandomPositioning(Pieces, Angles));
        }
    }
}
