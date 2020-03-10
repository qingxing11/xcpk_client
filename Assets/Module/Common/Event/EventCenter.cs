/*
 * Advanced C# messenger by Ilya Suzdalnitski. V1.0
 * 
 * Based on Rod Hyde's "CSharpMessenger" and Magnus Wolffelt's "CSharpMessenger Extended".
 * 
 * Features:
 	* Prevents a MissingReferenceException because of a reference to a destroyed message handler.
 	* Option to log all messages
 	* Extensive error detection, preventing silent bugs
 * 
 * Usage examples:
 	1. Messenger.AddListener<GameObject>("prop collected", PropCollected);
 	   Messenger.Broadcast<GameObject>("prop collected", prop);
 	2. Messenger.AddListener<float>("speed changed", SpeedChanged);
 	   Messenger.Broadcast<float>("speed changed", 0.5f);
 * 
 * Messenger cleans up its evenTable automatically upon loading of a new level.
 * 
 * Don't forget that the messages that should survive the cleanup, should be marked with Messenger.MarkAsPermanent(string)
 * 
 */

//#define LOG_ALL_MESSAGES
//#define LOG_ADD_LISTENER
//#define LOG_BROADCAST_MESSAGE
#define REQUIRE_LISTENER

using System;
using System.Collections.Generic;
using UnityEngine;
//using GouGou;

static internal class EventCenter
{

    //Disable the unused variable warning
#pragma warning disable 0414
    //Ensures that the MessengerHelper will be created automatically upon start of the game.
    //	static private MessengerHelper mMessengerHelper = ( new GameObject("MessengerHelper") ).AddComponent< MessengerHelper >();
#pragma warning restore 0414

    private static readonly Dictionary<EventDefine, Delegate> _mEventTable = new Dictionary<EventDefine, Delegate>();

    //Message handlers that should never be removed, regardless of calling Cleanup
    public static List<EventDefine> MPermanentMessages = new List<EventDefine>();


    //Marks a certain message as permanent.
    public static void MarkAsPermanent(EventDefine eventType)
    {
#if LOG_ALL_MESSAGES
		Debug.Log("Messenger MarkAsPermanent \t\"" + eventType + "\"");
#endif

        MPermanentMessages.Add(eventType);
    }


    static public void Cleanup()
    {
#if LOG_ALL_MESSAGES
		Debug.Log("MESSENGER Cleanup. Make sure that none of necessary listeners are removed.");
#endif

        List<EventDefine> messagesToRemove = new List<EventDefine>();

        foreach (KeyValuePair<EventDefine, Delegate> pair in _mEventTable)
        {
            bool wasFound = false;

            foreach (EventDefine message in MPermanentMessages)
            {
                if (pair.Key == message)
                {
                    wasFound = true;
                    break;
                }
            }

            if (!wasFound)
                messagesToRemove.Add(pair.Key);
        }

        foreach (EventDefine message in messagesToRemove)
        {
            _mEventTable.Remove(message);
        }
    }

    public static void PrEGameEventEventTable()
    {
        UnityEngine.Debug.Log("\t\t\t=== MESSENGER PrEGameEventEventTable ===");

        foreach (KeyValuePair<EventDefine, Delegate> pair in _mEventTable)
        {
            UnityEngine.Debug.Log("\t\t\t" + pair.Key + "\t\t" + pair.Value);
        }

        UnityEngine.Debug.Log("\n");
    }

    public static void OnListenerAdding(EventDefine eventType, Delegate listenerBeingAdded)
    {
#if LOG_ALL_MESSAGES || LOG_ADD_LISTENER
		Debug.Log("MESSENGER OnListenerAdding \t\"" + eventType + "\"\t{" + listenerBeingAdded.Target + " -> " + listenerBeingAdded.Method + "}");
#endif

        if (!_mEventTable.ContainsKey(eventType))
        {
            _mEventTable.Add(eventType, null);
        }

        Delegate d = _mEventTable[eventType];
        if (d != null && d.GetType() != listenerBeingAdded.GetType())
        {
            throw new ListenerException(string.Format("Attempting to add listener with inconsistent signature for event type {0}. Current listeners have type {1} and listener being added has type {2}", eventType, d.GetType().Name, listenerBeingAdded.GetType().Name));
        }
    }

