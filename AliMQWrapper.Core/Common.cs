/* 
 * 文件名：Common.cs
 * 文件功能描述：ons 通用 配置 
 * 创建者：daniel
 * 时间：2019-6-23
 * 版本：1.0.0
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliMQWrapper.Core
{
    /// <summary>
    /// 订阅方式
    /// 消息队列 RocketMQ 支持以下两种订阅方式：
    /// </summary>
    public enum SubscriptionModel
    {
        /// <summary>
        /// 集群订阅
        /// 同一个 Group ID 所标识的所有 Consumer 平均分摊消费消息。 
        /// 例如某个 Topic 有 9 条消息，一个 Group ID 有 3 个 Consumer 实例，那么在集群消费模式下每个实例平均分摊，只消费其中的 3 条消息。
        /// </summary>
        CLUSTERING,

        /// <summary>
        /// 广播订阅
        /// 同一个 Group ID 所标识的所有 Consumer 都会各自消费某条消息一次。 
        /// 例如某个 Topic 有 9 条消息，一个 Group ID 有 3 个 Consumer 实例，那么在广播消费模式下每个实例都会各自消费 9 条消息。
        /// </summary>
        BROADCASTING
    }
}
