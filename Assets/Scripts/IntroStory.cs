using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroStory : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [TextArea]
    [SerializeField] string story;
    [SerializeField] float textSpeed;

    float progress = 0;
    string currentString = "";
    private bool active = false;

    // Update is called once per frame
    void Update()
    {
        if (!active)
            return;

        float advancement = Time.deltaTime * textSpeed;
        if (advancement < 1)
            progress += advancement;
        else
            progress += 1;

        int charsShown = Mathf.FloorToInt(progress);

        if (charsShown < story.Length)
        {
            if (charsShown >= currentString.Length)
            {
                currentString += story[charsShown];
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                progress = story.Length;
                currentString = story;
            }
        }
        text.text = currentString;
    }

    public void play()
    {
        active = true;
    }
}
