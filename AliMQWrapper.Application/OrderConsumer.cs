/* 
 * 文件名：OrderConsumer.cs
 * 文件功能描述：顺序消息队列 消费者 应用场景 实现类
 * 创建者：daniel
 * 时间：2019-6-23
 * 版本：1.0.0
 * 
 */
using AliMQWrapper.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliMQWrapper.Application
{
    /// <summary>
    /// 顺序消息队列 消费者 应用场景 实现类
    /// </summary>
    /// <typeparam name="L"></typeparam>
    public class OrderConsumer<L> : RocketMQBase where L : ons.MessageOrderListener
    {
        #region consumer acgent

        protected Service.OrderConsumer<L> consumerAgent;

        #endregion

        #region ctor

        public OrderConsumer()
        {
            iFactoryProperty = new Service.FactoryProperty();

            consumerAgent = new Service.OrderConsumer<L>();

            consumerAgent.FactoryProperty = (Service.FactoryProperty)iFactoryProperty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessKey"></param>
        /// <param name="secretKey"></param>
        /// <param name="producerId"></param>
        /// <param name="publishTopics"></param>
        /// <param name="nameSrvAddr"></param>
        /// <param name="logPath"></param>
        public OrderConsumer(
            string accessKey,
            string secretKey,
            string producerId,
            string publishTopics,
            string nameSrvAddr,
            string logPath = @"d:\rocket-mq-order-log")
        {
            iFactoryProperty = new Service.FactoryProperty();
            iFactoryProperty.SetAccessKey(accessKey);
            iFactoryProperty.SetSecretKey(secretKey);
            iFactoryProperty.SetProducerId(producerId);
            iFactoryProperty.SetPublishTopic(publishTopics);
            iFactoryProperty.SetNameSrvAddr(nameSrvAddr);
            iFactoryProperty.SetLogPath(logPath);

            consumerAgent = new Service.OrderConsumer<L>();

            consumerAgent.FactoryProperty = (Service.FactoryProperty)iFactoryProperty;

        }

        public OrderConsumer(IFactoryProperty iFactoryProperty)
        {
            this.iFactoryProperty = iFactoryProperty;

            consumerAgent = new Service.OrderConsumer<L>();

            consumerAgent.FactoryProperty = (Service.FactoryProperty)iFactoryProperty;
        }

        #endregion

        #region Message Listener

        public L MessageListener { get { return consumerAgent?.MessageListener; } set { consumerAgent.MessageListener = value; } }

        #endregion

        #region consume

        public void CreateConsumer()
        {
            consumerAgent?.CreateOrderConsumer();
        }

        public void StartConsumer()
        {
            consumerAgent?.StartOrderConsumer();
        }

        public void ShutdownConsumer()
        {
            consumerAgent?.ShutdownOrderConsumer();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageListener"></param>
        /// <param name="subExpression"></param>
        public void Subscribe(string subExpression = "*")
        {
            consumerAgent?.Subscribe(subExpression);
        }

        #endregion

        #region consumer action suit

        public void BatchStartConsumer()
        {
            CreateConsumer();
            Subscribe();
            StartConsumer();
        }

        #endregion

    }
}
