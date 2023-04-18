/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;


public class UI_Assistant : MonoBehaviour
{

    private Text messageText;
    private TextWriter.TextWriterSingle textWriterSingle;
    private AudioSource talkingAudioSource;

    private List<string> messageList = new List<string>() {
        "Doctor: You've been in a coma for several weeks now, and we weren't sure if you were going to make it…",
        "Doctor: As you continue to recover, you may find that memories from the day of the incident start to come back to you.",
        "Doctor: It's not uncommon for coma patients to experience gaps in their memory, but with time, many are able to regain those lost memories…",
        "Doctor: Do you remember what happened ?",
        "Player: I’m not sure. It’s all still fuzzy to me.",
        "Doctor: Well, let me fill you in. You had a pretty eventful day before you fell into the coma.",
        "Doctor: You woke up at home and got ready for work, just like any other day. You're a high school chemistry teacher and you went to teach your chemistry class…",
        "Doctor: After work, you decided to visit the local art gallery and while you were there, you fell into the coma.",
        "Player: It’s slowly coming back to me.",
        "Doctor: Good to hear. During your coma, we ran some tests and found that there were chemicals present in your bloodstream. Do you remember being exposed to any chemicals or inhaling any fumes that day?",
        "Player: I do remember something about a chemical exploding in the chemistry lab at school. Could that be related?",
        "Doctor: Yes, it's likely. The explosion could have caused a release of toxic fumes that you unknowingly inhaled.",
        "Doctor: That could explain the presence of the chemicals in your bloodstream. It's fortunate that we were able to identify the cause of your coma and treat you accordingly.",
        "Doctor: You're going to need some time to recover, but you're going to be okay.",
        "Doctor: I'm glad you were able to regain your memories.",

    };
    private int currentMessageIndex = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;

    }

    private void Awake()
    {
        messageText = transform.Find("message").Find("messageText").GetComponent<Text>();
        talkingAudioSource = transform.Find("talkingSound").GetComponent<AudioSource>();

        transform.Find("message").GetComponent<Button_UI>().ClickFunc = () => {
            if (textWriterSingle != null && textWriterSingle.IsActive())
            {
                // Currently active TextWriter
                textWriterSingle.WriteAllAndDestroy();
            }
            else
            {
                if (currentMessageIndex >= messageList.Count)
                {
                    SceneManager.LoadScene(7);
                    currentMessageIndex = 0;

                }
                string message = messageList[currentMessageIndex];
                currentMessageIndex++;

                textWriterSingle = TextWriter.AddWriter_Static(messageText, message, .02f, true, true, StopTalkingSound);
            }
        };
    }



    private void StopTalkingSound()
    {
        talkingAudioSource.Stop();
    }

}

