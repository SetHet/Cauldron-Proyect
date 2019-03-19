﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    #region Basic Methods
    private void Awake()
    {
        Singleton();
    }
    #endregion

    #region Singleton
    protected static PlayerInput _current;
    public static PlayerInput current { get { return _current; } }
    public void Singleton()
    {
        if (_current != null)
        {
            Debug.LogWarning("Hay 2 Input Player");
            Destroy(gameObject);
            return;
        }

        _current = this;
    }
    #endregion

    #region Variables
    public NameInputs nameInputs = new NameInputs();
    [System.Serializable]
    public class NameInputs
    {
        public string MoverLateral = "Horizontal";
        public string MoverFrontal = "Vertical";
        public string Jump = "Jump";
    }
    #endregion

    #region Methods
    public Vector2 GetWalk()
    {
        return new Vector2(Input.GetAxis(nameInputs.MoverLateral), Input.GetAxis(nameInputs.MoverFrontal));
    }

    public bool isJump
    {
        get
        {
            return Input.GetButtonDown(nameInputs.Jump);
        }
    }
    #endregion
}