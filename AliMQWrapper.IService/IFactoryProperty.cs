/* 
 * 文件名：IFactoryProperty.cs
 * 文件功能描述：ons 工厂接口
 * 创建者：daniel
 * 时间：2019-6-23
 * 版本：1.0.0
 * 
 */
using AliMQWrapper.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliMQWrapper.IService
{
    public interface IFactoryProperty
    {
        #region common settings

        /// <summary>
        /// 设置阿里云身份验证 AccessKey
        /// AccessKey 阿里云身份验证，在阿里云服务器管理控制台创建
        /// </summary>
        /// <param name="accessKey"></param>
        void SetAccessKey(string accessKey);

        /// <summary>
        /// 设置阿里云身份验证 SecretKey
        /// SecretKey 阿里云身份验证，在阿里云服务器管理控制台创建
        /// </summary>
        /// <param name="secretKey"></param>
        void SetSecretKey(string secretKey);

        /// <summary>
        /// 设置消费（订阅）者Id
        /// 您在控制台创建的 Consumer ID,可以同GroupId
        /// </summary>
        /// <param name="consumerId"></param>
        void SetConsumerId(string consumerId);

        /// <summary>
        /// 设置生产者Id
        /// 您在控制台创建的 Procuder ID,可以同GroupId
        /// </summary>
        /// <param name="producerId"></param>
        void SetProducerId(string producerId);

        /// <summary>
        /// 设置主题
        /// 您在控制台创建的 Topic
        /// </summary>
        /// <param name="publishTopic"></param>
        void SetPublishTopic(string publishTopic);

        /// <summary>
        /// 设置 TCP 接入域名，进入控制台的实例管理页面的“获取接入点信息”区域查看
        /// </summary>
        /// <param name="nameSrvAddr"></param>
        void SetNameSrvAddr(string nameSrvAddr);

        /// <summary>
        /// 设置消息文本
        /// </summary>
        /// <param name="msgContent"></param>
        void SetMsgContent(string msgContent);

        /// <summary>
        /// 设置订阅方式
        /// </summary>
        /// <param name="subscriptionModel"></param>
        void SetSubscriptionModel(SubscriptionModel subscriptionModel = SubscriptionModel.CLUSTERING);

        /// <summary>
        /// 设置日志路径
        /// </summary>
        /// <param name="logPath"></param>
        void SetLogPath(string logPath);

        #endregion

        #region factoryinfo

        ons.ONSFactoryProperty FactoryInfo { get; set; }

        #endregion
    }
}
