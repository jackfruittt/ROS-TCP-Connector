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
using RosMessageTypes.ActionMsgs;
#endif

namespace Unity.Robotics.ROSTCPConnector.MessageGeneration
{
#if !ROS2
    // ROS1 ActionResult structure
    public abstract class ActionResult<TResult> : Message where TResult : Message
    {
        public HeaderMsg header { get; set; }
        public GoalStatusMsg status { get; set; }
        public TResult result { get; set; }

        public ActionResult()
        {
            header = new HeaderMsg();
            status = new GoalStatusMsg();
        }

        public ActionResult(HeaderMsg header, GoalStatusMsg status)
        {
            this.header = header;
            this.status = status;
        }

        protected ActionResult(MessageDeserializer deserializer)
        {
            this.header = HeaderMsg.Deserialize(deserializer);
            this.status = GoalStatusMsg.Deserialize(deserializer);
        }
    }
#else
    // ROS2 ActionResult structure - GetResult response includes status code
    public abstract class ActionResult<TResult> : Message where TResult : Message
    {
        // Status codes matching action_msgs/GoalStatus
        public sbyte status { get; set; }
        public TResult result { get; set; }

        public ActionResult()
        {
            status = GoalStatusMsg.STATUS_UNKNOWN;
        }

        public ActionResult(sbyte status)
        {
            this.status = status;
        }

        protected ActionResult(MessageDeserializer deserializer)
        {
            deserializer.Read(out sbyte statusValue);
            this.status = statusValue;
        }
    }
#endif
}
