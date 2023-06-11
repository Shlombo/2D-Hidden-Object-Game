using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenManager : MonoBehaviour
{
    
    private static HiddenManager _instance;

    public static HiddenManager Instance {
        get{
            if(_instance == null) {
                Debug.LogError("HiddenManager is null");
            }
            return _instance;
        }
    }
    
    [SerializeField]
    public List<GameObject> hiddenObjects = new List<GameObject>();
    
    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
