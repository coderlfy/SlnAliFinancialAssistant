using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fundation.Core
{
    enum ValidateType
    {
        None,
        /// <summary>
        /// 不为空
        /// </summary>
        NotEmpty,
        /// <summary>
        /// 必须为整数
        /// </summary>
        IsNumber,
        /// <summary>
        /// 整数限制长度
        /// </summary>
        NumberLength

    }
}
