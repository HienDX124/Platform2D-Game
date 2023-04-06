using System.Collections;
using System.Collections.Generic;
using LTA.DesignPattern;
using UnityEngine;

// cái này dùng để tạo all prefab trong game (singleton)
public class CreateController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Creator : SingletonMonoBehaviour<CreateController>{}