    static public void OnListenerRemoving(EventDefine eventType, Delegate listenerBeingRemoved)
    {
#if LOG_ALL_MESSAGES
		Debug.Log("MESSENGER OnListenerRemoving \t\"" + eventType + "\"\t{" + listenerBeingRemoved.Target + " -> " + listenerBeingRemoved.Method + "}");
#endif

        if (_mEventTable.ContainsKey(eventType))
        {
            Delegate d = _mEventTable[eventType];

            if (d == null)
            {
                throw new ListenerException(string.Format("Attempting to remove listener with for event type \"{0}\" but current listener is null.", eventType));
            }
            else if (d.GetType() != listenerBeingRemoved.GetType())
            {
                throw new ListenerException(string.Format("Attempting to remove listener with inconsistent signature for event type {0}. Current listeners have type {1} and listener being removed has type {2}", eventType, d.GetType().Name, listenerBeingRemoved.GetType().Name));
            }
        }
        else
        {
            throw new ListenerException(string.Format("Attempting to remove listener for type \"{0}\" but Messenger doesn't know about this event type.", eventType));
        }
    }

    static public void OnListenerRemoved(EventDefine eventType)
    {
        //foreach (var item in _mEventTable)
        //{
        //    Debug.Log("OnListenerRemove00000:" + item);
        //}

        if (_mEventTable[eventType] == null)
        {
            _mEventTable.Remove(eventType);
        }

        //foreach (var item in _mEventTable)
        //{
        //    Debug.Log("OnListenerRemoved11111:"+item);
        //}
    }

    static public void OnBroadcasting(EventDefine eventType)
    {
#if REQUIRE_LISTENER
        if (!_mEventTable.ContainsKey(eventType))
        {
        }
#endif
    }

    static public BroadcastException CreateBroadcastSignatureException(EventDefine eventType)
    {
        return new BroadcastException(string.Format("Broadcasting message \"{0}\" but listeners have a different signature than the broadcaster.", eventType));
    }

    public class BroadcastException : Exception
    {
        public BroadcastException(string msg)
            : base(msg)
        {
        }
    }

    public class ListenerException : Exception
    {
        public ListenerException(string msg)
            : base(msg)
        {
        }
    }

    //No parameters
    static public void AddListener(EventDefine eventType, Callback handler)
    {
        OnListenerAdding(eventType, handler);
        _mEventTable[eventType] = (Callback)_mEventTable[eventType] + handler;
    }

    //Single parameter
    static public void AddListener<T>(EventDefine eventType, Callback<T> handler)
    {
        OnListenerAdding(eventType, handler);
        _mEventTable[eventType] = (Callback<T>)_mEventTable[eventType] + handler;
    }

    //Two parameters
    static public void AddListener<T, U>(EventDefine eventType, Callback<T, U> handler)
    {
        OnListenerAdding(eventType, handler);
        _mEventTable[eventType] = (Callback<T, U>)_mEventTable[eventType] + handler;
    }

    //Three parameters
    static public void AddListener<T, U, V>(EventDefine eventType, Callback<T, U, V> handler)
    {
        OnListenerAdding(eventType, handler);
        _mEventTable[eventType] = (Callback<T, U, V>)_mEventTable[eventType] + handler;
    }

    //Four parameters
    static public void AddListener<T, U, V, X>(EventDefine eventType, Callback<T, U, V, X> handler)
    {
        OnListenerAdding(eventType, handler);
        _mEventTable[eventType] = (Callback<T, U, V, X>)_mEventTable[eventType] + handler;
    }

