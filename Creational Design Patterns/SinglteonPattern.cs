using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns.Creational_Design_Patterns
{
    public class SinglteonPattern
    {
        public sealed class LazySingleton
        {
            private static LazySingleton _instance = null;
            private LazySingleton() { }

            public static LazySingleton Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = new LazySingleton();
                        return _instance;
                    }
                    return _instance;
                }
            }
        }

        public sealed class ThreadSafeSingleton
        {
            private static ThreadSafeSingleton _instance = null;
            private static readonly object _lock = new object();
            private ThreadSafeSingleton() { }
            public static ThreadSafeSingleton Instance
            {
                get
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ThreadSafeSingleton();
                            return _instance;
                        }
                        return _instance;
                    }
                }
            }
        }

        public sealed class DoubleCheckLockingSingleton
        {
            private static DoubleCheckLockingSingleton _instance = null;
            private static readonly object _lock = new object();
            private DoubleCheckLockingSingleton() { }
            public static DoubleCheckLockingSingleton Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        lock (_lock)
                        {
                            if (_instance == null)
                            {
                                _instance = new DoubleCheckLockingSingleton();
                                return (_instance);
                            }
                            else
                            {
                                return _instance;
                            }
                        }
                    }
                    return _instance;
                }
            }

            public sealed class EagerSingleton
            {
                private static readonly EagerSingleton _instance = new();
                private static readonly object _lock = new object();
                private EagerSingleton() { }
                public static EagerSingleton Instance
                {
                    get
                    {
                        return _instance;
                    }
                }
            }

            public sealed class StaticSingleton
            {
                private static readonly StaticSingleton _instance;
                private StaticSingleton() { }
                static StaticSingleton()
                {
                    try
                    {
                        _instance = new StaticSingleton();
                    }
                    catch (Exception e)
                    {

                    }
                }
                public static StaticSingleton Instance => _instance;
            }


            public sealed class BillPughSingleton
            {
                private BillPughSingleton() { }
                private static class SingletonHelper
                {
                    internal static readonly BillPughSingleton Instance = new();
                }

                public static BillPughSingleton Instance
                {
                    get
                    {
                        return SingletonHelper.Instance;
                    }
                }
            }

            public sealed class ModernLazySingleton
            {
                private static readonly Lazy<ModernLazySingleton> _lazy = new(new ModernLazySingleton());
                private ModernLazySingleton() { }
                public ModernLazySingleton Instance => _lazy.Value;
            }
        }
    }
}
