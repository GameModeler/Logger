using GMLogger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMLogger.Loggers;
using GMLogger.Layout;
using System.Windows;
using System.Reflection;

namespace Logger.Appenders
{
    /// <summary>
    /// Display logs into a custom message box
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MessageBoxCustomAppender<T> : IAppender where T : new()
    {

        private const string DEFAULT_MESSAGE_BOX_CUSTOM_NAME = "GM_MESSAGE_BOX_CUSTOM_APPENDER";

        public string Layout { get; set; }

        public string Name { get; set; }

        private T obj; 

        public MessageBoxCustomAppender(string name)
        {
            Name = name == null ? DEFAULT_MESSAGE_BOX_CUSTOM_NAME : name;
        }


        /// <summary>
        /// Append log
        /// </summary>
        /// <param name="log"></param>
        public void DoAppend(Log log)
        { 
            obj = new T();

            MethodInfo showDMethod = obj.GetType().GetMethod("ShowDialog");
            showDMethod.Invoke(obj, null);
        }
    }
}
