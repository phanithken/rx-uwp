﻿using RxUWPLibrary.Disposable;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;

namespace RxUWPLibrary.Observable.Extensiions
{
    public static class ObservableExtensions
    {
        #region Method

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static IObservable<T> Bind<T>(this IObservable<T> source, Subject<T> to) {
            return source.Do(value => to.OnNext(value));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="bag"></param>
        public static void DisposeBag<T>(this IObservable<T> source, DisposeBag bag) {
            var token = source.Subscribe(observer => { });
            bag.Collect(token);
        }

        #endregion
    }
}