    //	//four parameters
    //	static public void AddListener<T, U, V>(EEventDefine eventType, Callback<T, U, V, X> handler) {
    //        OnListenerAdding(eventType, handler);
    //        mEventTable[eventType] = (Callback<T, U, V, X>)mEventTable[eventType] + handler;
    //    }
    //	
    //	//five parameters
    //	static public void AddListener<T, U, V>(EEventDefine eventType, Callback<T, U, V, X, Y> handler) {
    //        OnListenerAdding(eventType, handler);
    //        mEventTable[eventType] = (Callback<T, U, V, X, Y>)mEventTable[eventType] + handler;
    //    }
    //	
    //	//six parameters
    //	static public void AddListener<T, U, V>(EEventDefine eventType, Callback<T, U, V, X, Y, Z> handler) {
    //        OnListenerAdding(eventType, handler);
    //        mEventTable[eventType] = (Callback<T, U, V, X, X, Y, Z>)mEventTable[eventType] + handler;
    //    }

    //No parameters
    static public void RemoveListener(EventDefine eventType, Callback handler)
    {
        OnListenerRemoving(eventType, handler);
        _mEventTable[eventType] = (Callback)_mEventTable[eventType] - handler;
        OnListenerRemoved(eventType);
    }

    //Single parameter
    static public void RemoveListener<T>(EventDefine eventType, Callback<T> handler)
    {
        OnListenerRemoving(eventType, handler);
        _mEventTable[eventType] = (Callback<T>)_mEventTable[eventType] - handler;
        OnListenerRemoved(eventType);
    }

    //Two parameters
    static public void RemoveListener<T, U>(EventDefine eventType, Callback<T, U> handler)
    {
        OnListenerRemoving(eventType, handler);
    
        _mEventTable[eventType] = (Callback<T, U>)_mEventTable[eventType] - handler;
        
        OnListenerRemoved(eventType);
    }

    //Three parameters
    static public void RemoveListener<T, U, V>(EventDefine eventType, Callback<T, U, V> handler)
    {
        OnListenerRemoving(eventType, handler);
        _mEventTable[eventType] = (Callback<T, U, V>)_mEventTable[eventType] - handler;
        OnListenerRemoved(eventType);
    }

    //Four parameters
    static public void RemoveListener<T, U, V, X>(EventDefine eventType, Callback<T, U, V, X> handler)
    {
        OnListenerRemoving(eventType, handler);
        _mEventTable[eventType] = (Callback<T, U, V, X>)_mEventTable[eventType] - handler;
        OnListenerRemoved(eventType);
    }

    //	//Four parameters
    //	static public void RemoveListener<T, U, V>(EEventDefine eventType, Callback<T, U, V, X> handler) {
    //        OnListenerRemoving(eventType, handler);
    //        mEventTable[eventType] = (Callback<T, U, V, X>)mEventTable[eventType] - handler;
    //        OnListenerRemoved(eventType);
    //    }
    //	
    //	//Five parameters
    //	static public void RemoveListener<T, U, V>(EEventDefine eventType, Callback<T, U, V, X, Y> handler) {
    //        OnListenerRemoving(eventType, handler);
    //        mEventTable[eventType] = (Callback<T, U, V, X, Y>)mEventTable[eventType] - handler;
    //        OnListenerRemoved(eventType);
    //    }
    //	
    //	//Six parameters
    //	static public void RemoveListener<T, U, V>(EEventDefine eventType, Callback<T, U, V, X, Y, Z> handler) {
    //        OnListenerRemoving(eventType, handler);
    //        mEventTable[eventType] = (Callback<T, U, V, X, Y, Z>)mEventTable[eventType] - handler;
    //        OnListenerRemoved(eventType);
    //    }
    //	
    //No parameters
    static public void Broadcast(EventDefine eventType)
    {
#if LOG_ALL_MESSAGES || LOG_BROADCAST_MESSAGE
		Debug.Log("MESSENGER\t" + System.DateTime.Now.ToString("hh:mm:ss.fff") + "\t\t\tInvoking \t\"" + eventType + "\"");
#endif
        OnBroadcasting(eventType);

        Delegate d;
        if (_mEventTable.TryGetValue(eventType, out d))
        {
            Callback callback = d as Callback;

            if (callback != null)
            {
                callback();
            }
            else
            {
                throw CreateBroadcastSignatureException(eventType);
            }
        }
    }

//    static public void SendEvent(CEvent evt)
//    {
//        Broadcast<CEvent>(evt.GetEventId(), evt);
//    }

