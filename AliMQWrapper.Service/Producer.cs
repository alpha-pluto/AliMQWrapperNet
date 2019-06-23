/* 
 * 文件名：Producer.cs
 * 文件功能描述：生产者
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

namespace AliMQWrapper.Service
{
    public class Producer : IProducer
    {
        #region properties

        private ons.Producer producer;

        private ons.OrderProducer orderProducer;

        private FactoryProperty factoryProperty;

        public FactoryProperty FactoryProperty { get { return factoryProperty; } set { factoryProperty = value; } }

        #endregion

        #region ctor

        public Producer()
        {
            factoryProperty = new FactoryProperty();
        }

        public Producer(FactoryProperty factoryProperty)
        {
            this.factoryProperty = factoryProperty;
        }

        #endregion

        #region producer

        public void CreateProducer()
        {
            if (null != factoryProperty)
                producer = ons.ONSFactory.getInstance().createProducer(factoryProperty.FactoryInfo);
            else
                throw new ArgumentNullException("factoryProperty must not be empty");
        }

        public void StartProducer()
        {
            producer?.start();
        }

        public void ShutdownProducer()
        {
            producer?.shutdown();
        }


        #endregion

        #region order producer

        public void CreateOrderProducer()
        {
            if (null != factoryProperty)
                orderProducer = ons.ONSFactory.getInstance().createOrderProducer(factoryProperty.FactoryInfo);
            else
                throw new ArgumentNullException("factoryProperty must not be empty");
        }

        public void StartOrderProducer()
        {
            orderProducer?.start();
        }

        public void ShutdownOrderProducer()
        {
            orderProducer.shutdown();
        }

        #endregion

        #region message

        /// <summary>
        /// 向普通队列发送消息
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
            if (null != factoryProperty)
            {
                ons.Message msg = new ons.Message(factoryProperty.FactoryInfo.getPublishTopics(), tag, msgBody);
                msg.setKey(string.IsNullOrEmpty(msgKey) ? Guid.NewGuid().ToString() : msgKey);
                try
                {
                    ons.SendResultONS sendResult = producer.send(msg);
                    errMsg = sendResult.getMessageId();
                    retFlag = true;
                }
                catch (Exception ex)
                {
                    errMsg = ex.ToString();
                }
            }
            else
            {
                errMsg = "factoryProperty must not be empty";
            }
            return retFlag;
        }

        /// <summary>
        /// 向顺序队列发送消息
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
            if (null != factoryProperty)
            {
                ons.Message msg = new ons.Message(factoryProperty.FactoryInfo.getPublishTopics(), tag, msgBody);
                msg.setKey(string.IsNullOrEmpty(msgKey) ? Guid.NewGuid().ToString() : msgKey);
                try
                {
                    ons.SendResultONS sendResult = orderProducer.send(msg, key);
                    errMsg = sendResult.getMessageId();
                    retFlag = true;
                }
                catch (Exception ex)
                {
                    errMsg = ex.ToString();
                }
            }
            else
            {
                errMsg = "factoryProperty must not be empty";
            }
            return retFlag;
        }


        #endregion

    }
}
