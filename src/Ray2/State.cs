﻿using System;
using System.Runtime.Serialization;

namespace Ray2
{
    /// <summary>
    /// State abstract class
    /// </summary>
    /// <typeparam name="TStateKey">State id type</typeparam>
    [DataContract]
    public abstract class State<TStateKey> : IState<TStateKey>
    {
        public State()
        {
            this.TypeCode = this.GetType().FullName;
        }
        /// <summary>
        /// State Id
        /// </summary>
       [DataMember]
        public virtual TStateKey StateId { get; set; }
        /// <summary>
        /// State version number
        /// </summary>
        [DataMember]
        public virtual long Version { get; private set; } = 0;
        /// <summary>
        /// Event time corresponding to the status version number
        /// </summary>
        [DataMember]
        public virtual long VersionTime { get; private set; }
        /// <summary>
        /// State type fullname
        /// </summary>
        [DataMember]
        public virtual string TypeCode { get; }
        /// <summary>
        /// next version no
        /// </summary>
        /// <returns></returns>
        public long NextVersion()
        {
            return this.Version+1;
        }
        /// <summary>
        /// Play event modification status
        /// </summary>
        /// <param name="@event"></param>
        public void Player(IEvent @event)
        {
            this.PlayEvent(@event);
            this.Version = @event.Version;
            this.VersionTime = @event.Timestamp;
        }
        /// <summary>
        /// Play event
        /// </summary>
        /// <param name="@event">Event <see cref="IEvent"/></param>
        protected abstract void PlayEvent(IEvent @event);
    }
}
