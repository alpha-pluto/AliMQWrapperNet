/* 
 * 文件名：IConsumer.cs
 * 文件功能描述：消费者接口 
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
    public interface IConsumer<L> where L : ons.MessageListener
    {
        void CreatePushConsumer();

        void StartPushConsumer();

        void Subscribe(string subExpression = "*");

        void ShutdownPushConsumer();


    }
}
