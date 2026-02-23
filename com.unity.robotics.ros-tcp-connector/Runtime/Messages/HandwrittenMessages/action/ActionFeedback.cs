/*
© Siemens AG, 2019
Author: Sifan Ye (sifan.ye@siemens.com)

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at
<http://www.apache.org/licenses/LICENSE-2.0>.
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

#if !ROS2
using RosMessageTypes.Actionlib;
using RosMessageTypes.Std;
#else
using RosMessageTypes.UniqueIdentifier;
#endif

namespace Unity.Robotics.ROSTCPConnector.MessageGeneration
{
#if !ROS2
    // ROS1 ActionFeedback structure
    public abstract class ActionFeedback<TFeedback> : Message where TFeedback : Message
    {
        public HeaderMsg header { get; set; }
        public GoalStatusMsg status { get; set; }
        public TFeedback feedback { get; set; }

        public ActionFeedback()
        {
            header = new HeaderMsg();
            status = new GoalStatusMsg();
        }

        public ActionFeedback(HeaderMsg header, GoalStatusMsg status)
        {
            this.header = header;
            this.status = status;
        }

        protected ActionFeedback(MessageDeserializer deserializer)
        {
            this.header = HeaderMsg.Deserialize(deserializer);
            this.status = GoalStatusMsg.Deserialize(deserializer);
        }
    }
#else
    // ROS2 ActionFeedback structure - feedback messages include the goal UUID
    public abstract class ActionFeedback<TFeedback> : Message where TFeedback : Message
    {
        public UUIDMsg goal_id { get; set; }
        public TFeedback feedback { get; set; }

        public ActionFeedback()
        {
            goal_id = new UUIDMsg();
        }

        public ActionFeedback(UUIDMsg goal_id)
        {
            this.goal_id = goal_id;
        }

        protected ActionFeedback(MessageDeserializer deserializer)
        {
            this.goal_id = UUIDMsg.Deserialize(deserializer);
        }
    }
#endif
}
