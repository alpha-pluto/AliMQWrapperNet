/* 
 * 文件名：Consumer.cs
 * 文件功能描述：普通消息消费者
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
    /// <summary>
    /// 普通消息消费者
    /// </summary>
    /// <typeparam name="L"></typeparam>
    public class Consumer<L> : IConsumer<L> where L : ons.MessageListener
    {
        #region properties

        private ons.PushConsumer consumer;

        private FactoryProperty factoryProperty;

        public FactoryProperty FactoryProperty { get { return factoryProperty; } set { factoryProperty = value; } }

        private L messageListener;

        public L MessageListener { get { return messageListener; } set { messageListener = value; } }

        private string subExpression = "*";

        public string SubExpression { get { return subExpression; } set { subExpression = value; } }

        #endregion

        #region ctor

        public Consumer()
        {
            factoryProperty = new FactoryProperty();
        }

        public Consumer(FactoryProperty factoryProperty)
        {
            this.factoryProperty = factoryProperty;
        }

        #endregion

        #region consumer actions

        public void CreatePushConsumer()
        {
            if (null != factoryProperty)
                consumer = ons.ONSFactory.getInstance().createPushConsumer(factoryProperty.FactoryInfo);
            else
                throw new ArgumentNullException("factoryProperty must not be empty");
        }

        public void StartPushConsumer()
        {
            consumer?.start();
        }

        public void ShutdownPushConsumer()
        {
            consumer?.shutdown();
        }

        public void Subscribe(string subExpression = "*")
        {
            consumer?.subscribe(factoryProperty.FactoryInfo.getPublishTopics(), subExpression, messageListener);
        }

        #endregion

        #region consumer action suit

        public void StartConsumer()
        {
            CreatePushConsumer();

            Subscribe(SubExpression);

            StartPushConsumer();
        }

        public void ShutdownConsumer()
        {
            ShutdownPushConsumer();
        }

        #endregion
    }
}
