/* 
 * 文件名：IOrderConsumer.cs
 * 文件功能描述：顺序消息消费者接口 
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
    public interface IOrderConsumer<L> where L : ons.MessageOrderListener
    {

        void CreateOrderConsumer();

        void StartOrderConsumer();

        void ShutdownOrderConsumer();

        void Subscribe(string subExpression = "*");
    }
}
