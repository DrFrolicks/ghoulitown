﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    List<bool> taskComplete = new List<bool>();
    List<string> taskName = new List<string>();

    void Start()
    {
        int i = 0;
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Task")) //Loop just sets an id for each task automatically and tracks their name and if they're done or not
        {
            taskComplete.Add(false);
            taskName.Add(o.gameObject.GetComponent<TaskScript>().taskName);
            o.gameObject.GetComponent<TaskScript>().setId(i);
            i += 1;
        }
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("GroupTask")) //Loop just sets an id for each task automatically and tracks their name and if they're done or not
        {
            taskComplete.Add(false);
            taskName.Add(o.gameObject.GetComponent<GroupTaskMaster>().taskName);
            o.gameObject.GetComponent<GroupTaskMaster>().setId(i);
            i += 1;
        }
    }

    public void taskUpdate(int id) //Updates tasks complete
    {
        taskComplete[id] = true;
    }

    void OnApplicationQuit()
    {
        for(int x = 0; x < taskComplete.Count; x+=1)
        {
            Debug.Log("Task: " + taskName[x] + "\nComplete: " + taskComplete[x]);
        }
    }


}
