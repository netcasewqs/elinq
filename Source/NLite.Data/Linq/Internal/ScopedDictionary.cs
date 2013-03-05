// Copyright (c) Microsoft Corporation.  All rights reserved.
// This source code is made available under the terms of the Microsoft Public License (MS-PL)

using System;
using System.Collections;
using System.Collections.Generic;

namespace NLite.Data.Linq.Internal
{
    class ScopedDictionary<TKey, TValue>
    {
        ScopedDictionary<TKey, TValue> previous;
        Dictionary<TKey, TValue> map;

        public ScopedDictionary(ScopedDictionary<TKey, TValue> previous,IEqualityComparer<TKey> comparer)
        {
            this.previous = previous;
            this.map = new Dictionary<TKey, TValue>(comparer);
        }


        public void Add(TKey key, TValue value)
        {
            this.map.Add(key, value);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            for (ScopedDictionary<TKey, TValue> scope = this; scope != null; scope = scope.previous)
            {
                if (scope.map.TryGetValue(key, out value))
                    return true;
            }
            value = default(TValue);
            return false;
        }

        public bool ContainsKey(TKey key)
        {
            for (ScopedDictionary<TKey, TValue> scope = this; scope != null; scope = scope.previous)
            {
                if (scope.map.ContainsKey(key))
                    return true;
            }
            return false;
        }
    }
}