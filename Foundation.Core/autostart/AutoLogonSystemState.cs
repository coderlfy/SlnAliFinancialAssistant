using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fundation.Core
{
    public enum AutoLogonSystemState
    {
        /// <summary>
        /// 已启用
        /// </summary>
        isStart,
        /// <summary>
        /// 未启用
        /// </summary>
        notStart,
        /// <summary>
        /// 认证失败
        /// </summary>
        Authfaild,
        /// <summary>
        /// 系统注册失败
        /// </summary>
        registrationfailed
    }
}
