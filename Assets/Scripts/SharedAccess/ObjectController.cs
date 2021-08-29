using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [SerializeField] protected ObjectViev view;
    protected ObjectModel objModel;



    public virtual void Destruction() {
        view.Destruction();
    }
}
