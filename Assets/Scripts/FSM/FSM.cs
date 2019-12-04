using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FSM : MonoBehaviour
{
    private List<IBehaviourState> _currentStates = new List<IBehaviourState>();

    public void StartState(IBehaviourState newState)
    {
        if (!CanStartEvent(newState)) return;
        newState.Start();
        _currentStates.Add(newState);
    }
    
    public void StartState<T>() where T : IBehaviourState, new()
    {
        if (!CanStartEvent<T>()) return;
        var state = new T();
        state.Start();
        _currentStates.Add(state);
    }

    public void ChangeStateToFrom(IBehaviourState newState,IBehaviourState currentlyState)
    {
        if (!CanStartEvent(newState)) return;
        
        var current = GetState(currentlyState.GetType());
        
        if (current != null)
        {
            current.Exit();
            _currentStates.Remove(current);
        }
        StartState(newState);

    }

    public void ChangeStateToFrom<TNewState,TCurrentState>() where TCurrentState : IBehaviourState where TNewState : IBehaviourState, new()
    {
        if (!CanStartEvent<TNewState>()) return;

        StopState<TCurrentState>();
        StartState<TNewState>();
    }

    public void RestartState<T>() where T : IBehaviourState, new()
    {
        StopState<T>();
        StartState<T>();
    }

    public void StopState<T>() where T : IBehaviourState
    {
        var current = GetState<T>();
        if (current == null)
        {
            Debug.LogWarning($"Trying to Stop {typeof(T)} : This state does not exist!");
            return;
        }
        current.Exit();
        _currentStates.Remove(current);
    }

    private bool CanStartEvent(IBehaviourState newState)
    {
        var response = _currentStates.All(state => state.GetType() != newState.GetType());
        if(!response) Debug.LogError($"Trying to Start {newState.GetType()} : This event already exist! Use FSM.Restart() method instead.");
        return response;
    }    
    
    private bool CanStartEvent<T>() where T : IBehaviourState
    {
        var response = _currentStates.All(state => state.GetType() != typeof(T));
        if(!response) Debug.LogError($"Trying to Start {typeof(T)} : This event already exist! Use FSM.Restart() method instead.");
        return response;
    }

    private IBehaviourState GetState<T>() where T : IBehaviourState
    {
        return _currentStates.First(state => state.GetType() == typeof(T));
    }
    
    private IBehaviourState GetState(Type stateType)
    {
        return _currentStates.First(state => state.GetType() == stateType);
    }

    // Update is called once per frame
    private void Update()
    {
        _currentStates.ForEach(state => state.Update()); 
    }
}