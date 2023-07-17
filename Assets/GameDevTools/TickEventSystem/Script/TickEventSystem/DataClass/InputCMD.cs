using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCMD
{
    public int Active_ID;
    public int Order;
    public string[] CMD;
    public int[] CMD_Short;
    public int[] CMD_Long;
    public Dictionary<string, List<string>> CMD_Ban;
    public string[] CMD_Tags;
    public bool CleanBuffer;
}