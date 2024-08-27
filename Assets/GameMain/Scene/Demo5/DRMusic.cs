using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

public class DRMusic : DataRowBase
{
    public override int Id => m_Id;

    public int m_Id;
    public string AssetName { get; set; }
    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] colString = dataRowString.Split('\t');
        int index = 1;
        m_Id = int.Parse(colString[index++]);
        AssetName = colString[index++];
        return true;

    }
}
