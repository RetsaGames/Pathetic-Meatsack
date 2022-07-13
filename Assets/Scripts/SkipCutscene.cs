using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkipCutscene : MonoBehaviour
{
    [SerializeField] GameObject txtObject;
    [SerializeField] Image img;
    [SerializeField] float fillSpeed = 1;
    [SerializeField] string scene;

    float filled = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Return))
        {
            txtObject.SetActive(true);
            filled += Time.deltaTime * fillSpeed;
        }
        else
        {
            txtObject.SetActive(false);
            filled = 0;
        }
        img.fillAmount = filled;

        if (filled > 1)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
