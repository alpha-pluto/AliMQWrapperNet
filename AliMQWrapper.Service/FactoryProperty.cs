/* 
 * 文件名：FactoryProperty.cs
 * 文件功能描述：ons 工厂实现(配置 appkey,appsecret,消息group 等)
 * 创建者：daniel
 * 时间：2019-6-23
 * 版本：1.0.0
 * 
 */
using AliMQWrapper.Core;
using AliMQWrapper.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliMQWrapper.Service
{
    public class FactoryProperty : IFactoryProperty
    {

        #region properties

        private ons.ONSFactoryProperty factoryInfo;

        public ons.ONSFactoryProperty FactoryInfo { get { return factoryInfo; } set { factoryInfo = value; } }

        #endregion

        #region ctor

        public FactoryProperty()
        {
            factoryInfo = new ons.ONSFactoryProperty();
        }

        public FactoryProperty(ons.ONSFactoryProperty factoryInfo)
        {
            this.factoryInfo = factoryInfo;
        }

        #endregion

        #region common setting

        public void SetAccessKey(string accessKey)
        {
            if (!string.IsNullOrEmpty(accessKey))
            {
                factoryInfo.setFactoryProperty(ons.ONSFactoryProperty.AccessKey, accessKey);
            }
            else
            {
                throw new ArgumentNullException("accessKey must not be empty");
            }
        }

        public void SetConsumerId(string consumerId)
        {
            if (!string.IsNullOrEmpty(consumerId))
            {
                factoryInfo.setFactoryProperty(ons.ONSFactoryProperty.ConsumerId, consumerId);
            }
            else
            {
                throw new ArgumentNullException("consumerId must not be empty");
            }
        }

        public void SetLogPath(string logPath)
        {
            if (!string.IsNullOrEmpty(logPath))
            {
                factoryInfo.setFactoryProperty(ons.ONSFactoryProperty.LogPath, logPath);
            }
            else
            {
                throw new ArgumentNullException("logPath must not be empty");
            }
        }

        public void SetMsgContent(string msgContent)
        {
            if (!string.IsNullOrEmpty(msgContent))
            {
                factoryInfo.setFactoryProperty(ons.ONSFactoryProperty.MsgContent, msgContent);
            }
            else
            {
                throw new ArgumentNullException("msgContent must not be empty");
            }
        }

        public void SetNameSrvAddr(string nameSrvAddr)
        {
            if (!string.IsNullOrEmpty(nameSrvAddr))
            {
                factoryInfo.setFactoryProperty(ons.ONSFactoryProperty.NAMESRV_ADDR, nameSrvAddr);
            }
            else
            {
                throw new ArgumentNullException("nameSrvAddr must not be empty");
            }
        }

        public void SetProducerId(string producerId)
        {
            if (!string.IsNullOrEmpty(producerId))
            {
                factoryInfo.setFactoryProperty(ons.ONSFactoryProperty.ProducerId, producerId);
            }
            else
            {
                throw new ArgumentNullException("producerId must not be empty");
            }
        }

        public void SetPublishTopic(string publishTopic)
        {
            if (!string.IsNullOrEmpty(publishTopic))
            {
                factoryInfo.setFactoryProperty(ons.ONSFactoryProperty.PublishTopics, publishTopic);
            }
            else
            {
                throw new ArgumentNullException("publishTopic must not be empty");
            }
        }

        public void SetSecretKey(string secretKey)
        {
            if (!string.IsNullOrEmpty(secretKey))
            {
                factoryInfo.setFactoryProperty(ons.ONSFactoryProperty.SecretKey, secretKey);
            }
            else
            {
                throw new ArgumentNullException("secretKey must not be empty");
            }
        }

        public void SetSubscriptionModel(SubscriptionModel subscriptionModel = SubscriptionModel.CLUSTERING)
        {
            factoryInfo.setFactoryProperty(ons.ONSFactoryProperty.MessageModel, subscriptionModel == SubscriptionModel.CLUSTERING ? ons.ONSFactoryProperty.CLUSTERING : ons.ONSFactoryProperty.BROADCASTING);
        }

        #endregion
    }
}
