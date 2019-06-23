/* 
 * 文件名：Consumer.cs
 * 文件功能描述：生产者应用场景实现类
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
    /// 生产者应用场景实现类
    /// </summary>
    public class Producer : RocketMQBase
    {

        #region producer acgent

        protected Service.Producer producerAgent;

        #endregion

        #region ctor

        public Producer()
        {
            iFactoryProperty = new Service.FactoryProperty();

            producerAgent = new Service.Producer();

            producerAgent.FactoryProperty = (Service.FactoryProperty)iFactoryProperty;
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
        public Producer(
            string accessKey,
            string secretKey,
            string producerId,
            string publishTopics,
            string nameSrvAddr,
            string logPath = @"d:\rocket-mq-log")
        {
            iFactoryProperty = new Service.FactoryProperty();
            iFactoryProperty.SetAccessKey(accessKey);
            iFactoryProperty.SetSecretKey(secretKey);
            iFactoryProperty.SetProducerId(producerId);
            iFactoryProperty.SetPublishTopic(publishTopics);
            iFactoryProperty.SetNameSrvAddr(nameSrvAddr);
            iFactoryProperty.SetLogPath(logPath);

            producerAgent = new Service.Producer();

            producerAgent.FactoryProperty = (Service.FactoryProperty)iFactoryProperty;

        }

        public Producer(IFactoryProperty iFactoryProperty)
        {
            this.iFactoryProperty = iFactoryProperty;

            producerAgent = new Service.Producer();

            producerAgent.FactoryProperty = (Service.FactoryProperty)iFactoryProperty;
        }

        #endregion

        #region common message producer

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errMsg"></param>
        /// <param name="msgBody"></param>
        /// <param name="tag"></param>
        /// <param name="msgKey"></param>
        /// <returns></returns>
        public bool SendMessage(out string errMsg, string msgBody, string tag = "RegisterLog", string msgKey = "")
        {
            bool retFlag = false;
            errMsg = string.Empty;
            producerAgent.CreateProducer();
            producerAgent.StartProducer();
            retFlag = producerAgent.SendMessage(out errMsg, msgBody, tag, msgKey);
            //producerAgent.ShutdownProducer();
            return retFlag;
        }

        #endregion

        #region order message producer

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errMsg"></param>
        /// <param name="msgBody"></param>
        /// <param name="tag"></param>
        /// <param name="msgKey"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool SendOrderMessage(out string errMsg, string msgBody, string tag = "RegisterLog", string msgKey = "", string key = "test")
        {
            bool retFlag = false;
            errMsg = string.Empty;
            producerAgent.CreateOrderProducer();
            producerAgent.StartOrderProducer();
            retFlag = producerAgent.SendOrderMessage(out errMsg, msgBody, tag, msgKey);
            //producerAgent.ShutdownOrderProducer();
            return retFlag;
        }

        #endregion

    }
}
