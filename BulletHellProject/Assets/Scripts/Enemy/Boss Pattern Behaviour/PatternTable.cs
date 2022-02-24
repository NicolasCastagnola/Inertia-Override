using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternTable : MonoBehaviour
{
    LookUpTable<int, float> _lookUpTable;

    private void Start()
    {
        //_lookUpTable = new LookUpTable<int, float>(FactorySin);
    }

    //pattern
    float FactorySin(int value)
    {
        Debug.Log("Hago el calculo: ");
        return Mathf.Sin(value);
    }

    GameObject FactoryGO(string enemy)
    {
        return gameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Debug.Log(_lookUpTable.ReturnValue(1));

        if (Input.GetKeyDown(KeyCode.Alpha2))
            Debug.Log(_lookUpTable.ReturnValue(2));

        if (Input.GetKeyDown(KeyCode.Alpha3))
            Debug.Log(_lookUpTable.ReturnValue(3));

        if (Input.GetKeyDown(KeyCode.Alpha4))
            Debug.Log(_lookUpTable.ReturnValue(4));


    }
}
