using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Product.Application.Services.Front.Catalogs.Dtos
{
    public class BottomOutput: BottomOutput<BottomOutput>
    {

    }
    public class BottomOutput<T> : NavgationOutput where T : BottomOutput<T>
    {
        [Newtonsoft.Json.JsonIgnore]
        public virtual List<string> Cids { get; set; }

        /// <summary>
        /// 子集
        /// </summary>
        public virtual List<T> Children { get; set; }
    }
}
