using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using UnityEngine.UI;
using Firebase;

public class RealtimeDatabase : MonoBehaviour
{
    DatabaseReference reference;
    User userDetails = new User();
    [SerializeField] InputField _Username;
    [SerializeField] InputField _Email;

    // Start is called before the first frame update
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        User userDetails = new User();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Write()
    {
        userDetails._username = _Username.text;
        userDetails._emailID = _Email.text;
 
        string json = JsonUtility.ToJson(userDetails);


        reference.Child("Players").Child(userDetails._username).SetRawJsonValueAsync(json).ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("Write Successful");
            }
        });
    }
}
