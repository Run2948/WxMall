using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Cms.Service.Config
{
    /// <summary>
    /// 可xml序列化的TimeSpan类
    /// </summary>
    [Serializable]
    public class XmlTimeSpan
    {
        // Local Variable
        private TimeSpan m_TimeSinceLastEvent;

        // Public Property - XmlIgnore as it doesn't serialize anyway
        [XmlIgnore]
        public TimeSpan TimeSinceLastEvent
        {
            get { return m_TimeSinceLastEvent; }
            set { m_TimeSinceLastEvent = value; }
        }

        // Pretend property for serialization
        [XmlElement("TimeSinceLastEvent")]
        public long TimeSinceLastEventTicks
        {
            get { return m_TimeSinceLastEvent.Ticks; }
            set { m_TimeSinceLastEvent = new TimeSpan(value); }
        }

        public XmlTimeSpan(int hours, int minutes, int seconds)
        {
            m_TimeSinceLastEvent = new TimeSpan(hours, minutes, seconds);
        }
        public XmlTimeSpan(int days, int hours, int minutes, int seconds)
        {
            m_TimeSinceLastEvent = new TimeSpan(days, hours, minutes, seconds);
        }
        public XmlTimeSpan()
        { }
    }
}
