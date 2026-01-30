using System;

namespace SampleAssignment
{
    // Delegate definition
    public delegate void Notify();

    public class PhoneCall
    {
        // Event declaration
        public event Notify PhoneCallEvent;

        // Message property
        public string Message { get; private set; }

        // Constructor
        public PhoneCall()
        {
            Message = string.Empty;
        }

        // Private event handler for subscribe
        private void OnSubscribe()
        {
            Message = "Subscribed to Call";
        }

        // Private event handler for unsubscribe
        private void OnUnSubscribe()
        {
            Message = "UnSubscribed to Call";
        }

        // Event trigger method
        public void MakeAPhoneCall(bool notify)
        {
            PhoneCallEvent = null;

            if (notify)
            {
                PhoneCallEvent += OnSubscribe;
            }
            else
            {
                PhoneCallEvent += OnUnSubscribe;
            }

            // Safe event invocation
            PhoneCallEvent?.Invoke();
        }
    }

    public class TestPhoneCall
    {
        public static void Main()
        {
            PhoneCall call = new PhoneCall();

            call.MakeAPhoneCall(true);
            Console.WriteLine(call.Message);

            call.MakeAPhoneCall(false);
            Console.WriteLine(call.Message);
        }
    }
}

/*
▶️ Sample Execution

Input:
MakeAPhoneCall(true);
MakeAPhoneCall(false);

Output:
Subscribed to Call
UnSubscribed to Call
*/
