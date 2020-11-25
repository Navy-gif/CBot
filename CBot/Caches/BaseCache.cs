using CBot.RESTOptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CBot.Caches
{
    abstract class BaseCache<TKey, TVal>
    {

        protected BaseClient Client;
        protected Dictionary<TKey, TVal> Cache;

        public BaseCache (BaseClient Client)
        {
            this.Client = Client;
            this.Cache = new Dictionary<TKey, TVal>();
        }

        public abstract TVal Resolve(TKey Key);

        public abstract BaseCache<TKey, TVal> Fetch(CacheFetchOptions Options);

        public abstract Task<TVal> Fetch(TKey Key);

        public bool Has(TKey Key)
        {
            return Cache.ContainsKey(Key);
        }

        public TVal Get(TKey Key)
        {
            if (Cache.TryGetValue(Key, out TVal Result)) return Result;
            else return default(TVal);
        }

        public bool TryGet(TKey Key, out TVal Result)
        {
            return Cache.TryGetValue(Key, out Result);
        }

        public abstract TVal Create(RestOptions Options);

        public abstract TVal CreateEntry(JsonElement Data);

    }
}
