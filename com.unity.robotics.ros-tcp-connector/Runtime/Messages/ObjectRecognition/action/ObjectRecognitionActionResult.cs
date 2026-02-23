using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
#if !ROS2
using RosMessageTypes.Std;
using RosMessageTypes.Actionlib;
#endif

namespace RosMessageTypes.ObjectRecognition
{
    public class ObjectRecognitionActionResult : ActionResult<ObjectRecognitionResult>
    {
        public const string k_RosMessageName = "object_recognition_msgs-master/ObjectRecognitionActionResult";
        public override string RosMessageName => k_RosMessageName;


        public ObjectRecognitionActionResult() : base()
        {
            this.result = new ObjectRecognitionResult();
        }

#if !ROS2
        public ObjectRecognitionActionResult(HeaderMsg header, GoalStatusMsg status, ObjectRecognitionResult result) : base(header, status)
        {
            this.result = result;
        }
#else
        public ObjectRecognitionActionResult(sbyte status, ObjectRecognitionResult result) : base(status)
        {
            this.result = result;
        }
#endif
        public static ObjectRecognitionActionResult Deserialize(MessageDeserializer deserializer) => new ObjectRecognitionActionResult(deserializer);

        ObjectRecognitionActionResult(MessageDeserializer deserializer) : base(deserializer)
        {
            this.result = ObjectRecognitionResult.Deserialize(deserializer);
        }
        public override void SerializeTo(MessageSerializer serializer)
        {
#if !ROS2
            serializer.Write(this.header);
#endif
            serializer.Write(this.status);
            serializer.Write(this.result);
        }

    }
}
