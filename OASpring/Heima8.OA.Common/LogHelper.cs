using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Heima8.OA.Common
{
    //public delegate void WriteLogDel(string str);
    public class LogHelper
    {
        public static Queue<string> ExceptionStringQueue = new Queue<string>();
        public static List<ILogWriter> LogWriterList = new List<ILogWriter>();
        //public static WriteLogDel WriteLogDelFunc;

        static LogHelper()
        {
            //通过多播委托将方法注册到委托中
            //WriteLogDelFunc = new WriteLogDel(WriteLogToFile);
            //WriteLogDelFunc += WriteLogToMongodb;

            //LogWriterList.Add(new TextFileWriter());
            //LogWriterList.Add(new SqlServerWriter());

            LogWriterList.Add(new Log4NetWriter());
            //把从队列中获取错误消息写到日志文件里面去
            ThreadPool.QueueUserWorkItem(o =>
            {
                while (true)
                {
                    lock (ExceptionStringQueue)
                    {
                        if (ExceptionStringQueue.Count > 0)
                        {
                            string str = ExceptionStringQueue.Dequeue();
                            //把异常信息写到日志文件里面去
                            //变化点：有可能写到日志文件，有可能写到数据库里面去。有可能两个地方都写。

                            //执行委托方法。把异常信息写到委托里面去。
                            //WriteLogDelFunc(str);
                            foreach (var logWriter in LogWriterList)
                            {
                                logWriter.WriteLogInfo(str);
                            }
                        }
                        else
                        {
                            Thread.Sleep(30);
                        }
                    }
                }
                
            });
        }

        public static void WriteLogToFile(string txt)
        {

        }
        public static void WriteLogToMongodb(string txt)
        {

        }
        public static void WriteLog(string exceptionText)
        {
            lock (ExceptionStringQueue)
            {
                ExceptionStringQueue.Enqueue(exceptionText);
                if (ExceptionStringQueue.Count > 100)
                {
                    //.....
                }
            }
        }
    }
}
