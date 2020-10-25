using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toScence : MonoBehaviour
{

    public void scence(int scenceId)
    {
        SceneManager.LoadScene(scenceId);
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