    //Single parameter
    static public void Broadcast<T>(EventDefine eventType, T arg1)
    {
#if LOG_ALL_MESSAGES || LOG_BROADCAST_MESSAGE
		Debug.Log("MESSENGER\t" + System.DateTime.Now.ToString("hh:mm:ss.fff") + "\t\t\tInvoking \t\"" + eventType + "\"");
#endif
        OnBroadcasting(eventType);

        Delegate d;
        if (_mEventTable.TryGetValue(eventType, out d))
        {

            Callback<T> callback = d as Callback<T>;

            if (callback != null)
            {
                callback(arg1);
            }
            else
            {
                d.DynamicInvoke(new object[] { arg1 });
                //                throw CreateBroadcastSignatureException(eventType);
            }
        }
    }

    //Two parameters
    static public void Broadcast<T, U>(EventDefine eventType, T arg1, U arg2)
    {
#if LOG_ALL_MESSAGES || LOG_BROADCAST_MESSAGE
		Debug.Log("MESSENGER\t" + System.DateTime.Now.ToString("hh:mm:ss.fff") + "\t\t\tInvoking \t\"" + eventType + "\"");
#endif
        OnBroadcasting(eventType);

        Delegate d;
        if (_mEventTable.TryGetValue(eventType, out d))
        {
            Callback<T, U> callback = d as Callback<T, U>;

            if (callback != null)
            {
                callback(arg1, arg2);
            }
            else
            {
                throw CreateBroadcastSignatureException(eventType);
            }
        }
    }

    //Three parameters
    static public void Broadcast<T, U, V>(EventDefine eventType, T arg1, U arg2, V arg3)
    {
#if LOG_ALL_MESSAGES || LOG_BROADCAST_MESSAGE
		Debug.Log("MESSENGER\t" + System.DateTime.Now.ToString("hh:mm:ss.fff") + "\t\t\tInvoking \t\"" + eventType + "\"");
#endif
        OnBroadcasting(eventType);

        Delegate d;
        if (_mEventTable.TryGetValue(eventType, out d))
        {
            Callback<T, U, V> callback = d as Callback<T, U, V>;

            if (callback != null)
            {
                callback(arg1, arg2, arg3);
            }
            else
            {
                throw CreateBroadcastSignatureException(eventType);
            }
        }
    }

    //Four parameters
    static public void Broadcast<T, U, V, X>(EventDefine eventType, T arg1, U arg2, V arg3, X arg4)
    {
#if LOG_ALL_MESSAGES || LOG_BROADCAST_MESSAGE
		Debug.Log("MESSENGER\t" + System.DateTime.Now.ToString("hh:mm:ss.fff") + "\t\t\tInvoking \t\"" + eventType + "\"");
#endif
        OnBroadcasting(eventType);

        Delegate d;
        if (_mEventTable.TryGetValue(eventType, out d))
        {
            Callback<T, U, V, X> callback = d as Callback<T, U, V, X>;

            if (callback != null)
            {
                callback(arg1, arg2, arg3, arg4);
            }
            else
            {
                throw CreateBroadcastSignatureException(eventType);
            }
        }
    }
}
/*
//This manager will ensure that the messenger's mEventTable will be cleaned up upon loading of a new level.
public sealed class MessengerHelper : MonoBehaviour {
   void Awake ()
   {
       DontDestroyOnLoad(gameObject);	
   }

   //Clean up mEventTable every time a new level loads.
   public void OnDisable() {
       Messenger.Cleanup();
   }
}
*/
