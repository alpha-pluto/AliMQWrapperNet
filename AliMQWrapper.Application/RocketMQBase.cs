/* 
 * 文件名：RocketMQBase.cs
 * 文件功能描述：消息队列 基类
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
    /// Rocket 消息队列 基类
    /// </summary>
    public abstract class RocketMQBase
    {
        #region base support

        protected IFactoryProperty iFactoryProperty;

        public virtual void SetAccessKey(string accessKey)
        {
            iFactoryProperty?.SetAccessKey(accessKey);
        }

        public virtual void SetSecretKey(string secretKey)
        {
            iFactoryProperty?.SetSecretKey(secretKey);
        }

        public virtual void SetProducerId(string producerId)
        {
            iFactoryProperty?.SetProducerId(producerId);
        }

        public virtual void SetConsumerId(string consumerId)
        {
            iFactoryProperty?.SetConsumerId(consumerId);
        }

        public virtual void SetPublishTopic(string publishTopic)
        {
            iFactoryProperty?.SetPublishTopic(publishTopic);
        }

        public virtual void SetNameSrvAddr(string nameSrvAddr)
        {
            iFactoryProperty?.SetNameSrvAddr(nameSrvAddr);
        }

        public virtual void SetLogPath(string logPath)
        {
            iFactoryProperty?.SetLogPath(logPath);
        }

        public virtual void SetMsgContent(string msgContent)
        {
            iFactoryProperty?.SetMsgContent(msgContent);
        }

        /// <summary>
        /// 设置订阅模式
        /// 默认为 集群模式
        /// </summary>
        /// <param name="subscriptionModel"></param>
        public virtual void SetSubscriptionModel(Core.SubscriptionModel subscriptionModel = Core.SubscriptionModel.CLUSTERING)
        {
            iFactoryProperty?.SetSubscriptionModel(subscriptionModel);
        }

        #endregion
    }
}
