using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGameStartScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameSaver.Instance.Commit();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
