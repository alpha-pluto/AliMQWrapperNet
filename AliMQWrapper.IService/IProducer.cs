/* 
 * 文件名：IProducer.cs
 * 文件功能描述：生产者接口 
 * 创建者：daniel
 * 时间：2019-6-23
 * 版本：1.0.0
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliMQWrapper.IService
{
    public interface IProducer
    {
        #region 

        /// <summary>
        /// 创建生产者
        /// </summary>
        void CreateProducer();

        /// <summary>
        /// 启动生产者
        /// </summary>
        void StartProducer();

        /// <summary>
        /// 关闭生产者
        /// </summary>
        void ShutdownProducer();

        /// <summary>
        /// 创建顺序生产者
        /// </summary>
        void CreateOrderProducer();

        /// <summary>
        /// 启动顺序生产者
        /// </summary>
        void StartOrderProducer();

        /// <summary>
        /// 关闭顺序生产者
        /// </summary>
        void ShutdownOrderProducer();

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="errMsg"></param>
        /// <param name="msgBody"></param>
        /// <param name="tag"></param>
        /// <param name="msgKey"></param>
        /// <returns></returns>
        bool SendMessage(out string errMsg, string msgBody, String tag = "RegisterLog", String msgKey = "");

        /// <summary>
        /// 发送顺序消息
        /// </summary>
        /// <param name="errMsg"></param>
        /// <param name="msgBody"></param>
        /// <param name="tag"></param>
        /// <param name="msgKey"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        bool SendOrderMessage(out string errMsg, string msgBody, String tag = "RegisterLog", String msgKey = "", String key = "test");

        #endregion

    }
}
