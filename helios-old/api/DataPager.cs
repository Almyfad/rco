using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;



    public class DataPagerQueryParams
    {
        public int? page { get; set; }
        public int? size { get; set; }
    }

    public class DataPager<T>
    {
        public int total { get; set; }
        public int totalpage { get; set; }
        public int page { get; set; }
        public int size { get; set; }
        public required IEnumerable<T> data { get; set; }

    }
    public static class DataPagerExtension
    {

        public async static Task<DataPager<TSource>> DataPage<TSource, TKey>(this IQueryable<TSource> data, Expression<Func<TSource, TKey>> keySelector, DataPagerQueryParams queryParams)
        {
            return await DataPage(data, keySelector, queryParams.page ?? 1, queryParams.size ?? 100);
        }

        public async static Task<DataPager<TResult>> DataPage<TSource, TResult, TKey>(this IQueryable<TSource> data, Expression<Func<TSource, TKey>> keySelector, DataPagerQueryParams queryParams, Func<TSource, TResult> selector)
        {
            return await DataPage(data, keySelector, queryParams.page ?? 1, queryParams.size ?? 100, selector);
        }


        private async static Task<DataPager<TSource>> DataPage<TSource, TKey>(
         this IQueryable<TSource> data, Expression<Func<TSource, TKey>> keySelector,
         int page, int size)
        {

            var total = await data.CountAsync();
            int totalpage = total % size == 0 ? total / size : total / size + 1;
            var paginatedData = await data._DataPage(keySelector, page, size);

            return new DataPager<TSource>
            {
                total = total,
                totalpage = totalpage,
                page = page,
                size = size,
                data = paginatedData
            };
        }




        private async static Task<DataPager<TResult>> DataPage<TSource, TResult, TKey>(
         this IQueryable<TSource> data, Expression<Func<TSource, TKey>> keySelector,
         int page, int size, Func<TSource, TResult> selector)
        {

            var total = await data.CountAsync();
            int totalpage = total % size == 0 ? total / size : total / size + 1;
            var paginatedData = await data._DataPage(keySelector, page, size, selector);

            return new DataPager<TResult>
            {
                total = total,
                totalpage = totalpage,
                page = page,
                size = size,
                data = paginatedData
            };
        }


        private async static Task<IEnumerable<TResult>> _DataPage<TSource, TResult, TKey>(
        this IQueryable<TSource> data, Expression<Func<TSource, TKey>> keySelector,
        int page, int size, Func<TSource, TResult> selector)
        {
            var paginatedData = await _DataPage(data, keySelector, page, size);

            return paginatedData.Select(selector);

        }



        private async static Task<IEnumerable<TSource>> _DataPage<TSource, TKey>(
            this IQueryable<TSource> data, Expression<Func<TSource, TKey>> keySelector,
            int page, int size)
        {
            return await data.OrderBy(keySelector).Skip((page - 1) * size).Take(size).ToListAsync();

        }






    }
