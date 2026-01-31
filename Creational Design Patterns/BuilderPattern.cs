using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns.Creational_Design_Patterns
{
    public class BuilderPattern
    {
        public class HTTPMethod
        {
            public string method;
            public string url;
            public string path;
            public string query;
            public string fragment;

            private HTTPMethod(Builder builder)
            {
                method = builder.Method;
                url = builder.Url;
                path = builder.Path;
                query = builder.Query;
                fragment = builder.Fragment;
            }

            public override string ToString()
            {
                return $"URL:{this.url}, Method: {this.method}, Path: {this.path}, Query: {this.query}, Fragment: {this.fragment}";
            }
            public class Builder
            {
                public string Method { get; private set; } = "GET";
                public string Url { get; private set; }
                public string Path { get; private set; } = "";
                public string Query { get; private set; } = "";
                public string Fragment { get; private set; } = "";

                public Builder(string url)
                {
                    Url = url;
                }

                public Builder SetMethod(string method)
                {
                    this.Method = method;
                    return this;
                }

                public Builder SetQuery(string query)
                {
                    this.Query = query;
                    return this;
                }

                public Builder SetPath(string path)
                {
                    this.Path = path;
                    return this;
                }

                public Builder SetFragment(string fragment)
                {
                    Fragment = fragment;
                    return this;
                }

                public HTTPMethod Build()
                {
                    return new HTTPMethod(this);
                }

            }
        }

        public class Program()
        {
            //public static void Main(string[] args)
            //{
            //    HTTPMethod request = new HTTPMethod.Builder("url").Build();
            //    HTTPMethod req2 = new HTTPMethod.Builder("http://req2").SetQuery("asdasd").SetMethod("POST").Build();
            //    Console.WriteLine(request.ToString());
            //    Console.WriteLine(req2.ToString());
            //}
        }

        
    }
}
