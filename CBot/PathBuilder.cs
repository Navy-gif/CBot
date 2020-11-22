using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CBot
{
    class PathBuilder
    {

        private string Base;
        private string Path;
        private Hashtable QueryElems = new Hashtable();
        private Uri Built;

        public PathBuilder(string BaseUri)
        {
            Base = BaseUri;
            if (!Base.EndsWith('/')) Base += '/';
        }

        public PathBuilder AddPathElement(string Element)
        {

            if (Built != null) throw new Exception("URI already built.");

            if (Element.StartsWith('/')) Element = Element.Substring(1);

            if (this.Path is null) this.Path = Element;
            else this.Path += Element;

            if (!this.Path.EndsWith('/')) this.Path += '/';

            return this;
        }

        public PathBuilder AddQuery(string key, string value)
        {
            if (Built != null) throw new Exception("URI already built.");
            QueryElems.Add(key, value);
            return this;
        }

        public Uri Build(bool Cache = true)
        {

            if (Built != null) return Built;

            string Out = Base + Path;

            if(QueryElems.Count > 0)
            {
                ICollection Keys = QueryElems.Keys;
                Out += "?";
                int Elements = 0;
                foreach (string Key in Keys)
                {
                    Elements++;
                    string Value = (string)QueryElems[Key];
                    Out += Key + "=" + Value;
                    
                    if (Elements != Keys.Count) Out += '&';
                }
            }

            if (!Cache) return new Uri(Out);

            Built = new Uri(Out);

            return Built;
        }

        public override string ToString()
        {
            if (Built != null) return Built.OriginalString;
            else return "Unbuilt URI: " + Build(false).OriginalString;
        }

    }
}
