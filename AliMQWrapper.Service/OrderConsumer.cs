/* 
 * 文件名：OrderConsumer.cs
 * 文件功能描述：顺序消息消费者
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
    public class OrderConsumer<L> : IOrderConsumer<L> where L : ons.MessageOrderListener
    {

        #region properties

        private ons.OrderConsumer consumer;

        private FactoryProperty factoryProperty;

        public FactoryProperty FactoryProperty { get { return factoryProperty; } set { factoryProperty = value; } }

        private L messageListener;

        public L MessageListener { get { return messageListener; } set { messageListener = value; } }

        #endregion

        #region ctor

        public OrderConsumer()
        {
            factoryProperty = new FactoryProperty();
        }

        public OrderConsumer(FactoryProperty factoryProperty)
        {
            this.factoryProperty = factoryProperty;
        }

        #endregion

        public void CreateOrderConsumer()
        {
            if (null != factoryProperty)
                consumer = ons.ONSFactory.getInstance().createOrderConsumer(factoryProperty.FactoryInfo);
            else
                throw new ArgumentNullException("factoryProperty must not be empty");
        }

        public void StartOrderConsumer()
        {
            consumer?.start();
        }

        public void ShutdownOrderConsumer()
        {
            consumer?.shutdown();
        }

        public void Subscribe(string subExpression = "*")
        {
            consumer.subscribe(factoryProperty.FactoryInfo.getPublishTopics(), subExpression, messageListener);
        }
    }
}
