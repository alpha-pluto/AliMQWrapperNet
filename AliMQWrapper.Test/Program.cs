/* 
 * 文件名：Program.cs
 * 文件功能描述：测试
 * 创建者：daniel
 * 时间：2019-6-23
 * 版本：1.0.0
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AliMQWrapper.Test
{
    class Program
    {
        private const string uriServAddr = @"http://MQ_INST_********.mq-internet-access.mq-internet.aliyuncs.com:80";
        private const string accessKey = "******";
        private const string secretKey = "******";

        private const string topic = "Order";
        private const string producerId = "GID_Order";
        private const string consumerId = "GID_Order";
        private const string logPath = "D://Test//logs//mqlog";

        private const string topicOrder = "Order-Msg";
        private const string oProducerId = "GID_Order_Seq";
        private const string oConsumerId = "GID_Order_Seq";

        private const bool testOrder = false;
        static void Main(string[] args)
        {
            Application.Producer producer = new Application.Producer();
            if (!testOrder)
            {
                #region common message

                producer.SetNameSrvAddr(uriServAddr);
                producer.SetPublishTopic(topic);
                producer.SetProducerId(producerId);
                producer.SetAccessKey(accessKey);
                producer.SetSecretKey(secretKey);
                producer.SetLogPath(logPath);
                string errMsg = string.Empty;
                string msgBody = Newtonsoft.Json.JsonConvert.SerializeObject(new { a = "1", b = 2, c = new List<string> { "good", "apple", "pop", "Home work" } });
                var ret = producer.SendMessage(out errMsg, msgBody, "test-mq");
                Console.WriteLine($"producer.SendMessage=>{errMsg}");
                Console.ReadLine();


                Application.Consumer<MessageHandler> consumer = new Application.Consumer<MessageHandler>();
                consumer.MessageListener = new MessageHandler();
                consumer.SetNameSrvAddr(uriServAddr);
                consumer.SetPublishTopic(topic);
                consumer.SetProducerId(producerId);
                consumer.SetConsumerId(consumerId);
                consumer.SetAccessKey(accessKey);
                consumer.SetSecretKey(secretKey);
                consumer.SetLogPath(logPath);

                consumer.BatchStartConsumer();

                Thread.Sleep(10000);

                consumer.ShutdownConsumer();

                #endregion
            }
            else
            {
                #region order message                
                producer.SetNameSrvAddr(uriServAddr);
                producer.SetPublishTopic(topicOrder);
                producer.SetProducerId(oProducerId);
                producer.SetAccessKey(accessKey);
                producer.SetSecretKey(secretKey);
                producer.SetLogPath(logPath);
                string errMsg = string.Empty;
                string msgBody = Newtonsoft.Json.JsonConvert.SerializeObject(new { a = "1", b = 2, c = new List<string> { "good", "apple", "pop", "order message" } });
                var ret = producer.SendOrderMessage(out errMsg, msgBody, "test-mq");
                Console.WriteLine(errMsg);
                Console.ReadLine();

                Application.OrderConsumer<OrderMessageHandler> consumer = new Application.OrderConsumer<OrderMessageHandler>();
                consumer.MessageListener = new OrderMessageHandler();
                consumer.SetNameSrvAddr(uriServAddr);
                consumer.SetPublishTopic(topicOrder);
                consumer.SetProducerId(oProducerId);
                consumer.SetConsumerId(oConsumerId);
                consumer.SetAccessKey(accessKey);
                consumer.SetSecretKey(secretKey);
                consumer.SetLogPath(logPath);

                consumer.BatchStartConsumer();

                Thread.Sleep(10000);

                consumer.ShutdownConsumer();

                #endregion
            }


        }
    }

    public class MessageHandler : ons.MessageListener
    {
        public MessageHandler()
        {

        }

        /// <summary>
        /// 析构函数
        /// </summary>
        ~MessageHandler()
        {

        }

        public override ons.Action consume(ons.Message value, ons.ConsumeContext context)
        {
            var tag = value.getTag();
            var messageId = value.getMsgID();
            var key = value.getKey();
            Byte[] text = Encoding.Default.GetBytes(value.getBody());

            Console.WriteLine($"{tag},{key},{messageId},{Encoding.UTF8.GetString(text)}");

            return ons.Action.CommitMessage;
        }
    }

    public class OrderMessageHandler : ons.MessageOrderListener
    {

        public OrderMessageHandler()
        {

        }

        ~OrderMessageHandler()
        {

        }

        public override ons.OrderAction consume(ons.Message value, ons.ConsumeOrderContext context)
        {
            var tag = value.getTag();
            var messageId = value.getMsgID();
            var key = value.getKey();
            Byte[] text = Encoding.Default.GetBytes(value.getBody());
            Console.WriteLine($"{tag},{key},{messageId},{Encoding.UTF8.GetString(text)}");
            return ons.OrderAction.Success;
        }

    }
}
