using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
#if !ROS2
using RosMessageTypes.Std;
using RosMessageTypes.Actionlib;
#else
using RosMessageTypes.UniqueIdentifier;
#endif

namespace RosMessageTypes.ObjectRecognition
{
    public class ObjectRecognitionActionGoal : ActionGoal<ObjectRecognitionGoal>
    {
        public const string k_RosMessageName = "object_recognition_msgs-master/ObjectRecognitionActionGoal";
        public override string RosMessageName => k_RosMessageName;


        public ObjectRecognitionActionGoal() : base()
        {
            this.goal = new ObjectRecognitionGoal();
        }

#if !ROS2
        public ObjectRecognitionActionGoal(HeaderMsg header, GoalIDMsg goal_id, ObjectRecognitionGoal goal) : base(header, goal_id)
        {
            this.goal = goal;
        }
#else
        public ObjectRecognitionActionGoal(UUIDMsg goal_id, ObjectRecognitionGoal goal) : base(goal_id)
        {
            this.goal = goal;
        }
#endif
        public static ObjectRecognitionActionGoal Deserialize(MessageDeserializer deserializer) => new ObjectRecognitionActionGoal(deserializer);

        ObjectRecognitionActionGoal(MessageDeserializer deserializer) : base(deserializer)
        {
            this.goal = ObjectRecognitionGoal.Deserialize(deserializer);
        }
        public override void SerializeTo(MessageSerializer serializer)
        {
#if !ROS2
            serializer.Write(this.header);
#endif
            serializer.Write(this.goal_id);
            serializer.Write(this.goal);
        }

    }
}
